import React from 'react'
import {useState} from 'react'
import Songs from './Songs'

const SoundUploader = () => {
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
    const deleteSong = (id) =>{
        setSongs(songs.filter((song) => song.id!==id))
        }

    return (
        <div className='container'>
            <h1>Zenék kezelése</h1>
            <h2>Új zeneszám feltöltése</h2>
            <h2>Feltöltött zeneszámok</h2>
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
        </div>
    )
}

export default SoundUploader
