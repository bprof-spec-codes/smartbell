import React, { useState } from "react";
import Rings from "../Rings/Rings";

function TimeTable({ date }) {
  const [rings, setRings] = useState([]);

  //add ring
  const addRing = (ring) => {
    //console.log(ring);
    const id = Math.floor(Math.random() * 10000) + 1;
    const newRing = { id, ...ring };
    newRing.text = "Szünet";
    setRings([...rings, newRing]); //hozzáadjuk a már meglévő tömhöz
  };

  //delete ring
  const deleteRing = (id) => {
    //console.log('delete', id)
    setRings(rings.filter((ring) => ring.id !== id));
  };
  //toggle reminder
  const toggleReminder = (id) => {
    setRings(
      rings.map((ring) =>
        ring.id === id ? { ...ring, normal: !ring.normal } : ring
      )
    );
  };

  return (
    <div className="timetable">
        <Rings rings={rings} onDelete={deleteRing} onToggle={toggleReminder} date={date}/>
    </div>
  );
}

export default TimeTable;
