// src/components/AddMemberModal/AddMemberModal.tsx
import React, { useState } from 'react';
import type { ChangeEvent, FormEvent } from 'react';
import styles from './AddMemberModal.module.css';

interface AddMemberModalProps {
  isOpen: boolean;
  onClose: () => void;
  onAdd: (memberId: string) => void;
}

export const AddMemberModal: React.FC<AddMemberModalProps> = ({
  isOpen,
  onClose,
  onAdd,
}) => {
  const [query, setQuery] = useState('');
  const [loading, setLoading] = useState(false);
  const [foundId, setFoundId] = useState<string | null>(null);

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setQuery(e.target.value);
  };

  const handleSearch = async (e: FormEvent) => {
    e.preventDefault();
    setLoading(true);
    // TODO: заменить на реальный API-запрос
    await new Promise(res => setTimeout(res, 700));
    setFoundId(query.trim() ? query.trim() : null);
    setLoading(false);
  };

  const handleAdd = () => {
    if (foundId) {
      onAdd(foundId);
      setQuery('');
      setFoundId(null);
      onClose();
    }
  };

  if (!isOpen) return null;
  return (
    <div className={styles.backdrop} onClick={onClose}>
      <div className={styles.modal} onClick={e => e.stopPropagation()}>
        <h3 className={styles.title}>Add Member</h3>
        <form onSubmit={handleSearch} className={styles.form}>
          <input
            type="text"
            value={query}
            onChange={handleChange}
            placeholder="Enter user ID…"
            className={styles.input}
          />
          <button type="submit" className={styles.searchBtn} disabled={loading}>
            {loading ? 'Searching…' : 'Search'}
          </button>
        </form>

        {foundId && (
          <div className={styles.result}>
            <span>User ID: {foundId}</span>
            <button onClick={handleAdd} className={styles.addBtn}>
              Add
            </button>
          </div>
        )}

        <button className={styles.closeBtn} onClick={onClose} aria-label="Close">
          ✕
        </button>
      </div>
    </div>
  );
};
