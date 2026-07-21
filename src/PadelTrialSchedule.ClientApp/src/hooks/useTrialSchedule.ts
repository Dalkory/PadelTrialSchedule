import { useCallback, useEffect, useState } from 'react';
import { getTrialSchedule } from '../api/scheduleApi';
import type { ScheduleFilters, TrialScheduleResponse } from '../api/types';

const EMPTY_FILTERS: ScheduleFilters = {
  cityId: null,
  clubId: null,
  coachId: null,
  type: null,
};

export function useTrialSchedule(selectedDate: Date) {
  const [filters, setFilters] = useState<ScheduleFilters>(EMPTY_FILTERS);
  const [data, setData] = useState<TrialScheduleResponse | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [reloadVersion, setReloadVersion] = useState(0);
  const [defaultsInitialized, setDefaultsInitialized] = useState(false);

  useEffect(() => {
    const controller = new AbortController();

    async function load() {
      setLoading(true);
      setError(null);

      try {
        const response = await getTrialSchedule({ date: selectedDate, ...filters }, controller.signal);
        setData(response);

        if (!defaultsInitialized) {
          const moscow = response.cities.find((city) => city.name === 'Москва');
          setDefaultsInitialized(true);
          if (moscow) {
            setFilters((current) => ({ ...current, cityId: moscow.id }));
          }
        }
      } catch (loadError) {
        if (loadError instanceof DOMException && loadError.name === 'AbortError') return;
        setError(loadError instanceof Error ? loadError.message : 'Не удалось загрузить расписание.');
      } finally {
        if (!controller.signal.aborted) setLoading(false);
      }
    }

    void load();
    return () => controller.abort();
  }, [defaultsInitialized, filters, reloadVersion, selectedDate]);

  const updateFilter = useCallback(<Key extends keyof ScheduleFilters>(key: Key, value: ScheduleFilters[Key]) => {
    setFilters((current) => {
      if (key === 'cityId') {
        return { ...current, cityId: value, clubId: null };
      }

      return { ...current, [key]: value };
    });
  }, []);

  const resetFilters = useCallback(() => setFilters(EMPTY_FILTERS), []);
  const reload = useCallback(() => setReloadVersion((version) => version + 1), []);

  return {
    data,
    error,
    filters,
    loading,
    reload,
    resetFilters,
    updateFilter,
  };
}
