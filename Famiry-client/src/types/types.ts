export interface CalendarEvent {
  id: string;
  date: Date;
  title: string;
  description: string;
  imageUrl?: string;
}

export interface DayData {
  date: Date;
  isCurrentMonth: boolean;
  isToday: boolean;
  events: CalendarEvent[];
}