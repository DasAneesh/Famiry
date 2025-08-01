// src/components/MonthCard/MonthCard.tsx
import React from 'react';
import styles from './MonthCard.module.css';
import type { MonthSummary } from '../../types/calendar';

export interface MonthCardProps {
  summaries: MonthSummary[];    // array длины 12
  onMonthClick: (m: number) => void;
}

export const MonthCard: React.FC<MonthCardProps> = ({ summaries, onMonthClick }) => {
  return (
    <div className={styles.card}>
      <h3 className={styles.title}>Year Overview</h3>
      <div className={styles.grid}>
        {summaries.map((sum, idx) => (
          <div
            key={idx}
            className={styles.cell}
            onClick={() => onMonthClick(sum.month)}
          >
            {new Date(0, sum.month).toLocaleString('default', { month: 'short' })}
            <div className={styles.dot} data-count={sum.events.length}></div>
          </div>
        ))}
      </div>
    </div>
  );
};
