'use server';

import apiError from '@/functions/api-error';
import login from './login'; // Importe a função de login, se necessário

export default async function userPost(state: {}, formData: FormData) {
  const username = formData.get('username') as string | null;
  const password = formData.get('password') as string | null;

  try {
      if (!username || !password) {
          throw new Error('Preencha os dados.');
      }
      if (password.length < 6) {
          throw new Error('A senha deve ter mais de 6 dígitos.');
      }

      const url = `http://localhost:5001/api/users?name=${username}&username=${username}&password=${password}&IsActive=true`;

      const response = await fetch(url, {
          method: 'POST',
          body: formData,
      });

      // Verificar se a requisição foi bem-sucedida
      if (!response.ok) {
          throw new Error('Erro ao cadastrar usuário.');
      }

      // Chamar a função de login para autenticar o usuário recém-criado
      const { ok } = await login({}, formData);

      if (!ok) {
          throw new Error('Erro ao logar.');
      }

      return { data: null, ok: true, error: '' };
  } catch (error) {
      return apiError(error);
  }
}
