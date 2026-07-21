import type { ScheduleFilters, TrialScheduleResponse } from './types';
import { toApiDate } from '../utils/date';

export interface ScheduleRequest extends ScheduleFilters {
  date: Date;
}

export function buildScheduleUrl(request: ScheduleRequest): string {
  const query = new URLSearchParams();
  const date = toApiDate(request.date);
  query.set('dateFrom', date);
  query.set('dateTo', date);

  if (request.cityId) query.set('cityId', request.cityId);
  if (request.clubId) query.set('clubId', request.clubId);
  if (request.coachId) query.set('coachId', request.coachId);
  if (request.type) query.set('type', request.type);

  return `/api/v1/trial-schedule?${query.toString()}`;
}

export async function getTrialSchedule(
  request: ScheduleRequest,
  signal?: AbortSignal,
): Promise<TrialScheduleResponse> {
  const response = await fetch(buildScheduleUrl(request), {
    headers: { Accept: 'application/json' },
    signal,
  });

  if (!response.ok) {
    const problem = (await response.json().catch(() => null)) as { detail?: string } | null;
    throw new Error(problem?.detail ?? 'Не удалось загрузить расписание.');
  }

  return (await response.json()) as TrialScheduleResponse;
}
