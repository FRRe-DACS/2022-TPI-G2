import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import CatalogoPaquetes from "./views/CatalogoPaquetes";
import Home from "./views/Home";
import Conocenos from "./views/Conocenos";
import Carroform from "./components/Carro/carroform";
import LoginForm from "./components/login";
import AddPaquetes from "./views/AddPaquetes";
import EditarPaquetes from "./views/EditarPaquetes";
import PostForm from "./views/PostForm";
import RegisterForm from "./components/RegisterForm/RegisterForm";
import StoreProvider from "./store/StoreProvider";

function App() {
  return (
    <div>
      <BrowserRouter>
        <StoreProvider>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/CatalogoPaquetes" element={<CatalogoPaquetes />} />
            <Route path="/Conocenos" element={<Conocenos />} />
            <Route path="/Login" element={<LoginForm />} />
            <Route path="/AddPaquetes" element={<AddPaquetes />} />
            <Route path="/EditarPaquetes" element={<EditarPaquetes />} />
            <Route path="/PostForm" element={<PostForm />} />
            <Route path="/register" element={<RegisterForm />} />
            <Route path="/carroform/:idpaquete" element={<Carroform />} />
          </Routes>
        </StoreProvider>
      </BrowserRouter>
    </div>
  );
}

export default App;
