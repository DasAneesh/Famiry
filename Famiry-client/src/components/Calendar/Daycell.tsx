import React from 'react';
import type { DayData } from '../../types/types';
import './styles.css';

interface DayCellProps {
  dayData: DayData;
  onClick: () => void;
}

const DayCell: React.FC<DayCellProps> = ({ dayData, onClick }) => {
  return (
    <div 
      className={`day-cell ${dayData.isCurrentMonth ? '' : 'other-month'} ${dayData.isToday ? 'today' : ''}`}
      onClick={onClick}
    >
      <div className="day-number">{dayData.date.getDate()}</div>
      <div className="day-events">
        {dayData.events.slice(0, 2).map(event => (
          <div key={event.id} className="event-preview">
            {event.imageUrl && (
              <img src={event.imageUrl} alt={event.title} className="event-image-preview" />
            )}
            <span className="event-title">{event.title}</span>
          </div>
        ))}
        {dayData.events.length > 2 && (
          <div className="more-events">+{dayData.events.length - 2} more</div>
        )}
      </div>
    </div>
  );
};

export default DayCell;