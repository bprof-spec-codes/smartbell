import React from "react";

import Button from '../../components/Button/Button';

//rafce -->tabtab
const Header = () => {
    const onClicked = () => {
        console.log('Clicked.')
    }

    return (
        <header className='header'>
            <h1>Kiválasztott nap</h1>
            <Button onClick={onClicked} color='green' text='Új csengetés hozzáadása'/>
        </header>
    )
}

export default Header