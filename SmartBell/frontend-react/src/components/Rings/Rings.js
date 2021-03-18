import React from 'react'



const Rings = (props) => {


    return (
        <div>
            {props.rings.map((ring)=>(
                <h3 key={ring.id}>{ring.text} - {ring.time}</h3>
            ))}
        </div>
    )
}

export default Rings
