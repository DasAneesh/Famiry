// src/components/YearCard/YearCard.tsx
import React from 'react';
import styles from './YearCard.module.css';
import type { YearOverview } from '../../types/calendar';

export interface YearCardProps {
  overviews: YearOverview[];    // например, 5–10 лет
  onYearClick: (y: number) => void;
}

export const YearCard: React.FC<YearCardProps> = ({ overviews, onYearClick }) => {
  return (
    <div className={styles.card}>
      <h3 className={styles.title}>Years</h3>
      <div className={styles.grid}>
        {overviews.map((ov, idx) => (
          <div
            key={idx}
            className={styles.cell}
            onClick={() => onYearClick(ov.year)}
          >
            {ov.year}
            <div className={styles.dot} data-count={ov.summary.length}></div>
          </div>
        ))}
      </div>
    </div>
  );
};
