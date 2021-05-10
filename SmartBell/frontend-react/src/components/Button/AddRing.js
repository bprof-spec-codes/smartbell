import React from 'react'
import {useState, useEffect} from 'react'
import moment from 'moment';
import TimePicker from 'rc-time-picker';
import 'rc-time-picker/assets/index.css';
import DDMenu from './DDMenu';
import TPicker from '../Calendar/TPicker'
import axios from "../../axios";
import '../../index.css'

const AddRing = () => {
    const ringOptions = ['Normál', 'Csengetések némítása','Iskolarádió','Speciális csengetés'];
    const radioOptions = ['Alap rádióműsor', 'műsor2', 'műsor3'];
    const ttrOptions = ['Alap szöveg', 'ünnepi szöveg', 'covid tájékoztató'];

    const [ringType, setRingType]=useState(ringOptions[0]);

    const [startTime,setStartTime] = useState('12:00');
    const [endTime,setEndTime] = useState('12:00');
    const [description, setDescription] = useState('');
    const [length, setLength] = useState(0);
    const file = 'emptyFile'

    const [files,setFiles] = useState([]);

    
    function onStartChange(value) {
        setStartTime(value);
        console.log(value);
    }

    function onEndChange(value) {
        setEndTime(value);
        console.log(value);
    }

    useEffect(() => {
        axios
          .get(`/File/GetAllFiles/`)
          .then((response) => {
            const res = response.data;
            setFiles(res);
            console.log(res);
          })
          .catch((error) => {
            console.log(error);
          });
      }, [ringType]);


     //add ring
    const addRing = () =>{
        
        console.log(startTime);
        console.log(endTime);
        console.log(description);

        const data = {}


        /*axios.post(`/${(ringType==='Normál' && 'Bellring/InsertLessonBellrings') ||
         (ringType==='Csengetések némítása' && 'Holiday/InsertLessonBellrings') ||
         (ringType==='Iskolarádió' && 'Bellring/AssignTimeToSequencedBellRing') ||
         (ringType==='Beolvasás' && 'Bellring/InsertSpecialBellring')}`,)
         axios.post(`Bellring/InsertLessonBellrings`,
         {
            startBellRing:{description:description,bellRingTime:startTime,interval:length},
            endBellRing:{description:description,bellRingTime:endTime,interval:length},
            startFileName:file,

        });*/
         

    }

    useEffect(() => {
        console.log(ringType)
    }, [ringType])
    
    const onSubmit = (e)=>{
        e.preventDefault()
        addRing();
    }

    return (
        <form className='container' onSubmit={onSubmit}>
            <div className='form-control'>
                <label>Szünet típusa </label>
                <select onChange={(e)=> setRingType(e.target.value)}>
                    <option value={ringOptions[0]}>
                        Normál
                    </option>
                    <option value={ringOptions[1]}>
                        Csengetések némítása
                    </option>
                    <option value={ringOptions[2]}>
                        Iskolarádió
                    </option>
                    <option value={ringOptions[3]}>
                        Speciális csengetés
                    </option>
                </select>
            </div>

            <div className='form-control'>
                <label>Szünet kezdete</label>
                <TPicker onChange={onStartChange}/>
            </div>

            {
                ringType=='Csengetések némítása' && 
                <div>
                    <div className='form-control'>
                        <label>Szünet vége</label>
                        <TPicker onChange={onEndChange}/>
                    </div>
                </div>
            }
            {
                ringType=='Normál' && 
                <div>
                    <div className='form-control'>
                        <label>Szünet vége</label>
                        <TPicker onChange={onEndChange}/>
                    </div>
                    <div className='form-control'>
                        <p>Csengetés leírása:</p><br/>
                        <input placeholder='alapértelmezett' type='text' onChange={e => setDescription(e.target.value)}/><br/>
                    </div>
                    <div className='form-control'>
                        <p>Add meg a csengetések hosszát másodpercben:</p><br/>
                        <input placeholder='automatikus' type='number' onChange={e => setLength(e.target.value)}/><br/>
                    </div>
                </div>
            }
            {
                ringType=='Iskolarádió' && 
                <div>
                    <div className='form-control'>
                        <p>Csengetés leírása:</p><br/>
                        <input placeholder='alapértelmezett' type='text' onChange={e => setDescription(e.target.value)}/><br/>
                    </div>
                    <div className='form-control'>
                        <label>Válassz rádióműsort</label>
                        <DDMenu props={radioOptions} first={radioOptions[0]} />
                    </div>
                </div>
            }
            {
                ringType=='Speciális csengetés' && 
                <div>
                    <div className='form-control'>
                        <p>Csengetés leírása:</p><br/>
                        <input placeholder='alapértelmezett' type='text' onChange={e => setDescription(e.target.value)}/><br/>
                    </div>
                    <div className='form-control'>
                        <label>Válassz lejátszandó fájlt</label>
                        <DDMenu props={files} first={files[0]} />
                    </div>
                </div>
            }
            
            <input type='submit' className='btn btn-block' value='Csengetés hozzáadása'/>
        </form>
    )
}

export default AddRing
