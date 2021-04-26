import React from 'react';

import {useState, useEffect} from 'react'
import {BrowserRouter as Router, Route} from 'react-router-dom'

import Rings from './components/Rings/Rings'
import AddRing from './components/Button/AddRing'

//calendar
import MainCalendar from './components/Calendar/MainCalendar'
import ConfigButton from './components/Button/ConfigButton'
import CalendarConfig from './components/Calendar/CalendarConfig';
import TimeTable from './components/Calendar/TimeTable';

import Header from '../src/components/Header/Header';
import Calendar from 'react-calendar';
import '../src/components/Calendar/MainCalendar.css';

//id, bellringtime, interval, intervalseconds, audiopath, type(int)
const App = () =>{
  const [showAddRing, setShowAddRing] = useState(false)

  const [rings, setRings] = useState([
    {
        id:1, //3 fajta csengetés, 4-es ha user által feltöltött zeneszám
        text: 'Szünet',
        startTime: '8:00',//a kurzusban "day"
        endTime: '8:20',
        normal: true //false, ha rendkívüli
    },
    {
        id:2,
        text:'Szünet',
        startTime: '8:50',
        endTime: '9:20',
        normal: true
    },
    {
        id:3,
        text:'Szünet',
        startTime: '9:00',
        endTime: '9:20',
        normal: true
    },
    {
        id:4,
        text: 'Szünet',
        startTime: '9:32',
        endTime: '9:40',
        normal: false
    }
])

  const [date,setDate] = useState(new Date());   
    useEffect(() => {
      console.log(date);
    }, [date])
    const onChange = date => {
        setDate(date);
    };

  //add ring
  const addRing = (ring) =>{
    //console.log(ring);
    const id=Math.floor(Math.random()*10000)+1
    const newRing = {id, ...ring}
    newRing.text='Szünet'
    setRings([...rings, newRing]) //hozzáadjuk a már meglévő tömhöz
  }

  return(
    <Router>
      <div style={{
        backgroundImage: "url(/logo.png)",
        backgroundRepeat: 'no-repeat',
        backgroundPositionX: '40px',
        backgroundSize: '150px'
        }}>  
        <Route path='/' exact render={(props)=> (
          <div>
            <div className='container'>
            
            <Calendar onChange={onChange} value={date}/>
            <Header
                title={date.toDateString()}
                onAdd={()=>setShowAddRing(!showAddRing)}
                showAdd={showAddRing}
            />
            {console.log(date)}
        </div>
            {showAddRing && <AddRing onAdd={addRing} />}
            <TimeTable date={date}/>
            <ConfigButton/>
          </div>
        )}/>              
        <Route path='/calConfig' component={CalendarConfig}/>

      </div>
    </Router>   
  )
}

export default App;