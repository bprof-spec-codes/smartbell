import React from 'react';

import classes from './components/SchoolDay/SchoolDay.css'

const lesson = (props) => {
    let block = null;

    switch(props.type){
        case('normal'):
            block = <div className={classes.LessonSheet}></div>;
            break;
        case('break'):
            block = <div className={classes.BreakSheet}></div>;
            break;
    }
};

export default lesson;