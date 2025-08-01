import { useContext } from 'react';
import { MemberContext } from '../context/MemberContext';

export function useMembers() {
  const ctx = useContext(MemberContext);
  if (!ctx) throw new Error('useMembers must be used within MemberProvider');
  return ctx;
}
