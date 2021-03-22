import React from 'react'

import Ring from './Ring'

const Rings = ({rings, onDelete, onToggle}) => {

    return (
        <div>
            {rings.map((ring)=>(
                <Ring 
                    key={ring.id} 
                    ring={ring} 
                    onDelete={onDelete}
                    onToggle={onToggle}
                />
            ))}
        </div>
    )
}

export default Rings
