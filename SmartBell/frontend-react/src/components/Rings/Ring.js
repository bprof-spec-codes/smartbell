import React from 'react' //rafcetabtab

import {FaTimes} from 'react-icons/fa'

const Ring = ({ring, onDelete, onToggle}) => {
    return (
        <div className={`task ${ring.normal? 'reminder':''}`} onDoubleClick={()=>onToggle(ring.id)}>
            <h3>
                {ring.description};
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