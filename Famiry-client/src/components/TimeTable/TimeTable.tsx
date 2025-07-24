import React from 'react';
import './TimeTable.css';

interface TimeSlot {
  time: string;
  sun?: React.ReactNode;
  mon?: React.ReactNode;
  tue?: React.ReactNode;
  wed?: React.ReactNode;
  thu?: React.ReactNode;
  fri?: React.ReactNode;
  sat?: React.ReactNode;
}

const TimeTable: React.FC = () => {
  const timeSlots: TimeSlot[] = [
    { time: '7 AM' },
    { 
      time: '8 AM', 
      mon: <span className="event">Monday Wake-Up Hour</span> 
    },
    { time: '9 AM' },
    { time: '10 AM' },
    { time: '11 AM' },
    { time: '12 PM' },
    { time: '1 PM' },
    { time: '2 PM' },
    { time: '3 PM' },
    { time: '4 PM' },
    { time: '5 PM' },
  ];

  const renderCellContent = (content?: React.ReactNode) => {
    return content || <span className="empty-slot">No events</span>;
  };

  return (
    <div className="time-table">
      <h3>Weekly Schedule</h3>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>SUN</th>
              <th>MON</th>
              <th>TUE</th>
              <th>WED</th>
              <th>THU</th>
              <th>FRI</th>
              <th>SAT</th>
              <th>EST (GMT-5)</th>
            </tr>
          </thead>
          <tbody>
            {timeSlots.map((slot, index) => (
              <tr key={index}>
                <td>{renderCellContent(slot.sun)}</td>
                <td>{renderCellContent(slot.mon)}</td>
                <td>{renderCellContent(slot.tue)}</td>
                <td>{renderCellContent(slot.wed)}</td>
                <td>{renderCellContent(slot.thu)}</td>
                <td>{renderCellContent(slot.fri)}</td>
                <td>{renderCellContent(slot.sat)}</td>
                <td>{slot.time}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default TimeTable;