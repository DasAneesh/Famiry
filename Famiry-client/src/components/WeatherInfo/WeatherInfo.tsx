import React from 'react';
import './WeatherInfo.css';

interface WeatherInfoProps {
  date: Date;
  temperature: string;
}

const WeatherInfo: React.FC<WeatherInfoProps> = ({ date, temperature }) => {
  const formattedDate = date.toLocaleDateString('en-US', {
    weekday: 'long',
    year: 'numeric',
    month: 'long',
    day: 'numeric'
  });

  return (
    <div className="weather-info">
      <div className="date-display">{formattedDate}</div>
      <h3>Weather Forecast</h3>
      <div className="temperature">
        {temperature}
      </div>
    </div>
  );
};

export default WeatherInfo;