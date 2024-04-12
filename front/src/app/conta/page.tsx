'use client';

import login from '@/actions/login';
import { useFormState, useFormStatus } from 'react-dom';
import Button from '@/components/forms/button';
import Input from '@/components/forms/input';
import React from 'react';
import Link from 'next/link';
import styles from './conta.module.css';
import ErrorMessage from '@/components/helper/error-message';
import ButtonDanger from '@/components/forms/button-danger';

function FormButton() {
  const { pending } = useFormStatus();

  return (
    <>
      {pending ? (
        <ButtonDanger disabled={pending}>Enviando...</ButtonDanger>
      ) : (
        <ButtonDanger>Apagar</ButtonDanger>
      )}
    </>
  );
}

export default function ContaPage() {
  const [state, action] = useFormState(login, {
    ok: false,
    error: '',
    data: null,
  });

  React.useEffect(() => {
    if (state.ok) window.location.href = '/';
  }, [state.ok]);

  return (
    <section className='animeLeft'>
      <h1 className='title'>Minha Conta</h1>
      <form className={styles.form}>
        <Input label="Usuário" name="username" type="text" />
        <Input label="Senha" name="password" type="password" />
        <ErrorMessage error={state.error} />
        <FormButton />

      </form>
    </section>
  );
}
