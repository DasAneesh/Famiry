export type Importance = 'blue' | 'green' | 'purple' | 'red';

export interface DayEvent {
  id: string;
  date: Date;
  title: string;
  description?: string;
  importance: Importance;
  completed: boolean;
}

export interface MonthSummary {
  month: number;        // 0 = January, 11 = December
  events: DayEvent[];
}

export interface YearOverview {
  year: number;         // e.g. 2025
  summary: MonthSummary[];
}
