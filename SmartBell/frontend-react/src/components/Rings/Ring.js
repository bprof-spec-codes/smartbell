import React from 'react' //rafcetabtab

import {FaTimes} from 'react-icons/fa'


const Ring = ({ring, onDelete}) => {
    const ringText = ring.bellRingTime.split("T")[1].split(":");
    /*const [type, setType]=useState('Kezdet: ');

    switch(ring.type) {
        case '1':
            setType('Vég');
          break;
        case '2':
            setType('Vég');
          break;
        default:
          // code block
    }*/

    return (
        <div className={`task ${ring.normal? 'reminder':''}`}>
            <h3>
                {ringText[0]+':'+ringText[1]}   {ring.description}  
                <FaTimes style={{color: 'red', cursor: 'pointer'}} onClick={() => onDelete(ring.id)}/>
            </h3>
            <p>{ring.text}</p>
        </div>
    )
}

export default Ring