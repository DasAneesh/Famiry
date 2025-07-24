export interface Event {
  id: string;
  title: string;
  time: string;
  date: Date;
  description?: string;
  link?: string;
}

export interface WeatherData {
  date: Date;
  temperature: string;
  conditions?: string;
}