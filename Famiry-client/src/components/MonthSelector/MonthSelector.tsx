import React from 'react';
import './styles.css';

interface MonthSelectorProps {
  currentDate: Date;
  onDateChange: (date: Date) => void;
}

const MonthSelector: React.FC<MonthSelectorProps> = ({ currentDate, onDateChange }) => {
  const monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 
                     'July', 'August', 'September', 'October', 'November', 'December'];

  const handlePrevMonth = () => {
    const newDate = new Date(currentDate);
    newDate.setMonth(newDate.getMonth() - 1);
    onDateChange(newDate);
  };

  const handleNextMonth = () => {
    const newDate = new Date(currentDate);
    newDate.setMonth(newDate.getMonth() + 1);
    onDateChange(newDate);
  };

  return (
    <div className="month-selector">
      <button onClick={handlePrevMonth}>&lt;</button>
      <h2>
        {monthNames[currentDate.getMonth()]} {currentDate.getFullYear()}
      </h2>
      <button onClick={handleNextMonth}>&gt;</button>
    </div>
  );
};

export default MonthSelector;