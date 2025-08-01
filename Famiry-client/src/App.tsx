import React, { useState } from 'react';
import { CalendarProvider } from './context/CalendarContext';
import { MemberProvider } from './context/MemberContext';
import { useCalendar } from './hooks/useCalendar';
import { useMembers } from './hooks/useMembers';
import { CardSelector} from './components/CardSelector/CardSelector';
import type { CardType} from './components/CardSelector/CardSelector';
import { DayCard } from './components/DayCard/DayCard';
import { MonthCard } from './components/MonthCard/MonthCard';
import { YearCard } from './components/YearCard/YearCard';
import { SearchBar } from './components/SearchBar/SearchBar';
import { MemberList } from './components/MemberList/MemberList';
import { AddMemberModal } from './components/AddMemberModal/AddMemberModal';

const AppContent: React.FC = () => {
  const { selectedDate, setSelectedDate, events, monthSummaries, yearOverviews } = useCalendar();
  const { members, addMember, removeMember } = useMembers();

  const [cardType, setCardType] = useState<CardType>('day');
  const [searchText, setSearchText] = useState('');
  const [isModalOpen, setModalOpen] = useState(false);

  // фильтрация событий по тексту
  const filteredEvents = events.filter(e =>
    e.title.toLowerCase().includes(searchText.toLowerCase())
  );

  return (
    <div style={{ padding: 20 }}>
      <CardSelector selected={cardType} onChange={setCardType} />
      <SearchBar value={searchText} onChange={setSearchText} />

      {cardType === 'day' && (
        <DayCard
          month={selectedDate.getMonth()}
          year={selectedDate.getFullYear()}
          events={filteredEvents}
          onEventClick={e => alert(e.title)}
        />
      )}
      {cardType === 'month' && (
        <MonthCard
          summaries={monthSummaries}
          onMonthClick={m => setSelectedDate(new Date(selectedDate.getFullYear(), m, 1))}
        />
      )}
      {cardType === 'year' && (
        <YearCard
          overviews={yearOverviews}
          onYearClick={y => setSelectedDate(new Date(y, selectedDate.getMonth(), 1))}
        />
      )}

      <MemberList members={members} onRemove={removeMember} />
      <button onClick={() => setModalOpen(true)}>Add Member</button>
      <AddMemberModal
        isOpen={isModalOpen}
        onClose={() => setModalOpen(false)}
        onAdd={id => addMember({ id, name: id, avatarUrl: '', online: false, lastSeen: '' })}
      />
    </div>
  );
};

export const App: React.FC = () => (
  <CalendarProvider>
    <MemberProvider>
      <AppContent />
    </MemberProvider>
  </CalendarProvider>
);
