import type { SVGProps } from 'react';

type IconProps = SVGProps<SVGSVGElement>;

const defaults = {
  width: 18,
  height: 18,
  viewBox: '0 0 24 24',
  fill: 'none',
  stroke: 'currentColor',
  strokeWidth: 1.8,
  strokeLinecap: 'round' as const,
  strokeLinejoin: 'round' as const,
  'aria-hidden': true,
};

export function ArrowLeftIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="m15 18-6-6 6-6" /></svg>;
}

export function ArrowRightIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="m9 18 6-6-6-6" /></svg>;
}

export function CalendarIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="M8 2v4M16 2v4M3 10h18" /><rect x="3" y="4" width="18" height="18" rx="3" /></svg>;
}

export function ClockIcon(props: IconProps) {
  return <svg {...defaults} {...props}><circle cx="12" cy="12" r="9" /><path d="M12 7v5l3 2" /></svg>;
}

export function LocationIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="M20 10c0 5-8 12-8 12S4 15 4 10a8 8 0 1 1 16 0Z" /><circle cx="12" cy="10" r="2.5" /></svg>;
}

export function PeopleIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2" /><circle cx="9" cy="7" r="4" /><path d="M22 21v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75" /></svg>;
}

export function RefreshIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="M20 6v5h-5M4 18v-5h5" /><path d="M18.5 9A7 7 0 0 0 6.2 6.2L4 8m16 8-2.2 1.8A7 7 0 0 1 5.5 15" /></svg>;
}

export function CloseIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="m6 6 12 12M18 6 6 18" /></svg>;
}

export function SparkIcon(props: IconProps) {
  return <svg {...defaults} {...props}><path d="m12 3 1.4 4.6L18 9l-4.6 1.4L12 15l-1.4-4.6L6 9l4.6-1.4L12 3Z" /><path d="m19 15 .7 2.3L22 18l-2.3.7L19 21l-.7-2.3L16 18l2.3-.7L19 15Z" /></svg>;
}
