import React from 'react';

import {useState} from 'react'

import Rings from './components/Rings/Rings'
import AddRing from './components/Button/AddRing'

//calendar
import MainCalendar from './components/Calendar/MainCalendar'
import ConfigButton from './components/Button/ConfigButton'

//id, bellringtime, interval, intervalseconds, audiopath, type(int)
const App = () =>{
  const [showAddRing, setShowAddRing] = useState(false)

  const [rings, setRings] = useState([
    {
        id:1, //3 fajta csengetés, 4-es ha user által feltöltött zeneszám
        text: 'Alap becsengetés',
        time: '8:00',//a kurzusban "day"
        normal: true //false, ha rendkívüli
    },
    {
        id:2,
        text:'Alap kicsengetés',
        time: '8:50',
        normal: true
    },
    {
        id:3,
        text:'Alap becsengetés',
        time: '9:00',
        normal: true
    },
    {
        id:4,
        text: 'Tűzriadó-próba',
        time: '9:32',
        normal: false
    }
])

  //add ring
  const addRing = (ring) =>{
    //console.log(ring);
    const id=Math.floor(Math.random()*10000)+1
    const newRing = {id, ...ring}
    setRings([...rings, newRing]) //hozzáadjuk a már meglévő tömhöz
  }

  //delete ring
  const deleteRing = (id) =>{
    //console.log('delete', id)
    setRings(rings.filter((ring) => ring.id!==id))
  }

  //toggle reminder
  const toggleReminder = (id) => {
    setRings(rings.map((ring)=>ring.id===id?
    {...ring, normal: !ring.normal}
    :
    ring))
  }

  return(
    <div className='container'>
      <ConfigButton/>
      <MainCalendar
        onAdd={()=>setShowAddRing(!showAddRing)} 
        showAdd={showAddRing}
      />
        {showAddRing && <AddRing onAdd={addRing} />}
        {
          rings.length > 0 ? 
          (
            <Rings 
              rings={rings} 
              onDelete={deleteRing}
              onToggle={toggleReminder}
            />
          ) 
          : 
          (
            'A mai napra nincsenek csengetések'
          )
        }
      </div>
  )
}
export default App;