import Link from 'next/link';
import styles from './header.module.css';
import Image from 'next/image';

export default async function Header() {

  return (
    <header className={styles.header}>
      <nav className={`${styles.nav} container`}>
        <Link className={styles.logo} href={'/'}>
          <Image
            src={'/assets/cats.svg'}
            alt="Cats"
            width={56}
            height={44}
            priority
          />
        </Link>
        <Link className={styles.login} href={'/conta'} />
      </nav>
    </header>
  );
}
