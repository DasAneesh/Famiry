import React from 'react';
import { Calendar, EventsList, TimeTable, WeatherInfo, PhotoUpload } from './components';

const App: React.FC = () => {
  return (
    <div className="app">
      <Calendar />
      <EventsList />
      <TimeTable />
      <WeatherInfo date={new Date()} temperature="85°/40°" />
      <PhotoUpload onUpload={(url) => console.log('Uploaded:', url)} />
    </div>
  );
};

export default App;