import React from 'react'
import {useState} from 'react'

import UploadFile from '../Button/UploadFile'
import DDMenu from './DDMenu';
import TPicker from '../Calendar/TPicker'
import '../../index.css'

const AddRing = ({onAdd}) => {
    const [text, setText]=useState('');
    const [time,setTime]=useState('');
    const [normal,setNormal]=useState(false);
    const [toRead, settoRead]=useState('');

    const ringOptions = ['Normál', 'Csengetések némítása','Iskolarádió','Beolvasás'];
    const ringOption = ringOptions[0];
    const radioOptions = ['Alap rádióműsor', 'műsor2', 'műsor3'];
    const radioOption = radioOptions[0];
    const ttrOptions = ['Alap szöveg', 'ünnepi szöveg', 'covid tájékoztató'];
    const ttrOption = ttrOptions[0];

    
    const onSubmit = (e)=>{
        e.preventDefault()

        /*if(!text){
            alert('Kérlek nevezd el a csengetést')
            return
        }*/

        onAdd({text, time, normal})
        setText('')
        setTime('')
        setNormal(false)
        settoRead('')
    }

    return (
        <form className='container' onSubmit={onSubmit}>
            <div className='form-control'>
                <label>Szünet típusa </label>
                <DDMenu props={ringOptions} first={ringOption} />
            </div>
            
            <div className='form-control'>
                <label>Szünet kezdete</label>
                <TPicker/>
            </div>
            <div className='form-control'>
                <label>Szünet vége</label>
                <TPicker/>
            </div>
            <div className='form-control'>
                <p>Add meg a csengetések hosszát másodpercben:</p><br/>
                <input placeholder='automatikus'/><br/>
            </div>
            <div className='form-control'>
                <label>Válassz rádióműsort</label>
                <DDMenu props={radioOptions} first={radioOptions[0]} />
            </div>
            <div className='form-control'>
                <label>Válassz felolvasandó szöveget</label>
                <DDMenu props={ttrOptions} first={ttrOptions[0]} />
            </div>

            <input type='submit' className='btn btn-block' value='Csengetés hozzáadása'/>
        </form>
    )
}

export default AddRing
