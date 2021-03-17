import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

//calendar
import Calendar from './components/Calendar';

//calendar miatt off
ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();
