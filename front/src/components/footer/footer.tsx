import Image from 'next/image';
import styles from './footer.module.css';

export default async function Footer() {
  return (
    <footer className={styles.footer}>
      <Image
        src={'/assets/cats-footer.svg'}
        alt="Cats"
        width={52}
        height={44}
      />
      <p>Cats 2024</p>
    </footer>
  );
}
