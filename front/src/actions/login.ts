'use server';

import apiError from "@/functions/api-error";

export default async function login(state: {}, formData: FormData) {
  const username = formData.get('username') as string | null;
  const password = formData.get('password') as string | null;

  try {
      if (!username || !password) {
          throw new Error('Preencha os dados.');
      }

      const response = await fetch('http://localhost:5001/api/user');
      const data = await response.json();

      const validUser = data.find((user: any) => user.username === username && user.password === password);

      if (validUser) {
          console.log('Usuário válido:', validUser.username);
          return { data: null, ok: true, error: '' };
      } else {
          throw new Error('Usuário ou senha inválidos.');
      }
  } catch (error) {
      console.log('Erro:', error);
      return apiError(error);
  }

}
