import { describe, expect, it } from 'vitest';
import { buildScheduleUrl } from './scheduleApi';

describe('buildScheduleUrl', () => {
  it('includes selected filters and omits empty values', () => {
    const url = buildScheduleUrl({
      date: new Date(2026, 6, 21),
      cityId: 'city-id',
      clubId: null,
      coachId: 'coach-id',
      type: 'Discovery',
    });

    expect(url).toContain('dateFrom=2026-07-21');
    expect(url).toContain('dateTo=2026-07-21');
    expect(url).toContain('cityId=city-id');
    expect(url).toContain('coachId=coach-id');
    expect(url).toContain('type=Discovery');
    expect(url).not.toContain('clubId=');
  });
});
