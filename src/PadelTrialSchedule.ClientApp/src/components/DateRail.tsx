import { useEffect, useRef } from 'react';
import { ArrowLeftIcon, ArrowRightIcon } from './Icons';
import { formatMonth, formatMonthLong, formatWeekday, sameDay } from '../utils/date';

interface DateRailProps {
  dates: Date[];
  selectedDate: Date;
  onSelect: (date: Date) => void;
  onPrevious: () => void;
  onNext: () => void;
}

export function DateRail({ dates, selectedDate, onSelect, onPrevious, onNext }: DateRailProps) {
  const selectedRef = useRef<HTMLButtonElement>(null);

  useEffect(() => {
    selectedRef.current?.scrollIntoView({ behavior: 'smooth', block: 'nearest', inline: 'center' });
  }, [selectedDate]);

  return (
    <section className="date-section" aria-labelledby="date-heading">
      <div className="date-section-title">
        <div>
          <span className="eyebrow">Выберите день</span>
          <h2 id="date-heading">{formatMonthLong(selectedDate)}</h2>
        </div>
        <span className="moscow-time">время МСК</span>
      </div>

      <div className="date-rail-wrap">
        <button className="date-nav" type="button" onClick={onPrevious} aria-label="Предыдущая неделя">
          <ArrowLeftIcon />
        </button>
        <div className="date-rail">
          {dates.map((date) => {
            const selected = sameDay(date, selectedDate);
            return (
              <button
                className={`date-tile${selected ? ' selected' : ''}`}
                key={date.toISOString()}
                ref={selected ? selectedRef : undefined}
                type="button"
                aria-pressed={selected}
                onClick={() => onSelect(date)}
              >
                <span className="date-weekday">{formatWeekday(date)}</span>
                <span className="date-month">{formatMonth(date)}</span>
                <strong>{date.getDate()}</strong>
              </button>
            );
          })}
        </div>
        <button className="date-nav" type="button" onClick={onNext} aria-label="Следующая неделя">
          <ArrowRightIcon />
        </button>
      </div>
    </section>
  );
}
