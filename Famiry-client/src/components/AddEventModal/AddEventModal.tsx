import React, { useState } from 'react';
import type { ChangeEvent, FormEvent } from 'react';
import type { Importance } from '../../types/calendar';

interface AddEventModalProps {
  isOpen: boolean;
  onClose: () => void;
  onAdd: (data: { name: string; comment: string; importance: Importance }) => void;
}

export const AddEventModal: React.FC<AddEventModalProps> = ({ isOpen, onClose, onAdd }) => {
  const [name, setName] = useState('');
  const [comment, setComment] = useState('');
  const [importance, setImportance] = useState<Importance>('blue');

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    onAdd({ name, comment, importance });
    onClose();
    setName('');
    setComment('');
    setImportance('blue');
  };

  if (!isOpen) return null;

  return (
    <div className="modal">
      <div className="modal-content">
        <h3>Add Event</h3>
        <form onSubmit={handleSubmit}>
          <input
            placeholder="Name"
            value={name}
            onChange={(e: ChangeEvent<HTMLInputElement>) => setName(e.target.value)}
            required
          />
          <textarea
            placeholder="Comment"
            value={comment}
            onChange={(e: ChangeEvent<HTMLTextAreaElement>) => setComment(e.target.value)}
          />
          <select
            value={importance}
            onChange={(e: ChangeEvent<HTMLSelectElement>) => setImportance(e.target.value as Importance)}
          >
            <option value="blue">Not important</option>
            <option value="green">Slightly important</option>
            <option value="purple">Important</option>
            <option value="red">Emergency</option>
          </select>
          <button type="submit">Add</button>
          <button type="button" onClick={onClose} style={{ backgroundColor: '#ccc' }}>
            Cancel
          </button>
        </form>
      </div>
    </div>
  );
};
