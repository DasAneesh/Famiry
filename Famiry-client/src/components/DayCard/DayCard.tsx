import React from 'react';
import styles from './DayCard.module.css';
import type { DayEvent } from '../../types/calendar';

export interface DayCardProps {
  month: number;               // 0–11
  year: number;
  events: DayEvent[];          // события с полем date: Date
  onEventClick: (e: DayEvent) => void;
}

export const DayCard: React.FC<DayCardProps> = ({
  month,
  year,
  events,
  onEventClick,
}) => {
  // Собираем даты для 5 строк × 7 дней (35 ячеек)
  const cells = React.useMemo(() => {
    const first = new Date(year, month, 1).getDay(); // 0–6
    const total = new Date(year, month + 1, 0).getDate();
    const arr: (number | null)[] = Array(35).fill(null);
    for (let d = 1; d <= total; d++) {
      arr[first + d - 1] = d;
    }
    return arr;
  }, [month, year]);

  return (
    <div className={styles.card}>
      <h3 className={styles.title}>
        {new Date(year, month).toLocaleString('default', { month: 'long', year: 'numeric' })}
      </h3>
      <div className={styles.grid}>
        {cells.map((day, idx) => {
          const evt = day
            ? events.find(e => e.date.getDate() === day && e.date.getMonth() === month)
            : null;
          return (
            <div
              key={idx}
              className={styles.cell}
              onClick={() => evt && onEventClick(evt)}
            >
              <span className={styles.dayNumber}>{day}</span>
              {evt && <span className={styles.dot} data-importance={evt.importance}></span>}
            </div>
          );
        })}
      </div>
    </div>
  );
};
