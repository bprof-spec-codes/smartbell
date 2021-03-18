import React from 'react'

import Ring from './Ring'

const Rings = ({rings, onDelete}) => {

    return (
        <div>
            {rings.map((ring)=>(
                <Ring key={ring.id} ring={ring} onDelete={onDelete}/>
            ))}
        </div>
    )
}

export default Rings
