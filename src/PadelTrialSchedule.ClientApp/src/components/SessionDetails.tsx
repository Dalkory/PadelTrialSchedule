import { useEffect, useRef } from 'react';
import type { TrialSession } from '../api/types';
import { formatSessionDate, formatTime } from '../utils/date';
import { CoachAvatar } from './CoachAvatar';
import { CalendarIcon, ClockIcon, CloseIcon, LocationIcon, PeopleIcon } from './Icons';

interface SessionDetailsProps {
  session: TrialSession;
  onClose: () => void;
}

export function SessionDetails({ session, onClose }: SessionDetailsProps) {
  const closeRef = useRef<HTMLButtonElement>(null);
  const date = formatSessionDate(session.startsAt);

  useEffect(() => {
    const previousOverflow = document.body.style.overflow;
    document.body.style.overflow = 'hidden';
    closeRef.current?.focus();

    const handleKeyDown = (event: KeyboardEvent) => {
      if (event.key === 'Escape') onClose();
    };
    document.addEventListener('keydown', handleKeyDown);

    return () => {
      document.body.style.overflow = previousOverflow;
      document.removeEventListener('keydown', handleKeyDown);
    };
  }, [onClose]);

  return (
    <div className="modal-backdrop" onMouseDown={(event) => event.target === event.currentTarget && onClose()}>
      <section className="details-modal" role="dialog" aria-modal="true" aria-labelledby="details-title">
        <button ref={closeRef} className="modal-close" type="button" onClick={onClose} aria-label="Закрыть">
          <CloseIcon />
        </button>
        <span className="modal-kicker">Пробная тренировка</span>
        <h2 id="details-title">{session.title}</h2>

        <div className="modal-coach">
          <CoachAvatar name={session.coach.fullName} color={session.coach.accentColor} large />
          <div>
            <strong>{session.coach.fullName}</strong>
            <span>{session.coach.shortBio}</span>
          </div>
        </div>

        <div className="modal-facts">
          <div><CalendarIcon /><span><small>Дата и время</small>{date.weekday}, {date.day} {date.month}, {formatTime(session.startsAt)}</span></div>
          <div><ClockIcon /><span><small>Продолжительность</small>{session.durationMinutes} минут</span></div>
          <div><LocationIcon /><span><small>Станция</small>{session.clubName}, {session.clubAddress}</span></div>
          <div><PeopleIcon /><span><small>Группа</small>{session.level}, свободно {session.availableSpots} из {session.capacity}</span></div>
        </div>

        <div className="modal-note">
          <strong>Как попасть на тренировку?</strong>
          <p>В тестовой версии запись и оплата не выполняются. Карточка показывает все данные, необходимые для будущего подключения процедуры бронирования.</p>
        </div>
        <button className="modal-action" type="button" onClick={onClose}>Понятно</button>
      </section>
    </div>
  );
}
