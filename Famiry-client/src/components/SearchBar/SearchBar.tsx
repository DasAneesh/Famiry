// src/components/SearchBar/SearchBar.tsx
import React from 'react';
import type { ChangeEvent } from 'react';
import styles from './SearchBar.module.css';

interface SearchBarProps {
  value: string;
  onChange: (text: string) => void;
  placeholder?: string;
}

export const SearchBar: React.FC<SearchBarProps> = ({
  value,
  onChange,
  placeholder = 'Search…',
}) => {
  const handleInput = (e: ChangeEvent<HTMLInputElement>) => {
    onChange(e.target.value);
  };

  return (
    <div className={styles.wrapper}>
      <input
        type="text"
        className={styles.input}
        value={value}
        onChange={handleInput}
        placeholder={placeholder}
      />
      <button
        className={styles.button}
        onClick={() => onChange(value)}
        aria-label="Search"
      >
        🔍
      </button>
    </div>
  );
};
