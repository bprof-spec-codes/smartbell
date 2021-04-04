import React from 'react'
import DDMenu from '../Button/DDMenu'
import {useState} from 'react'

//rádióműsorokat egytől indexelni
const radioOptions = ['Alap rádióműsor', 'műsor2', 'műsor3'];
const radioOption = radioOptions[0];


const RadioMaker = () => {
    const [songs, setSongs] = useState([
        {
            id:1,
            text: 'BasicSong.mp3',
            length: '3:25',
            used: false
        },
        {
            id:2,
            text: 'RockSong.mp3',
            length: '4:20',
            used: true
        },
        {
            id:3,
            text: 'HouseMusic.mp3',
            length: '10:02',
            used: false
        },
        {
            id:4,
            text: 'FunnyFrogSong.mp3',
            length: '2:44',
            used: true
        },
    ])

    return (
        <div className='container'>
            <h1>Rádióműsor-összeállító</h1><br/>
            <h3>Eddigi rádióműsorjaid: </h3><br/>
            <DDMenu props={radioOptions} first={radioOption}/>
            <h3>Kiválaszott rádióműsor zenéi:</h3>
            {
              songs.length > 0 ? 
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
            <form className='form-control'>
                <h3>Új műsor:</h3>
                <label>Rádióműsor neve</label>
                    <input  
                        placeholder='Adj nevet a rádióműsorodnak' 
                    />
                <input type='submit' className='btn btn-block' value='Új rádióműsor hozzáadása'/>
            <br/><br/>
            <input type='submit' className='btn btn-block' value='Rádióműsorok mentése'/>
            </form>
            
        </div>
    )
}

export default RadioMaker
