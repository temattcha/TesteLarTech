export default async function PerfilUserPage({
  params,
}: {
  params: { user: string };
}) {
  return (
    <section>
      <h1>Usuário: {params.user}</h1>
    </section>
  );
}
