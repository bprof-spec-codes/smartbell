import React from 'react' //rafcetabtab

import {FaTimes} from 'react-icons/fa'

const Ring = ({ring, onDelete}) => {
    return (
        <div className='task'>
            <h3>
                {ring.time} {' '}
                <FaTimes 
                style={{color: 'red', cursor: 'pointer'}}
                onClick={() => onDelete(ring.id)}
                />
            </h3>
            <p>{ring.text}</p>
        </div>
    )
}

export default Ring