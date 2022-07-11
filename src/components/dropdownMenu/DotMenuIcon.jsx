import React from 'react';
import "./DropdownMenu.css";

const DotMenuIcon = ({handleOpen}) => {
    return (
        <div className='gv-dotmenuicon-container' onClick={handleOpen}>
            <ul className="gv-dots">
                <li></li>
                <li></li>
                <li></li>
            </ul>
        </div>
    )
}

export default DotMenuIcon;