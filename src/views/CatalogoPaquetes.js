import React, { useEffect, useState } from "react";
import Paquete from "./paquete";
import {getPaquetes} from "../service/paquetes.service"
import Header from "../components/header";
import {useStore} from "../store/StoreProvider"


function CatalogoPaquetes() {
  const [ paquetes ,setPaquetes]= useState([])
  const {user, isLogged} = useStore();

  useEffect(()=>{
    getPaquetes().then((res) => {
      console.log(res)
      setPaquetes(res);
      return res
    }).catch((err) => {
      console.log(err);
    })
  },[])



  return (
    <div className="CatalogoPaquetes">
       <Header />
      <br/><br/>
      {/* <!-- ***** no navbar ***** --> */}
      <section className="section" id="trainers">
        <div className="container">
          {/* <!-- ***** TITULO ***** --> */}
          <div className="row">
            <div className="col-lg-6 offset-lg-3">
              <div className="section-heading">
                <h2>
                  Paquetes de <em>Viaje</em>
                </h2>
                <img src={require("../assets/images/line-dec.png").default} alt="" />
                <p>
                  Ofrecemos los mejores paquetes de viajes para que no tengas
                  que preocuparte de nada.
                </p>
              </div>
            </div>
          </div>

          <div className="row" id="listado de paquetes">

            {paquetes && paquetes.map(paquete =>
              <Paquete
                id={paquete.id}
                name={paquete.name}
                packagePrice={paquete.packagePrice}
                
                
                description={paquete.description}
                packageServices={paquete.packageServices[0].service.description}

                /*paquete.packageServices && paquete.packageServices.map(servicio => {
                  return(
                    <div>
                    {servicio.description}
                    </div>
                  )
                }) */
                //img={paquete.img} 
                />
            )}

          </div>

          <br />



          {user.rol === "Admin" && <li className="main-button paquete-boton">
            <a href="/AddPaquetes">+ AÑADIR PAQUETE</a>
          </li>}

          <br />


        </div>


      </section>

      <footer>
        <div className="container">
          <div className="row">
            <div className="col-lg-12">
              <p>Copyright &copy; 2022

                - Designed by Grupo N°2 Cliente Servidor - UTN</p>

            </div>
          </div>
        </div>
      </footer>


    </div>
    
  );
}

export default CatalogoPaquetes;
