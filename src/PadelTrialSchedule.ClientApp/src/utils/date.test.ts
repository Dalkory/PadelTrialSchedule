import { describe, expect, it } from 'vitest';
import { addDays, fromApiDate, getScheduleDates, sameDay, toApiDate } from './date';

describe('date utilities', () => {
  it('serializes a local date without a timezone shift', () => {
    expect(toApiDate(new Date(2026, 6, 21, 23, 45))).toBe('2026-07-21');
  });

  it('builds a consecutive two-week rail', () => {
    const dates = getScheduleDates(new Date(2026, 6, 21));
    expect(dates).toHaveLength(14);
    expect(toApiDate(dates[0])).toBe('2026-07-21');
    expect(toApiDate(dates[13])).toBe('2026-08-03');
  });

  it('crosses month boundaries correctly', () => {
    expect(toApiDate(addDays(new Date(2026, 6, 31), 1))).toBe('2026-08-01');
  });

  it('parses API dates and compares calendar days', () => {
    expect(sameDay(fromApiDate('2026-07-21'), new Date(2026, 6, 21, 18, 0))).toBe(true);
    expect(() => fromApiDate('21.07.2026')).toThrow('Некорректная дата.');
  });
});
