import Feed from "@/components/feed/feed";


export default async function Home() {
  const response = await fetch('http://localhost:5001/api/cats')
  const data = await response.json();

  return (
    <section className="container mainContainer">
      <Feed photos={data} />
    </section>
  );
}
