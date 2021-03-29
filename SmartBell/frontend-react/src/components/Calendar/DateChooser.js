import React from 'react'

//help: https://codesandbox.io/s/react-google-flight-datepicker-zultp?file=/src/App.js:637-643
//also: https://github.com/JSLancerTeam/react-google-flight-datepicker
import {
    RangeDatePicker,
    SingleDatePicker
} from "react-google-flight-datepicker";
import "react-google-flight-datepicker/dist/main.css";
import DDMenu from '../Button/DDMenu';

const DateChooser = () => {
    return (
        <div className='dpcontainer'>
            <h1>Csengetési rend gyorsbeállító</h1><br/>
            <p>Mettől meddig tartson a csengetési rend?</p><br/>
            <RangeDatePicker
                startDate={new Date()}
                endDate={new Date()}
            /><br/>
            <p>Válassz csengetési rendet:</p><br/>
            <DDMenu/>
        </div>
    )
}

export default DateChooser
