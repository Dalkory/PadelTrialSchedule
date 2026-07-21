import type { TrialSession } from '../api/types';
import { formatSessionDate, formatTime } from '../utils/date';
import { CalendarIcon, ClockIcon, LocationIcon, PeopleIcon, SparkIcon } from './Icons';

interface SessionCardProps {
  session: TrialSession;
  onOpen: (session: TrialSession) => void;
}

export function SessionCard({ session, onOpen }: SessionCardProps) {
  const date = formatSessionDate(session.startsAt);
  const full = session.availableSpots === 0;

  return (
    <article className="session-card">
      <div className="date-badge" aria-label={`${date.day} ${date.month}`}>
        <strong>{date.day}</strong>
        <span>{date.month}</span>
      </div>

      <div className="session-main">
        <span className="type-chip"><SparkIcon />{session.typeLabel}</span>
        <h3>{session.title}</h3>
        <div className="session-metadata">
          <span><CalendarIcon />{date.weekday}, {formatTime(session.startsAt)}</span>
          <span><ClockIcon />{session.durationMinutes} минут</span>
          <span><LocationIcon />{session.clubName}</span>
          <span><PeopleIcon />{session.level}</span>
        </div>
      </div>

      <div className="card-bottom">
        <div className="capacity-block">
          <div className="capacity-segments" aria-label={`Занято ${session.bookedSpots} из ${session.capacity} мест`}>
            {Array.from({ length: session.capacity }, (_, index) => (
              <span className={index < session.bookedSpots ? 'filled' : ''} key={index} />
            ))}
          </div>
          <div className="capacity-copy">
            <span><strong>{session.bookedSpots}</strong>/{session.capacity} участников</span>
            <span className={full ? 'full' : ''}>{full ? 'мест нет' : `осталось: ${session.availableSpots}`}</span>
          </div>
        </div>
        <button className="details-button" type="button" onClick={() => onOpen(session)}>
          Подробнее
        </button>
      </div>
    </article>
  );
}
