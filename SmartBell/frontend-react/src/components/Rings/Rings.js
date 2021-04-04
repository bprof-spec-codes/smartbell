import React from 'react'

import Ring from './Ring'

//hozzáadásnál: elnevezni, kezdeti idő, vége idő, legördülőből mp3at választani,
//normál csengetés nem kell
//órai csengetés
    //ennél nevet adhatsz, időpontokat adunk (kezdő, vége) opt. hány másodpercig tartson a csengetés, hangot legördülőből 
// speciális csengetés beszúrás
    //ugyanezeket + választhatunk txtt a legördőlőből, az interval megadja a hosszát, nincs végdátum
//max egy óra lehet két csengetés közt

const Rings = ({rings, onDelete, onToggle}) => {

    return (
        <div className='container'>
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
