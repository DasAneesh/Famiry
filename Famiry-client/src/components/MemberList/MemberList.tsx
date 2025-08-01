// src/components/MemberList/MemberList.tsx
import React from 'react';
import styles from './MemberList.module.css';
import type { Member } from '../../types/member';

interface MemberListProps {
  members: Member[];
  onRemove: (id: string) => void;
}

export const MemberList: React.FC<MemberListProps> = ({ members, onRemove }) => {
  return (
    <div className={styles.container}>
      <h4 className={styles.title}>Members</h4>
      <ul className={styles.list}>
        {members.map(m => (
          <li key={m.id} className={styles.item}>
            <img src={m.avatarUrl} alt={m.name} className={styles.avatar} />
            <div className={styles.info}>
              <span className={styles.name}>{m.name}</span>
              <span
                className={`${styles.status} ${
                  m.online ? styles.online : styles.offline
                }`}
              >
                {m.online ? 'Online' : `Last seen ${m.lastSeen}`}
              </span>
            </div>
            <button
              className={styles.removeBtn}
              onClick={() => onRemove(m.id)}
              aria-label={`Remove ${m.name}`}
            >
              ✕
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};
