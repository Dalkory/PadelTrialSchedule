const API_DATE_PATTERN = /^\d{4}-\d{2}-\d{2}$/;

export function startOfDay(value: Date): Date {
  return new Date(value.getFullYear(), value.getMonth(), value.getDate());
}

export function addDays(value: Date, days: number): Date {
  const result = startOfDay(value);
  result.setDate(result.getDate() + days);
  return result;
}

export function getScheduleDates(from: Date, count = 14): Date[] {
  return Array.from({ length: count }, (_, index) => addDays(from, index));
}

export function toApiDate(value: Date): string {
  const year = value.getFullYear();
  const month = String(value.getMonth() + 1).padStart(2, '0');
  const day = String(value.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

export function fromApiDate(value: string): Date {
  if (!API_DATE_PATTERN.test(value)) {
    throw new Error('Некорректная дата.');
  }

  const [year, month, day] = value.split('-').map(Number);
  return new Date(year, month - 1, day);
}

export function sameDay(left: Date, right: Date): boolean {
  return toApiDate(left) === toApiDate(right);
}

export function formatWeekday(value: Date): string {
  return new Intl.DateTimeFormat('ru-RU', { weekday: 'short' }).format(value).replace('.', '');
}

export function formatMonth(value: Date): string {
  return new Intl.DateTimeFormat('ru-RU', { month: 'short' }).format(value).replace('.', '');
}

export function formatMonthLong(value: Date): string {
  const formatted = new Intl.DateTimeFormat('ru-RU', { month: 'long', year: 'numeric' }).format(value);
  return formatted.charAt(0).toUpperCase() + formatted.slice(1);
}

export function formatTime(value: string): string {
  return new Intl.DateTimeFormat('ru-RU', {
    hour: '2-digit',
    minute: '2-digit',
    timeZone: 'Europe/Moscow',
  }).format(new Date(value));
}

export function formatSessionDate(value: string): { day: string; month: string; weekday: string } {
  const date = new Date(value);
  const parts = new Intl.DateTimeFormat('ru-RU', {
    day: '2-digit',
    month: 'short',
    weekday: 'short',
    timeZone: 'Europe/Moscow',
  }).formatToParts(date);
  const get = (type: Intl.DateTimeFormatPartTypes) => parts.find((part) => part.type === type)?.value.replace('.', '') ?? '';
  return { day: get('day'), month: get('month'), weekday: get('weekday') };
}
