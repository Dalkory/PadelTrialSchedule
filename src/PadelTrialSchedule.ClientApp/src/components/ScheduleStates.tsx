import { RefreshIcon, SparkIcon } from './Icons';

export function ScheduleSkeleton() {
  return (
    <div className="skeleton-list" aria-label="Загрузка расписания" aria-busy="true">
      {[0, 1, 2].map((item) => (
        <div className="skeleton-group" key={item}>
          <div className="skeleton-line coach-line" />
          <div className="skeleton-card">
            <div className="skeleton-line chip-line" />
            <div className="skeleton-line title-line" />
            <div className="skeleton-line meta-line" />
            <div className="skeleton-line progress-line" />
          </div>
        </div>
      ))}
    </div>
  );
}

export function ScheduleError({ message, onRetry }: { message: string; onRetry: () => void }) {
  return (
    <div className="state-panel" role="alert">
      <span className="state-icon error"><RefreshIcon /></span>
      <h2>Расписание не загрузилось</h2>
      <p>{message}</p>
      <button type="button" onClick={onRetry}><RefreshIcon />Повторить</button>
    </div>
  );
}

export function EmptySchedule({ onReset }: { onReset: () => void }) {
  return (
    <div className="state-panel">
      <span className="state-icon"><SparkIcon /></span>
      <h2>На этот день ничего не найдено</h2>
      <p>Попробуйте выбрать другую дату или сбросить фильтры.</p>
      <button type="button" onClick={onReset}><RefreshIcon />Сбросить фильтры</button>
    </div>
  );
}
