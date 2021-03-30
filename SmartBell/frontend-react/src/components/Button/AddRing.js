import React from 'react'
import {useState} from 'react'

import UploadFile from '../Button/UploadFile'
import DDMenu from './DDMenu';

const AddRing = ({onAdd}) => {
    const [text, setText]=useState('');
    const [time,setTime]=useState('');
    const [normal,setNormal]=useState(false);
    const [toRead, settoRead]=useState('');

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
            <div>
                <label>Szünet fajtája </label>
                <DDMenu/>
            </div>
            <UploadFile/>        
            <div className='form-control'>
                <label>Csengetés</label>
                <input 
                    type='text' 
                    placeholder='Adj címet a csengetésnek' 
                    value={text}
                    onChange={(e)=>setText(e.target.value)}
                />
            </div>
            <div className='form-control'>
                <label>Időpont</label>
                <input 
                    type='text' 
                    placeholder='Add meg a csengetés kezdetét' 
                    value={time}
                    onChange={(e)=>setTime(e.target.value)}
                />
            </div>
            <div className='form-control form-control-check'>
                <label>Normál csengetés?</label>
                <input
                    type='checkbox' 
                    checked={normal}
                    value={normal}
                    onChange={(e)=>setNormal(e.currentTarget.checked)}
                 />
            </div>
            <div className='form-control'>
                <label>Felolvasás</label>
                <input 
                    type='text' 
                    placeholder='Add meg a hangosan beolvasandó szöveget' 
                    value={toRead}
                    onChange={(e)=>settoRead(e.target.value)}
                />
            </div>

            <input type='submit' className='btn btn-block' value='Csengetés hozzáadása'/>
        </form>
    )
}

export default AddRing
