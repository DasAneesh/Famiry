import React from 'react';
import type { Event } from '../../types/types';
import './EventsList.css';

interface EventsListProps {
  events?: Event[];
}

const EventsList: React.FC<EventsListProps> = ({ events = [] }) => {
  return (
    <div className="events-list">
      <h3>Today's Events</h3>
      
      {events.length === 0 ? (
        <p>No events scheduled</p>
      ) : (
        <ul>
          {events.map((event) => (
            <li key={event.id}>
              <div className="event-time">{event.time}</div>
              <div className="event-details">
                <strong>{event.title}</strong>
                {event.description && (
                  <p className="event-description">{event.description}</p>
                )}
                {event.link && (
                  <a 
                    href={event.link} 
                    target="_blank" 
                    rel="noopener noreferrer"
                    className="event-link"
                  >
                    Join meeting
                  </a>
                )}
              </div>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default EventsList;