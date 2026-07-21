import { useCallback, useMemo, useState } from 'react';
import type { TrialSession } from './api/types';
import { Brand } from './components/Brand';
import { CoachAvatar } from './components/CoachAvatar';
import { DateRail } from './components/DateRail';
import { Filters } from './components/Filters';
import { ArrowLeftIcon } from './components/Icons';
import { ScheduleError, ScheduleSkeleton, EmptySchedule } from './components/ScheduleStates';
import { SessionCard } from './components/SessionCard';
import { SessionDetails } from './components/SessionDetails';
import { useTrialSchedule } from './hooks/useTrialSchedule';
import { addDays, getScheduleDates, startOfDay } from './utils/date';

function App() {
  const [railStart, setRailStart] = useState(() => startOfDay(new Date()));
  const [selectedDate, setSelectedDate] = useState(() => startOfDay(new Date()));
  const [activeSession, setActiveSession] = useState<TrialSession | null>(null);
  const schedule = useTrialSchedule(selectedDate);
  const dates = useMemo(() => getScheduleDates(railStart), [railStart]);

  const groupedSessions = useMemo(() => {
    const groups = new Map<string, { coach: TrialSession['coach']; sessions: TrialSession[] }>();
    for (const session of schedule.data?.sessions ?? []) {
      const group = groups.get(session.coach.id);
      if (group) group.sessions.push(session);
      else groups.set(session.coach.id, { coach: session.coach, sessions: [session] });
    }
    return Array.from(groups.values());
  }, [schedule.data?.sessions]);

  const shiftRail = useCallback((days: number) => {
    setRailStart((current) => addDays(current, days));
    setSelectedDate((current) => addDays(current, days));
  }, []);

  return (
    <div id="top" className="app-shell">
      <header className="topbar">
        <a className="back-link" href="#top"><ArrowLeftIcon />Назад</a>
        <Brand />
        <span className="header-label">расписание</span>
      </header>

      <main>
        <section className="hero">
          <span className="hero-pill">Начните играть сегодня</span>
          <h1>Первые пробные<br /><em>тренировки</em></h1>
          <p>Выберите удобный клуб и познакомьтесь с паделом вместе с профессиональным тренером.</p>
        </section>

        <DateRail
          dates={dates}
          selectedDate={selectedDate}
          onSelect={setSelectedDate}
          onPrevious={() => shiftRail(-7)}
          onNext={() => shiftRail(7)}
        />

        <Filters
          filters={schedule.filters}
          cities={schedule.data?.cities ?? []}
          clubs={schedule.data?.clubs ?? []}
          coaches={schedule.data?.coaches ?? []}
          types={schedule.data?.types ?? []}
          onChange={schedule.updateFilter}
          onReset={schedule.resetFilters}
        />

        <section className="schedule-section" aria-live="polite">
          <div className="schedule-heading">
            <div>
              <span className="eyebrow">Доступные занятия</span>
              <h2>Расписание</h2>
            </div>
            {!schedule.loading && !schedule.error && (
              <span className="result-count">{schedule.data?.total ?? 0} {(schedule.data?.total ?? 0) === 1 ? 'тренировка' : 'тренировок'}</span>
            )}
          </div>

          {schedule.error ? <ScheduleError message={schedule.error} onRetry={schedule.reload} /> : null}
          {!schedule.error && schedule.loading ? <ScheduleSkeleton /> : null}
          {!schedule.error && !schedule.loading && groupedSessions.length === 0 ? <EmptySchedule onReset={schedule.resetFilters} /> : null}

          {!schedule.error && !schedule.loading && groupedSessions.map((group) => (
            <div className="coach-group" key={group.coach.id}>
              <div className="coach-heading">
                <CoachAvatar name={group.coach.fullName} color={group.coach.accentColor} />
                <div>
                  <strong>{group.coach.fullName}</strong>
                  <span>{group.coach.shortBio}</span>
                </div>
                <span className="coach-more" aria-hidden="true">•••</span>
              </div>
              {group.sessions.map((session) => <SessionCard key={session.id} session={session} onOpen={setActiveSession} />)}
            </div>
          ))}
        </section>
      </main>

      <footer>
        <Brand />
        <p>Первые шаги в паделе — в комфортном темпе.</p>
        <span>© {new Date().getFullYear()} First Court</span>
      </footer>

      {activeSession ? <SessionDetails session={activeSession} onClose={() => setActiveSession(null)} /> : null}
    </div>
  );
}

export default App;
