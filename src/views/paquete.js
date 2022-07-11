import React from "react"
import { Link } from "react-router-dom";
import { useStore } from "../store/StoreProvider";
import './styles.css';

export default function Paquete(props) {
    const {user, isLogged} = useStore();
    //aca tenemos que chequear si el usuario es un admin para renderizarle el boton editar
    return (
       
        <div className="col-lg-4" id="paquete1">
                        
            <div className="movie-item-style-2">
            <br/>
                <div className="cuadro-imagen">
                <img src={require("../assets/images/mv1.jpg")} alt=""/>
                {/* <img className="paquete-imagen" src={props.img} alt=""/> */}
                </div>
                <br/>
                    <div className="mv-item-infor">
                        <h6><a href="moviesingle.html" className="paquete-titulo">{props.name}</a></h6>
                        <br/>
                        <p>Descripcion: {props.description} </p> <br/>
                        <p className="rate"><i className="ion-android-star"></i><span>Precio:</span> ${props.packagePrice}</p>
                        
                        {<p className="run-time"> Avion: {props.packageServices} </p>}
                                           
                        
                        <br/>
                        <li className="main-button paquete-boton">
                            <Link to={isLogged? `/carroform/${props.id}`: "/login"}>COMPRAR</Link>
                        </li>
                        <br/>
                        {/* {user.Role==="Admin"?<li className="main-button paquete-boton">
                            <a href="/editarpaquetes">EDITAR</a>
                        </li>:<li className="main-button paquete-boton">
                            <a href="/carroform">COMPRAR</a>
                        </li>} */}
                        
                        <br/>
                    
                                   
                    </div>
            </div>
        
        </div>
    )}


    