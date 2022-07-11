import React from "react";
import {Link} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import '../assets/css/templatemo-training-studio.css';

import Video from '../assets/images/video1-2.mp4'
import Header from "../components/header/";


function Home() {
    return (
        <div className="Home">
            <html lang="en">

                <head>

                    <meta charset="utf-8" />
                    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
                    <meta name="description" content="" />
                    <meta name="author" content="" />
                    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&display=swap" rel="stylesheet" />

                    <title>Training Studio - Free CSS Template</title>

                    <link rel="stylesheet" type="text/css" href="../assets/css/bootstrap.min.css" />

                    <link rel="stylesheet" type="text/css" href="../assets/css/font-awesome.css" />

                    <link rel="stylesheet" href="../assets/css/templatemo-training-studio.css" />

                </head>

                <body>


                    <Header />


                    {/* <!-- ***** Main Banner Area Start ***** --> */}
                    <div className="main-banner" id="top">




                        <video autoPlay muted loop id="bg-video">
                            <source src={Video} type='video/mp4' />
                        </video>




                        <div className="video-overlay header-text">
                            <div className="caption">
                                <h6>Copa Mundial de la FIFA Catar 2022</h6>
                                <h2>Donde vivirás el <em>Fútbol</em></h2>
                                <div className="main-button scroll-to-section">
                                    <a href="#features">Nuestros Servicios</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    {/* <!-- ***** Main Banner Area End ***** --> */}

                    {/* <!-- ***** SERVICIOS ESTRELLAS ***** --> */}
                    <section className="section" id="features">
                        <div className="container">
                            <div className="row">
                                <div className="col-lg-6 offset-lg-3">
                                    <div className="section-heading">
                                        <h2>Servicios <em>Estrellas</em></h2>
                                        <img src={require("../assets/images/line-dec.png")} alt="waves" />
                                        <p>items especiales que ofrecemos a nuestros clientes especiales</p>
                                    </div>
                                </div>
                                <div className="col-lg-6">
                                    <ul className="features-items">
                                        <li className="feature-item">
                                            <div className="left-icon">
                                                <img src={require("../assets/images/features-first-icon.png")} alt="First One" />
                                            </div>
                                            <div className="right-content">
                                                <h4>Hoteles de Lujos</h4>
                                                <p>Hoteles a minutos de los estadios, con todas las atenciones que un verdadero fan necesita</p>
                                                <a href="/#" className="text-button">Discover More</a>
                                            </div>
                                        </li>
                                        <li className="feature-item">
                                            <div className="left-icon">
                                                <img src={require("../assets/images/features-first-icon.png")} alt="second one" />
                                            </div>
                                            <div className="right-content">
                                                <h4>Cobertura medica COVID</h4>
                                                <p>Te tenemos cubierto en caso de que te agarre el COVID-19 con un coctel de vacunas no aprobadas</p>
                                                <a href="/#" className="text-button">Discover More</a>
                                            </div>
                                        </li>
                                        <li className="feature-item">
                                            <div className="left-icon">
                                                <img src={require("../assets/images/features-first-icon.png")} alt="third gym training" />
                                            </div>
                                            <div className="right-content">
                                                <h4>Ven con tu familia o amigos</h4>
                                                <p>Nuestro sistema web cuenta con la opcion de que adquieras el paquete para tu grupo familiar o amistades, con una sola gestion</p>
                                                <a href="/#" className="text-button">Discover More</a>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <div className="col-lg-6">
                                    <ul className="features-items">
                                        <li className="feature-item">
                                            <div className="left-icon">
                                                <img src={require("../assets/images/features-first-icon.png")} alt="fourth muscle" />
                                            </div>
                                            <div className="right-content">
                                                <h4>Entradas a los Partidos</h4>
                                                <p>Todos nuestros paquetes cuentan con la entrada para los partidos, para que no te quedes afuera de ninguno</p>
                                                <a href="/#" className="text-button">Discover More</a>
                                            </div>
                                        </li>
                                        <li className="feature-item">
                                            <div className="left-icon">
                                                <img src={require("../assets/images/features-first-icon.png")} alt="training fifth" />
                                            </div>
                                            <div className="right-content">
                                                <h4>Aviones</h4>
                                                <p>Contamos con una flota de aviones propias para que llegues a Qatar estés donde estés</p>
                                                <a href="/#" className="text-button">Discover More</a>
                                            </div>
                                        </li>
                                        <li className="feature-item">
                                            <div className="left-icon">
                                                <img src={require("../assets/images/features-first-icon.png")} alt="gym training" />
                                            </div>
                                            <div className="right-content">
                                                <h4>Micro</h4>
                                                <p>Autobuses del hotel al estadio incluido con la compra del paquete.</p>
                                                <a href="/#" className="text-button">Discover More</a>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </section>
                    {/* <!-- ***** Features Item End ***** --> */}

                    {/* <!-- ***** Call to Action Start ***** --> */}
                    <section className="section" id="call-to-action">
                        <div className="container">
                            <div className="row">
                                <div className="col-lg-10 offset-lg-1">
                                    <div className="cta-content">
                                        <h2>NO LO <em>PIENSES</em>, VIVE LA <em>EXPERIENCIA</em>!</h2>
                                        <p>El torneo mas importante de deportes a nivel Mundial, solo ocurre cada 4 años, vas a salteartelo?  .</p>
                                        <div className="main-button scroll-to-section">
                                            <a href="/CatalogoPaquetes">Ver Paquetes</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    {/* <!-- ***** Call to Action End ***** --> */}

                    {/* <!-- ***** FASES DEL MUNDIAL ***** --> */}
                    <section className="section" id="our-classes">
                        <div className="container">
                            <div className="row">
                                <div className="col-lg-6 offset-lg-3">
                                    <div className="section-heading">
                                        <h2>Las fases del<em> Mundial</em></h2>
                                        <img src={require("../assets/images/line-dec.png")} alt="" />
                                        <p>A continuacion se presentan las distintas fases del mundial de futbol de Qatar 2022.</p>
                                    </div>
                                </div>
                            </div>
                            <div className="row" id="tabs">
                                <div className="col-lg-4">
                                    <ul>
                                        <li><a href='#tabs-1'><img src={require("../assets/images/tabs-first-icon.png")} alt="" />Fases de grupos</a></li>
                                        <li><a href='#tabs-2'><img src={require("../assets/images/tabs-first-icon.png")} alt="" />Octavos de final</a></li>
                                        <li><a href='#tabs-3'><img src={require("../assets/images/tabs-first-icon.png")} alt="" />Cuartos de final</a></li>
                                        <li><a href='#tabs-4'><img src={require("../assets/images/tabs-first-icon.png")} alt="" />Semifinal</a></li>
                                        <li><a href='#tabs-5'><img src={require("../assets/images/tabs-first-icon.png")} alt="" />final</a></li>
                                        <div className="main-rounded-button"><a href="/CatalogoPaquetes">Vea nuestros Paquetes</a></div>
                                    </ul>
                                </div>
                                <div className="col-lg-8">
                                    <section className='tabs-content'>
                                        <article id='tabs-1'>
                                            <h4>Fases de grupos</h4>
                                            <p>La fase de grupos se disputa entre el 21 de noviembre y el 2 de diciembre de 2022 y en ese periodo habrá partidos todos los días. Cada día se disputarán cuatro partidos, dos de cada grupo, en cuatro horarios diferentes que permitirán ver todos los partidos.</p>
                                            
                                            <img src={require("../assets/images/training-image-01.jpg")} alt="First Class" />

                                        </article>
                                        <article id='tabs-2'>
                                            <h4>Octavos de final</h4>
                                            <p>Los octavos de final se disputarán el 3, 4, 5 y 6 de diciembre, en los que se enfrentarán los primeros de grupo con los segundos de grupo sin que sea posible que se enfrenten equipos que ya habían competido entre sí en la fase de grupos.</p>
                                            
                                            <img src={require("../assets/images/training-image-01.jpg")} alt="First Class" />

                                        </article>
                                        <article id='tabs-3'>
                                            <h4>Cuartos de final</h4>
                                            <p>Sólo 8 de los equipos participantes del Mundial de Qatar 2022 podrán estar en los cuartos de final del torneo. Los emparejamientos de los 8 grupos se sortean el día 1 de abril y determinarán los cruces de las eliminatorias de octavos de final y los 8 ganadores se enfrentarán entre sí en los cuartos de final.</p>
                                            
                                            <img src={require("../assets/images/training-image-01.jpg")} alt="First Class" />

                                        </article>
                                        <article id='tabs-4'>
                                            <h4>Semifinal</h4>
                                            <p>Sólo los 4 mejores equipos participantes del Mundial de Qatar 2022 podrán estar en las semis del torneo.</p>
                                            
                                            <img src={require("../assets/images/training-image-01.jpg")} alt="First Class" />

                                        </article>
                                        <article id='tabs-5'>
                                            <h4>Final</h4>
                                            <p>En este partido se enfrentan los 2 mejores equipos del torneo para saber quien se alzara con la tan preciada Copa del Mundo</p>
                                            
                                            <img src={require("../assets/images/training-image-01.jpg")} alt="First Class" />

                                        </article>
                                    </section>
                                </div>
                            </div>
                        </div>
                    </section>

                    {/* <!-- ***** Conocenos ***** --> */}
                    <section className="section" id="schedule">
                        <div className="container">
                            <div className="row">
                                <div className="col-lg-6 offset-lg-3 section-heading ">
                                    <h2 ><ups>Integrantes del</ups>  <em>Grupo 2</em></h2>
                                    <img src={require("../assets/images/line-dec.png")} alt="" />
                                    <p>Esta página fue realizada por los siguientes alumnos</p>
                                </div>

                               


                            </div>
                            <div className="integrantes" >

                                <div className="Integrante cuadro-imagen2">
                                    <div >
                                    <img className="integrante-foto" src={require("../assets/images/juanlucas.jpg")} alt="" />
                                    </div>
                                    <div className="down-content">

                                        <h4 className="integrante-name">Juan Lucas Biain</h4>
                                        <p>Developer</p>

                                    </div>
                                </div>
                                <div className="Integrante cuadro-imagen2">
                                    <img src={require("../assets/images/guido.jpg")} alt="" />

                                    <div className="down-content">

                                        <h4 className="integrante-name">Guido Leonardo Stangaferro</h4>
                                        <p>Developer</p>

                                    </div>
                                </div>
                                <div className="Integrante cuadro-imagen2">

                                    <img src={require("../assets/images/ricardo.jpg")} alt="" />

                                    <div className="down-content">

                                        <h4 className="integrante-name">Ricardo Villa</h4>
                                        <p>Developer</p>

                                    </div>
                                </div>
                                <div className="Integrante cuadro-imagen2">

                                    <img src={require("../assets/images/gaston.jpg")} alt="" />

                                    <div className="down-content">

                                        <h4 className="integrante-name">Gaston Vera</h4>
                                        <p>Developer</p>

                                    </div>
                                </div>
                                <div className="Integrante cuadro-imagen2">

                                    <img src={require("../assets/images/rodrigo.jpg")} alt="" />

                                    <div className="down-content">

                                        <h4 className="integrante-name">Rodrigo Zapata</h4>
                                        <p>Developer</p>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </section>



                    {/* <!-- ***** Footer Start ***** --> */}
                    <footer>
                        <div className="container">
                            <div className="row">
                                <div className="col-lg-12">
                                    <p>Copyright &copy; 2022 Grupo 2 Cliente Servidor UTN Frre</p>

                                    

                                </div>
                            </div>
                        </div>
                    </footer>

                    {/* <!-- jQuery --> */}
                    <script src="../assets/js/jquery-2.1.0.min.js"></script>

                    {/* <!-- Bootstrap --> */}
                    <script src="../assets/js/popper.js"></script>
                    <script src="../assets/js/bootstrap.min.js"></script>

                    {/* <!-- Plugins --> */}
                    <script src="../assets/js/scrollreveal.min.js"></script>
                    <script src="../assets/js/waypoints.min.js"></script>
                    <script src="../assets/js/jquery.counterup.min.js"></script>
                    <script src="../assets/js/imgfix.min.js"></script>
                    <script src="../assets/js/mixitup.js"></script>
                    <script src="../assets/js/accordions.js"></script>

                    {/* <!-- Global Init --> */}
                    <script src="../assets/js/custom.js"></script>

                </body>
            </html>

        </div>
    );
}

export default Home;