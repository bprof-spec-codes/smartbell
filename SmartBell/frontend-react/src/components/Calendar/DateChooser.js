import React from 'react'
import {useState} from 'react'

//help: https://codesandbox.io/s/react-google-flight-datepicker-zultp?file=/src/App.js:637-643
//also: https://github.com/JSLancerTeam/react-google-flight-datepicker
import {RangeDatePicker, SingleDatePicker} from "react-google-flight-datepicker";
import "react-google-flight-datepicker/dist/main.css";
import DDMenu from '../Button/DDMenu';


const DateChooser = ({onAdd}) => {
    const [startDate, setStartDate]=useState(new Date());
    const [endDate, setEndDate]=useState(new Date());
    const [template,setTemplate]=useState('');
    const [sound,setSound]=useState('');
    const [radio, setRadio]=useState('');
    
    const onSubmit = (e)=>{
        e.preventDefault()
    
        if(startDate==endDate){
            alert('Kérlek add meg a kívánt időtartamot')
            return
        }
    
        onAdd({startDate, endDate, template, sound, radio})
        setStartDate(new Date())
        setEndDate(new Date())
        setTemplate('Alapértelmezett')
        setSound('Alapértelmezett')
        setRadio('Alapértelmezett')
    }

    return (
        <form className='dpcontainer'>
            <h1>Csengetési rend gyorsbeállító</h1><br/>
            <p>Mettől meddig tartson a csengetési rend?</p><br/>
            <RangeDatePicker
                startDate={new Date()}
                endDate={new Date()}
            /><br/>
            <p>Válassz csengetési rendet:</p><br/>
            <DDMenu/>

            <input type='submit' className='btn btn-block' value='Csengetési rend hozzáadása'/>
        </form>
    )
}

export default DateChooser
