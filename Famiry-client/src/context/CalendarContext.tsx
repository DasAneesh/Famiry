import React, { createContext, useState } from 'react';
import type { DayEvent, MonthSummary, YearOverview } from '../types/calendar';
import type { ReactNode } from 'react';

interface CalendarContextValue {
  selectedDate: Date;
  events: DayEvent[];
  monthSummaries: MonthSummary[];
  yearOverviews: YearOverview[];
  setSelectedDate: (d: Date) => void;
  addEvent: (e: DayEvent) => void;
  updateEvent: (e: DayEvent) => void;
  deleteEvent: (id: string) => void;
}

export const CalendarContext = createContext<CalendarContextValue | undefined>(undefined);

export const CalendarProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [selectedDate, setSelectedDate] = useState<Date>(new Date());
  const [events, setEvents] = useState<DayEvent[]>([]);

  const monthSummaries: MonthSummary[] = React.useMemo(() => {
    const groups: Record<number, DayEvent[]> = {};
    events.forEach(e => {
      const m = e.date.getMonth();
      groups[m] = groups[m] || [];
      groups[m].push(e);
    });
    return Array.from({ length: 12 }, (_, m) => ({ month: m, events: groups[m] || [] }));
  }, [events]);

  const yearOverviews: YearOverview[] = React.useMemo(() => {
    const years: Record<number, MonthSummary[]> = {};
    events.forEach(e => {
      const y = e.date.getFullYear();
      if (!years[y]) years[y] = [];
      let ms = years[y].find(x => x.month === e.date.getMonth());
      if (!ms) {
        ms = { month: e.date.getMonth(), events: [] };
        years[y].push(ms);
      }
      ms.events.push(e);
    });
    return Object.entries(years)
      .map(([y, summary]) => ({ year: Number(y), summary }))
      .sort((a, b) => a.year - b.year);
  }, [events]);

  const addEvent    = (e: DayEvent) => setEvents(prev => [...prev, e]);
  const updateEvent = (e: DayEvent) => setEvents(prev => prev.map(x => x.id === e.id ? e : x));
  const deleteEvent = (id: string)   => setEvents(prev => prev.filter(x => x.id !== id));

  return (
    <CalendarContext.Provider value={{
      selectedDate,
      events,
      monthSummaries,
      yearOverviews,
      setSelectedDate,
      addEvent,
      updateEvent,
      deleteEvent,
    }}>
      {children}
    </CalendarContext.Provider>
  );
};
