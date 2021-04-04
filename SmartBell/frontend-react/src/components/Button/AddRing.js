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
    const ringOptions = ['Normál', 'Ünnepnap','Iskolarádió','Beolvasás'];
    const ringOption = ringOptions[0];

    
    const onSubmit = (e)=>{
        e.preventDefault()

        if(!text){
            alert('Kérlek nevezd el a csengetést')
            return
        }

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
                <label>Válassz rádióműsort</label>
                <DDMenu props={ringOptions} first={ringOptions[0]} />
            </div>
            <div className='form-control'>
                <label>Válassz felolvasandó szöveget</label>
                <DDMenu props={ringOptions} first={ringOptions[0]} />
            </div>

            <input type='submit' className='btn btn-block' value='Csengetés hozzáadása'/>
        </form>
    )
}

export default AddRing
