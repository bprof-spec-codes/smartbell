import React from 'react'

//help: https://codesandbox.io/s/react-google-flight-datepicker-zultp?file=/src/App.js:637-643
//also: https://github.com/JSLancerTeam/react-google-flight-datepicker
import {
    RangeDatePicker,
    SingleDatePicker
} from "react-google-flight-datepicker";
import "react-google-flight-datepicker/dist/main.css";

const DateChooser = () => {
    return (
        <div className='dpcontainer'>
            <RangeDatePicker
                startDate={new Date()}
                endDate={new Date()}
            />
        </div>
    )
}

export default DateChooser
