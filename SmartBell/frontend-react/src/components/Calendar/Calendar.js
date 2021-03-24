import React, {useState} from 'react';

import rCalendar from 'react-calendar';

const Calendar = () => {
    const [date,setDate] = useState(new Date());
    const onChange=date=>{
        setDate(date);
    };
    

    return (
        <div>
            <rCalendar onChange={onChange} value={date}/>
        </div>
    )
}



export default rCalendar
