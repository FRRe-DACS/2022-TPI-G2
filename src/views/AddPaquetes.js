import React from "react";
import Paquete from "./paquete";
import paquetesApi from "../paquetes.json";
import PostForm from "./PostForm";
import Header from "../components/header";

function AddPaquetes() {
  let paquete = paquetesApi;

  return (
    <div className="CatalogoPaquetes">
      <Header />
      <br />
      <br />

      {/* <!-- ***** no navbar ***** --> */}
      <section className="section" id="trainers">
        <div className="container">
          {/* <!-- ***** TITULO ***** --> */}
          <div className="row">
            <div className="col-lg-6 offset-lg-3">
              <div className="section-heading">
                <h2>
                  AÑADIR PAQUETES DE <em>VIAJE</em>
                </h2>
                <img
                  src={require("../assets/images/line-dec.png").default}
                  alt=""
                />
                <p>
                  Por favor completar todos los campos, compruebe que la url de
                  la imagen sea pública
                </p>
              </div>
            </div>
          </div>

          <div className="row" id="listado de paquetes">
            <div className="col-lg-8" id="paquete1">
              <div className="movie-item-style-2">
                <br />

                <br />
                <div className="mv-item-infor">
                  <br />

                  <PostForm />

                  <br />
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
}

export default AddPaquetes;
