import React from 'react';
import Calendar from './components/Calendar/Calendar';
import './App.css';

const App: React.FC = () => {
  return (
    <div className="app">
      <h1>My Calendar App</h1>
      <Calendar />
    </div>
  );
};

export default App;