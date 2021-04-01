import React from 'react'
import DDMenu from '../Button/DDMenu'

//rádióműsorokat egytől indexelni

const RadioMaker = () => {
    return (
        <div className='container'>
            <h1>Rádióműsor-összeállító</h1><br/>
            <h3>Eddigi rádióműsorjaid: </h3><br/>
            <DDMenu/>
            <h3>Kiválaszott rádióműsor:</h3>
            <p>Zeneszámok: - to be implemented</p>
            <p>Zeneszámok hozzáadása, eltávolítása: - to be implemented</p><br/>
            <h3>Új műsor:</h3>
            <form className='form-control'>
                <label>Rádióműsor neve</label>
                    <input  
                        placeholder='Adj nevet a rádióműsorodnak' 
                    />
            <input type='submit' className='btn btn-block' value='Új rádióműsor hozzáadása'/>
            <input type='submit' className='btn btn-block' value='Rádióműsorok mentése'/>
            </form>
            
        </div>
    )
}

export default RadioMaker
