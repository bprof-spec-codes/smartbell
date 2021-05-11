import React from 'react'
import {useState} from 'react'
import Ttss from '../TTS/Ttss'

const TtsMaker = () => {

    const [fileName, setFileName]=useState('');

    const [ttss, setTtss] = useState([
        {
            id:1,
            name: 'Reggeli köszöntő',
            text: 'Jó reggelt kívánok minden kedves diáknak. Legyen szép napjuk!',
            used: false
        },
        {
            id:2,
            name: 'Fontos bejelentés',
            text: 'Fontos bejelentés! Kérem mindenki figyeljen ide! Ma az alábbi dolgok fognak történni:',
            used: false
        },
        {
            id:3,
            name: 'Tűzriadó',
            text: 'RIADÓ RIADÓ RIADÓ RIADÓ RIADÓ',
            used: false
        },
        {
            id:4,
            name: 'Probléma',
            text: 'A tanítás technikai okokból véget ért! Kérem mindenki menjen haza!',
            used: false
        }
    ])

    const deleteTts = (id) =>{
        setTtss(ttss.filter((ttss) => ttss.id!==id))
    }

    return (
        <div className='container'>
            <h1>Felolvasandó szövegek</h1>
            <form className='form-control'>
                <h3>Új szöveg:</h3>
                    <input  
                        placeholder='Gépeld be a felolvasandó szöveget' 
                    />
                <h3>Fájlnév:</h3>
                <input placeholder='Adj nevet a fájlnak' type='text' onChange={e => setFileName(e.target.value)}/><br/>
                <input type='submit' className='btn btn-block' value='Szöveg hozzáadása'/>

            <br/><br/>
            <h3>Felolvasható szövegek: </h3><br/>
            {
              ttss.length > 0 ? 
              (
                <Ttss 
                  ttss={ttss} 
                  onDelete={deleteTts}
                />
              ) 
              : 
              (
                'Nincsenek felolvasandó szövegek'
              )
            }
            
            <input type='submit' className='btn btn-block' value='Szövegek mentése'/>
            </form>
        </div>
    )
}

const onSubmit = (e)=>{
    e.preventDefault()
}

export default TtsMaker
