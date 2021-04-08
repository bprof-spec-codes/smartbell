import React from 'react'
import {FaTimes} from 'react-icons/fa'


const Song = ({song,onDelete}) => {
    return (
        <div className={`task ${song.used? 'reminder':''}`}>
            <h3>
                {song.text} {' '}
                <FaTimes 
                    style={{color: 'red', cursor: 'pointer'}}
                    onClick={() => onDelete(song.id)}
                />
            </h3>
            <p>{song.length}</p>
        </div>
    )
}

export default Song
