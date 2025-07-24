import React from 'react';
import './Calendar.css';

interface CalendarProps {
  currentDate?: Date;
  onDateChange?: (date: Date) => void;
}

const Calendar: React.FC<CalendarProps> = ({ currentDate = new Date() }) => {
  // Получаем первый день месяца
  const firstDay = new Date(
    currentDate.getFullYear(),
    currentDate.getMonth(),
    1
  );
  
  // Определяем день недели для первого дня месяца (0 - воскресенье, 1 - понедельник и т.д.)
  const firstDayOfWeek = firstDay.getDay();
  
  // Получаем количество дней в месяце
  const daysInMonth = new Date(
    currentDate.getFullYear(),
    currentDate.getMonth() + 1,
    0
  ).getDate();
  
  // Создаем массив дней месяца
  const days = Array.from({ length: daysInMonth }, (_, i) => i + 1);
  
  // Создаем пустые ячейки для дней предыдущего месяца
  const emptyCells = Array.from({ length: firstDayOfWeek }, (_, i) => i);
  
  // Дни недели
  const weekdays = ['SUN', 'MON', 'TUE', 'WED', 'THU', 'FRI', 'SAT'];

  return (
    <div className="calendar">
      <div className="headliner">
        <h2>
          {currentDate.toLocaleString('default', { month: 'long' })} {currentDate.getFullYear()}
        </h2>
      </div>
      
      
      <div className="weekdays-header">
        {weekdays.map(day => (
          <div key={day} className="weekday">{day}</div>
        ))}
      </div>
      
      <div className="days-grid">
        {/* Пустые ячейки в начале месяца */}
        {emptyCells.map((_, index) => (
          <div key={`empty-${index}`} className="day-cell other-month"></div>
        ))}
        
        {/* Дни текущего месяца */}
        {days.map(day => {
          const isCurrentDay = day === currentDate.getDate();
          return (
            <div 
              key={day} 
              className={`day-cell ${isCurrentDay ? 'current-day' : ''}`}
            >
              {day}
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default Calendar;