using NSwag.AspNetCore;
using API.Models;
using API.Data;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {

        // Configuro uma aplicação web cliente/servidor
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Crio uma estrutura de API REST com endpoints
        // onde eu posso mapear chamadas utilizando o protocolo HTTP
        builder.Services.AddEndpointsApiExplorer();

        // headers e títulos
        builder.Services.AddOpenApiDocument(config =>
        {
            config.DocumentName = "API";
            config.Title = "API v1";
            config.Version = "v1";
        });
        // vínculo com o BD
        builder.Services.AddDbContext<AppDbContext>();

        //evitar erros cíclico
        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        // Crio uma aplicação web
        WebApplication app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            // <swagger>
            app.UseOpenApi();
            app.UseSwaggerUi(config =>
            {
                config.DocumentTitle = "Program API";
                config.Path = "/swagger";
                config.DocumentPath = "/swagger/{documentName}/swagger.json";
                config.DocExpansion = "list";
            });
            // </swagger>
        }

        //lista de usuários COM telefones por id
        app.MapGet("/api/userById/{id}", (AppDbContext context, Guid userId) =>
        {
            //eu carrego os usuários e peço pra incluir(Include) os telefones com eager
            var users = context.Users.Include(u => u.Phones);
            return users is not null ? Results.Ok(users) : Results.NotFound();
        }).Produces<User>();

        // lista de usuários COM telefones
        app.MapGet("/api/user", (AppDbContext context) =>
        {
            var users = context.Users.Include(u => u.Phones);
            return users is not null ? Results.Ok(users) : Results.NotFound();
        }).Produces<User>();

        // lista de telefones
        app.MapGet("/api/phones", (AppDbContext context) =>
        {
            var phones = context.Phones;
            return phones is not null ? Results.Ok(phones) : Results.NotFound();
        }).Produces<Phone>();

        // cadastro user
        app.MapPost("/api/users", (AppDbContext context, String? name, String username, String password, String? cpf, String? birthday, bool IsActive = true) =>
        {
            var user = new User(Guid.NewGuid(), name, username, password, cpf, birthday);

            context.Users.Add(user);
            context.SaveChanges();

            return Results.Ok(user);
        }).Produces<User>();

        // cadastro Phone já associando a um User
        app.MapPost("/api/phones", (AppDbContext context, String number, Guid userId, Int16 phoneType) =>
        {
            var phone = new Phone(Guid.NewGuid(), number, userId);
            context.Phones.Add(phone);

            var user = context.Users.Find(userId);
            if (user is not null)
            {
                user.Phones.Add(phone);
                phone.UserId = userId;
            }

            context.SaveChanges();

            return Results.Ok(phone);
        }).Produces<Phone>();

        // Lista de gatos
        app.MapGet("/api/cats", (AppDbContext context) =>
        {
            var cats = context.Cats;
            return cats is not null ? Results.Ok(cats) : Results.NotFound();
        }).Produces<Cat>();

        // Remoção de usuário
        app.MapDelete("/api/users/{id}", async (AppDbContext context, Guid id) =>
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return Results.NotFound();
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // Atualização de usuário por ID
        app.MapPut("/api/user/{id}", async (AppDbContext context, Guid id, User userUpdate) =>
        {
            var existingUser = await context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return Results.NotFound("Usuário não encontrado.");
            }

            // Atualiza os campos do usuário com os valores fornecidos
            existingUser.Name = userUpdate.Name;
            existingUser.Username = userUpdate.Username;
            existingUser.Password = userUpdate.Password;
            existingUser.CPF = userUpdate.CPF;
            existingUser.Birthday = userUpdate.Birthday;
            existingUser.IsActive = userUpdate.IsActive;

            context.Users.Update(existingUser);
            await context.SaveChangesAsync();

            return Results.Ok(existingUser);
        }).Produces<User>();

        
        
        app.Run();
    }
}
