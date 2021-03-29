import React from 'react'
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';

const DDMenu = () => {
    const options = [
        'Alapértelmezett', 'Rövidített', 'Nornál', 'Ünnepnap','Vészcsengő','Iskolarádió','Beolvasás'
      ];
      const defaultOption = options[0];

    return (
        <div>
            <Dropdown options={options} onChange={this._onSelect} value={defaultOption} placeholder="Válassz a módok közül" />
            <br/>
        </div>
    )
}


export default DDMenu
