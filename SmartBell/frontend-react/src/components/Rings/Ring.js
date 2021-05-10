import React from 'react' //rafcetabtab

import {FaTimes} from 'react-icons/fa'

//const ringText = ring.bellRingTime

const Ring = ({ring, onDelete}) => {
    return (
        <div className={`task ${ring.normal? 'reminder':''}`}>
            <h3>
                {ring.bellRingTime}   {ring.description}
                <FaTimes style={{color: 'red', cursor: 'pointer'}} onClick={() => onDelete(ring.id)}/>
            </h3>
            <p>{ring.text}</p>
        </div>
    )
}

export default Ring