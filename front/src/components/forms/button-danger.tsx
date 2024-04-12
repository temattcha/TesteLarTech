import React from 'react';
import styles from './button.module.css';

type ButtonType = React.ButtonHTMLAttributes<HTMLButtonElement>;

const ButtonDanger = ({ children, ...props }: ButtonType) => {
  return (
    <button {...props} className={styles.buttondanger}>
      {children}
    </button>
  );
};

export default ButtonDanger;
