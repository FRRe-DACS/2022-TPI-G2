import React, { useRef, useEffect } from 'react';
import DropdownItem from './DropdownItem';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircleUser, faCircleXmark, faHouseChimney, faBookmark } from "@fortawesome/free-solid-svg-icons";
import "./DropdownMenu.css";
import { useStore } from '../../store/StoreProvider';

const DropdownMenu = ({ handleOpen, menuOptions, closeSession }) => {
    const refOne = useRef(null)
    const {user} = useStore();

    const hiddenOnClickOutside = (e) => {
        if (refOne.current && !refOne.current.contains(e.target)) {
            handleOpen();
        }
    }

    useEffect(() => {
        document.addEventListener("click", hiddenOnClickOutside, true)
    }, []);

    return (
        <div className='gv-dropdownMenu-container' ref={refOne}>
            <DropdownItem path={"/"} handleOpen={handleOpen} leftIcon={<FontAwesomeIcon icon={faCircleUser} />} >
                <p>Mi cuenta</p>
            </DropdownItem>
            {user.rol === "Admin" && <DropdownItem path={"/AddPaquetes"} handleOpen={handleOpen} leftIcon={<FontAwesomeIcon icon={faCircleUser} />} >
                <p>Crear Paquetes</p>
            </DropdownItem>}
            {user.rol === "Admin" && <DropdownItem path={"/EditarPaquetes"} handleOpen={handleOpen} leftIcon={<FontAwesomeIcon icon={faCircleUser} />} >
                <p>Editar Paquetes</p>
            </DropdownItem>}
            <DropdownItem closeSession={closeSession} path={"/"} handleOpen={handleOpen} leftIcon={<FontAwesomeIcon icon={faCircleXmark} />}>
                <p>Cerrar Sesión</p>
            </DropdownItem>
        </div>
    )
}

export default DropdownMenu;