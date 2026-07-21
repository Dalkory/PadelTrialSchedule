import type { LookupOption, ScheduleFilters } from '../api/types';
import { RefreshIcon } from './Icons';

interface FiltersProps {
  filters: ScheduleFilters;
  cities: LookupOption[];
  clubs: LookupOption[];
  coaches: LookupOption[];
  types: LookupOption[];
  onChange: <Key extends keyof ScheduleFilters>(key: Key, value: ScheduleFilters[Key]) => void;
  onReset: () => void;
}

interface SelectFieldProps {
  id: string;
  label: string;
  value: string | null;
  allLabel: string;
  options: LookupOption[];
  onChange: (value: string | null) => void;
}

function SelectField({ id, label, value, allLabel, options, onChange }: SelectFieldProps) {
  return (
    <label className="filter-field" htmlFor={id}>
      <span>{label}</span>
      <select id={id} value={value ?? ''} onChange={(event) => onChange(event.target.value || null)}>
        <option value="">{allLabel}</option>
        {options.map((option) => <option key={option.id} value={option.id}>{option.name}</option>)}
      </select>
    </label>
  );
}

export function Filters({ filters, cities, clubs, coaches, types, onChange, onReset }: FiltersProps) {
  const visibleClubs = filters.cityId
    ? clubs.filter((club) => club.parentId === filters.cityId)
    : clubs;

  return (
    <section className="filters" aria-label="Фильтры расписания">
      <SelectField
        id="city-filter"
        label="Город"
        value={filters.cityId}
        allLabel="Все города"
        options={cities}
        onChange={(value) => onChange('cityId', value)}
      />
      <SelectField
        id="club-filter"
        label="Станция"
        value={filters.clubId}
        allLabel="Все станции"
        options={visibleClubs}
        onChange={(value) => onChange('clubId', value)}
      />
      <SelectField
        id="coach-filter"
        label="Тренер"
        value={filters.coachId}
        allLabel="Все тренеры"
        options={coaches}
        onChange={(value) => onChange('coachId', value)}
      />
      <SelectField
        id="type-filter"
        label="Формат"
        value={filters.type}
        allLabel="Все форматы"
        options={types}
        onChange={(value) => onChange('type', value)}
      />
      <button className="reset-button" type="button" onClick={onReset} aria-label="Сбросить фильтры">
        <RefreshIcon />
        <span>Сбросить</span>
      </button>
    </section>
  );
}
