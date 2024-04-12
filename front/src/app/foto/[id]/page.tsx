export default async function FotoIdPage({
  params,
}: {
  params: { id: number };
}) {
  return (
    <section>
      <h1>Foto id: {params.id}</h1>
    </section>
  );
}
