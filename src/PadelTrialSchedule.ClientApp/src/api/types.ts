export interface LookupOption {
  id: string;
  name: string;
  parentId: string | null;
}

export interface Coach {
  id: string;
  fullName: string;
  shortBio: string;
  accentColor: string;
}

export interface TrialSession {
  id: string;
  title: string;
  type: string;
  typeLabel: string;
  level: string;
  startsAt: string;
  durationMinutes: number;
  capacity: number;
  bookedSpots: number;
  availableSpots: number;
  cityId: string;
  cityName: string;
  clubId: string;
  clubName: string;
  clubAddress: string;
  coach: Coach;
}

export interface TrialScheduleResponse {
  dateFrom: string;
  dateTo: string;
  cities: LookupOption[];
  clubs: LookupOption[];
  coaches: LookupOption[];
  types: LookupOption[];
  sessions: TrialSession[];
  total: number;
}

export interface ScheduleFilters {
  cityId: string | null;
  clubId: string | null;
  coachId: string | null;
  type: string | null;
}
