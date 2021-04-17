import React from 'react'
import DDMenu from '../Button/DDMenu'
import {useState} from 'react'
import Songs from './Songs'
import UploadFile from '../Button/UploadFile'


//rádióműsorokat egytől indexelni
const radioOptions = ['Alap rádióműsor', 'műsor2', 'műsor3'];
const radioOption = radioOptions[0];


const RadioMaker = () => {
    const [songs, setSongs] = useState([
        {
            id:1,
            text: 'BasicSong.mp3',
            length: '3:25',
            used: true
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
            used: true
        },
        {
            id:4,
            text: 'FunnyFrogSong.mp3',
            length: '2:44',
            used: true
        },
    ])

     //delete song
    const deleteSong = (id) =>{
    setSongs(songs.filter((song) => song.id!==id))
    }

    const [allsongs, setallSongs] = useState([
        {
            id:1,
            text: 'BasicSong.mp3',
            length: '3:25',
            used: true
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
            used: true
        },
        {
            id:4,
            text: 'FunnyFrogSong.mp3',
            length: '2:44',
            used: true
        },
        {
            id:5,
            text: 'OneMoreSong.mp3',
            length: '3:04',
            used: false
        },
        {
            id:6,
            text: 'MorningSong.mp3',
            length: '3:51',
            used: false
        },
    ])

    //delete song
    const deleteFromallSong = (id) =>{
        setallSongs(songs.filter((song) => song.id!==id))
        }

    return (
        <div className='radiocontainer'>
            <div class='row'>
                <div class='column'>
                    <div class='container'>
                        <h1>Rádióműsor-összeállító</h1><br/>
                        <form className='form-control'>
                            <h3>Új műsor:</h3>
                            <label>Rádióműsor neve</label>
                                <input  
                                    placeholder='Adj nevet a rádióműsorodnak' 
                                />
                            <input type='submit' className='btn btn-block' value='Új rádióműsor hozzáadása'/>
                        <br/><br/>
                        <h3>Eddigi rádióműsorjaid: </h3><br/>
                        <DDMenu props={radioOptions} first={radioOption}/>
                        
                        <h3>Kiválaszott rádióműsor zenéi:</h3>
                        {
                        songs.length > 0 ? 
                        (
                            <Songs 
                            songs={songs} 
                            onDelete={deleteSong}
                            />
                        ) 
                        : 
                        (
                            'A kiválasztott rádióműsor nem tartalmaz számokat'
                        )
                        }
                        
                        <input type='submit' className='btn btn-block' value='Rádióműsorok mentése'/>
                        </form>
                    </div>
                    
                </div>
                <div class='column'>
                    <div class='container'>
                        <h1>Zenék kezelése</h1><br/>
                        <h2>Új zeneszám feltöltése</h2>
                        <UploadFile/><br/>
                        <h2>Feltöltött zeneszámok</h2>
                        {
                        allsongs.length > 0 ? 
                        (
                            <Songs 
                            songs={allsongs} 
                            onDelete={deleteSong}
                            />
                        ) 
                        : 
                        (
                            'A kiválasztott rádióműsor nem tartalmaz számokat'
                        )
                        }
                    </div>
                </div>
            </div>          
        </div>
    )
}

export default RadioMaker
