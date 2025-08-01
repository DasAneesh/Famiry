// src/components/CardSelector/CardSelector.tsx
import React from 'react';
import styles from './CardSelector.module.css';

export type CardType = 'day' | 'month' | 'year';

interface CardSelectorProps {
  selected: CardType;
  onChange: (type: CardType) => void;
}

export const CardSelector: React.FC<CardSelectorProps> = ({ selected, onChange }) => {
  return (
    <div className={styles.container}>
      {(['day', 'month', 'year'] as CardType[]).map(type => (
        <button
          key={type}
          className={`${styles.button} ${selected === type ? styles.active : ''}`}
          onClick={() => onChange(type)}
        >
          {type === 'day' ? 'For Days' : type === 'month' ? 'For Months' : 'For Years'}
        </button>
      ))}
    </div>
  );
};
