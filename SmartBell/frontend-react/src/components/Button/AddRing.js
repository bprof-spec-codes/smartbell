import React from 'react'
import {useState, useEffect} from 'react'

import DDMenu from './DDMenu';
import TPicker from '../Calendar/TPicker'
import '../../index.css'

const AddRing = () => {
    const ringOptions = ['Normál', 'Csengetések némítása','Iskolarádió','Beolvasás'];
    const [ringType, setRingType]=useState(ringOptions[0]);


    const radioOptions = ['Alap rádióműsor', 'műsor2', 'műsor3'];
    const ttrOptions = ['Alap szöveg', 'ünnepi szöveg', 'covid tájékoztató'];

     //add ring
    const addRing = (ring) =>{
        const id=Math.floor(Math.random()*10000)+1
        const newRing = {id, ...ring
    }


        /*const data = {}


        axios.post(`/${(ringType==='Normál' && 'Bellring/InsertLessonBellrings') ||
         (ringType==='Csengetések némítása' && 'Holiday/InsertLessonBellrings') ||
         (ringType==='Iskolarádió' && 'Bellring/AssignTimeToSequencedBellRing') ||
         (ringType==='Beolvasás' && 'Bellring/InsertSpecialBellring')}`,)
         
        */

    }

    useEffect(() => {
        console.log(ringType)
    }, [ringType])
    
    const onSubmit = (e)=>{
        e.preventDefault()
    }

    return (
        <form className='container' onSubmit={onSubmit}>
            <div className='form-control'>
                <label>Szünet típusa </label>
                <select onChange={(e)=> setRingType(e.target.value)}>
                    <option value={ringOptions[0]}>
                        Normál
                    </option>
                    <option value={ringOptions[1]}>
                        Csengetések némítása
                    </option>
                    <option value={ringOptions[2]}>
                        Iskolarádió
                    </option>
                    <option value={ringOptions[3]}>
                        Beolvasás
                    </option>
                </select>
            </div>
            

            <div className='form-control'>
                <label>Szünet kezdete</label>
                <TPicker/>
            </div>

            {
                ringType!='Csengetések némítása' && 
                <div>
                    <div className='form-control'>
                        <p>Csengetés leírása:</p><br/>
                        <input placeholder='alapértelmezett'/><br/>
                    </div>
                </div>
            }
            {
                ringType=='Csengetések némítása' && 
                <div>
                    <div className='form-control'>
                        <label>Szünet vége</label>
                        <TPicker/>
                    </div>
                </div>
            }
            {
                ringType=='Normál' && 
                <div>
                    <div className='form-control'>
                        <label>Szünet vége</label>
                        <TPicker/>
                    </div>
                    <div className='form-control'>
                        <p>Add meg a csengetések hosszát másodpercben:</p><br/>
                        <input placeholder='automatikus'/><br/>
                    </div>
                </div>
            }
            {
                ringType=='Iskolarádió' && 
                <div>
                    <div className='form-control'>
                        <label>Válassz rádióműsort</label>
                        <DDMenu props={radioOptions} first={radioOptions[0]} />
                    </div>
                </div>
            }
            {
                ringType=='Beolvasás' && 
                <div>
                    <div className='form-control'>
                        <label>Válassz felolvasandó szöveget</label>
                        <DDMenu props={ttrOptions} first={ttrOptions[0]} />
                    </div>
                </div>
            }
            
            <input type='submit' className='btn btn-block' value='Csengetés hozzáadása'/>
        </form>
    )
}

export default AddRing
