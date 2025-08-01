export interface Member {
  id: string;
  name: string;
  avatarUrl: string;
  online: boolean;
  lastSeen: string;     // formatted string, e.g. "20m ago"
}
