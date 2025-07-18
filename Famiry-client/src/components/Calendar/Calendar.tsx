import React, { useState } from 'react';
import type { DayData, CalendarEvent } from '../../types/types';
import DayCell from './Daycell';
import MonthSelector from '../MonthSelector/MonthSelector.tsx';
import EventModal from '../EventModal/EventModal';
import './styles.css';

const Calendar: React.FC = () => {
  const [currentDate, setCurrentDate] = useState<Date>(new Date());
  const [selectedDate, setSelectedDate] = useState<Date | null>(null);
  const [events, setEvents] = useState<CalendarEvent[]>([]);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  const generateDays = (): DayData[] => {
    const year = currentDate.getFullYear();
    const month = currentDate.getMonth();
    
    const firstDayOfMonth = new Date(year, month, 1);
    const lastDayOfMonth = new Date(year, month + 1, 0);
    
    const startDay = firstDayOfMonth.getDay();
    const daysInMonth = lastDayOfMonth.getDate();
    
    const days: DayData[] = [];
    
    // Добавляем дни предыдущего месяца
    const prevMonthLastDay = new Date(year, month, 0).getDate();
    for (let i = startDay - 1; i >= 0; i--) {
      const date = new Date(year, month - 1, prevMonthLastDay - i);
      days.push({
        date,
        isCurrentMonth: false,
        isToday: false,
        events: events.filter(e => 
          e.date.getDate() === date.getDate() && 
          e.date.getMonth() === date.getMonth() && 
          e.date.getFullYear() === date.getFullYear()
        )
      });
    }
    
    // Добавляем дни текущего месяца
    const today = new Date();
    for (let i = 1; i <= daysInMonth; i++) {
      const date = new Date(year, month, i);
      days.push({
        date,
        isCurrentMonth: true,
        isToday: 
          date.getDate() === today.getDate() && 
          date.getMonth() === today.getMonth() && 
          date.getFullYear() === today.getFullYear(),
        events: events.filter(e => 
          e.date.getDate() === date.getDate() && 
          e.date.getMonth() === date.getMonth() && 
          e.date.getFullYear() === date.getFullYear()
        )
      });
    }
    
    // Добавляем дни следующего месяца
    const daysToAdd = 42 - days.length; // 6 недель
    for (let i = 1; i <= daysToAdd; i++) {
      const date = new Date(year, month + 1, i);
      days.push({
        date,
        isCurrentMonth: false,
        isToday: false,
        events: events.filter(e => 
          e.date.getDate() === date.getDate() && 
          e.date.getMonth() === date.getMonth() && 
          e.date.getFullYear() === date.getFullYear()
        )
      });
    }
    
    return days;
  };

  const handleDateClick = (date: Date) => {
    setSelectedDate(date);
    setIsModalOpen(true);
  };

  const handleAddEvent = (event: Omit<CalendarEvent, 'id'>) => {
    const newEvent = {
      ...event,
      id: Math.random().toString(36).substr(2, 9)
    };
    setEvents([...events, newEvent]);
    setIsModalOpen(false);
  };

  const handleDeleteEvent = (id: string) => {
    setEvents(events.filter(event => event.id !== id));
  };

  const days = generateDays();

  return (
    <div className="calendar-container">
      <MonthSelector 
        currentDate={currentDate}
        onDateChange={setCurrentDate}
      />
      
      <div className="calendar-header">
        {['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'].map(day => (
          <div key={day} className="calendar-header-day">{day}</div>
        ))}
      </div>
      
      <div className="calendar-grid">
        {days.map((day, index) => (
          <DayCell 
            key={index}
            dayData={day}
            onClick={() => handleDateClick(day.date)}
          />
        ))}
      </div>
      
      {isModalOpen && selectedDate && (
        <EventModal
          date={selectedDate}
          onClose={() => setIsModalOpen(false)}
          onSave={handleAddEvent}
        />
      )}
    </div>
  );
};

export default Calendar;