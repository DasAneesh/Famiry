export function formatDate(date: Date): string {
  return date.toLocaleDateString(undefined, {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
  });
}

export function getMonthName(monthIndex: number): string {
  return new Date(0, monthIndex).toLocaleString(undefined, { month: 'long' });
}

export function getWeekDayNames(): string[] {
  return Array.from({ length: 7 }, (_, i) =>
    new Date(1970, 0, 4 + i).toLocaleString(undefined, { weekday: 'short' })
  );
}

export function addDays(date: Date, days: number): Date {
  const d = new Date(date);
  d.setDate(d.getDate() + days);
  return d;
}
