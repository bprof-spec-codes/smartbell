import React, {Component} from 'react';
import Aux from '../../hoc/Auxillary';

class TimeTable extends Component{
    render(){
        return (
            <Aux>
                <div>Days</div>
                <div>Ring-Pattern Controls</div>
                <div>Music Controls</div>
            </Aux>
        );
    }
}

export default TimeTable;