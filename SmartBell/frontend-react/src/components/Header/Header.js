import React from "react";

import Button from '../../components/Button/Button';

//rafce -->tabtab
const Header = ({title, onAdd, showAdd}) => {

    return (
        <header className='header'>
            <h1>{title} Kiválasztott nap</h1>
            <Button 
                onClicked={onAdd} 
                color={showAdd? 'red' : 'green'} 
                text={showAdd ? 'Bezárás' : 'Új csengetés hozzáadása'}
            />
        </header>
    )
}

export default Header