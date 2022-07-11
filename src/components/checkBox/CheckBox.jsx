import React from 'react';
import "./Checkbox.css";

const CheckBox = ({title, value}) => {
    return(
        <div className='gv-checkbox-container'>
            <label className='gv-checkbox-label'>
                <input type="checkbox" className='gv-checkbox-input' value={value}/>
                <span className='gv-checkbox-span'></span>
            </label>
            <p>{title}</p>
        </div>
    )
}

export default CheckBox;