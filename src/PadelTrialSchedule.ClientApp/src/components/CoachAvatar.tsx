interface CoachAvatarProps {
  name: string;
  color: string;
  large?: boolean;
}

export function getInitials(name: string): string {
  return name
    .split(/\s+/)
    .filter(Boolean)
    .slice(0, 2)
    .map((part) => part[0]?.toUpperCase())
    .join('');
}

export function CoachAvatar({ name, color, large = false }: CoachAvatarProps) {
  return (
    <span
      className={`coach-avatar${large ? ' large' : ''}`}
      style={{ '--avatar-color': color } as React.CSSProperties}
      aria-hidden="true"
    >
      {getInitials(name)}
    </span>
  );
}
