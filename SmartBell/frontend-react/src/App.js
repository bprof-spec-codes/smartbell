import React from 'react';

import {useState} from 'react'

//crash course
import Header from './components/Header/Header'
import Rings from './components/Rings/Rings'


const App = () =>{
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

  return(
    <div className='container'>
        <Header/>
        <Rings rings={rings}/>
      </div>
  )
}

export default App;
