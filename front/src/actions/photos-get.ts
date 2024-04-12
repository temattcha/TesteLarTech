'use server';

export type Photo = {
  id: number;
  author: string;
  title: string;
  date: string;
  src: string;
  peso: string;
  idade: string;
  acessos: string;
  total_comments: string;
};

export default async function photosGet() {
  const response = await fetch(
    'http://localhost:5001/api/cats',
  );
  const data = (await response.json()) as Photo[];
  return data;
}
