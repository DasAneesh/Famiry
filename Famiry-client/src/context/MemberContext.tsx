import React, { createContext, useState } from 'react';
import type { Member } from '../types/member';
import type { ReactNode } from 'react';

interface MemberContextValue {
  members: Member[];
  addMember: (m: Member) => void;
  removeMember: (id: string) => void;
  updateStatus: (id: string, online: boolean, lastSeen?: string) => void;
}

export const MemberContext = createContext<MemberContextValue | undefined>(undefined);

export const MemberProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [members, setMembers] = useState<Member[]>([]);

  const addMember    = (m: Member)             => setMembers(prev => [...prev, m]);
  const removeMember = (id: string)            => setMembers(prev => prev.filter(x => x.id !== id));
  const updateStatus = (id: string, online: boolean, lastSeen?: string) => {
    setMembers(prev =>
      prev.map(m =>
        m.id === id ? { ...m, online, lastSeen: lastSeen ?? m.lastSeen } : m
      )
    );
  };

  return (
    <MemberContext.Provider value={{ members, addMember, removeMember, updateStatus }}>
      {children}
    </MemberContext.Provider>
  );
};
