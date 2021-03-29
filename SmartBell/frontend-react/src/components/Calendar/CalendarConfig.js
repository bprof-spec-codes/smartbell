import React from 'react'
import DateChooser from '../Calendar/DateChooser'

const CalendarConfig = () => {
    return (
        <div>
            <div>           
                <DateChooser/>
            </div>
            <div className='calcontainer'>
                <br />
                <a className='headerlink' href='/'> Naptár</a>
            </div>      
        </div>
    )
}

export default CalendarConfig
