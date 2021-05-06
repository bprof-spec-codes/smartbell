import React, {useState, useEffect} from 'react';

import axios from '../../axios';
import Ring from './Ring';

//hozzáadásnál: elnevezni, kezdeti idő, vége idő, legördülőből mp3at választani,
//normál csengetés nem kell
//órai csengetés
    //ennél nevet adhatsz, időpontokat adunk (kezdő, vége) opt. hány másodpercig tartson a csengetés, hangot legördülőből 
// speciális csengetés beszúrás
    //ugyanezeket + választhatunk txtt a legördőlőből, az interval megadja a hosszát, nincs végdátum
//max egy óra lehet két csengetés közt

const Rings = ({rings, onDelete, onToggle, date}) => {
    const [ringsFromBackend, setRingsFromBackend]=useState([]);
    const [ringsToBe, setRingsToBe]=useState([]);

    useEffect(()=>{renderrings()}, [ringsFromBackend])

    const dateFormatter = (date) => {
        let month = '' + (date.getMonth() + 1);
        let day = '' + date.getDate();
        let year = date.getFullYear();

        if (month.length < 2) 
            month = '0' + month;
        if (day.length < 2) 
            day = '0' + day;

        return [year, month, day].join('-');
    }

    const renderrings = () => {
        const allrings = ringsFromBackend>0 ? 
            ringsFromBackend.map((ring)=>(
                <Ring
                    key={ring.id} 
                    ring={ring} 
                    onDelete={onDelete}
                    onToggle={onToggle}
                />
            )) : <p>Ezen a napon nincs egy csengetés sem.</p>
            return allrings;
    }

    axios.get(`/Client/GetBellRingsForDay/${dateFormatter(date)}`)
    .then((response) => {
        const res = response.data;
        setRingsFromBackend(res);
    })
    .catch((error)=>{
        console.log(error);
    })
    return (
        <div className='container'>
            {ringsFromBackend>0 ? 
            ringsFromBackend.map((ring)=>(
                <Ring
                    key={ring.id} 
                    ring={ring} 
                    onDelete={onDelete}
                    onToggle={onToggle}
                />
            )) : <p>Ezen a napon nincs egy csengetés sem.</p> }
        </div>
    )
}

export default Rings
