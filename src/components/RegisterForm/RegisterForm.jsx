import React, { useState, useEffect } from "react";
import { useForm } from "../../hooks/useForm";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEyeSlash, faEye } from "@fortawesome/free-solid-svg-icons";
import "./registerForm.css";
import { Link } from "react-router-dom";
import { validationsForm, initialForm, styles } from "./formUtils.js"
import { postUser, loginUser } from "../../service/user.service";
import swal from "sweetalert";
import { useNavigate } from "react-router-dom";
import Header from "../header";
import "../checkBox/Checkbox.css";
import { useDispatch } from "../../store/StoreProvider";
import { types } from "../../store/StoreReducer";

export default function RegisterForm() {
  const [isLogged, setIsLogged] = useState(false);
  const [showPassword, setShowPassword] = useState(false);
  const [showPasswordConfirmation, setShowPasswordConfirmation] = useState(false);
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { form, errors, handleChange, handleBlur, handleSubmit } = useForm(
    initialForm,
    validationsForm
  );

  const handlePost = () => {
    postUser(form).then((res) => {
      if (res.status === 200) {
        loginUser(form.username, form.password).then((res) => {
            let userData = {
              id: res.data.userId,
              firstName: res.data.firstName,
              lastName: res.data.lastName,
              email: res.data.email,
              tokenJwt: res.data.token,
              rol: res.data.role
            }
            dispatch({
              type: types.authLogin,
              payload: userData
            });
            const storeData = {
              user: userData,
              isLogged: true
            }
            localStorage.setItem("store", JSON.stringify(storeData));
            setIsLogged(true);
        })
      } else {
        swal("Lamentablemente no ha podido iniciar sesión. Por favor, intente más tarde");
      }
    })
  }

  useEffect(() => {
    if (isLogged) {
      return navigate("/");
    }
  }, [isLogged]);

  const handleClickShowPassword = () => {
    setShowPassword(!showPassword);
  }

  const noErrors = (errors) => {
    let resp = false;
    if (Object.keys(errors).length === 0) {
      resp = true;
    }
    return resp
  }

  const handleClickShowPasswordConfirmation = () => {
    setShowPasswordConfirmation(!showPasswordConfirmation);
  }

  return (
    <>
      <Header />
      <div className="principalRegister">
        <form className="formRegister" onSubmit={handleSubmit}>
          <h2>Crear Cuenta</h2>
          <div className="gv-input-container-register">
            <input
              className="gv-input-register"
              type="text"
              name="firstName"
              id="firstName"
              placeholder=" "
              value={form.firstName}
              onBlur={handleBlur}
              onChange={handleChange}
            />
            <label htmlFor="name" className="gv-label-register">Nombre</label>
            {errors.firstName && <p style={styles}>{errors.firstName}</p>}
          </div>
          <div className="gv-input-container-register">
            <input
              className="gv-input-register"
              type="text"
              name="lastName"
              id="lastname"
              placeholder=" "
              value={form.lastName}
              onBlur={handleBlur}
              onChange={handleChange}
            />
            <label htmlFor="lastName" className="gv-label-register">Apellido</label>
            {errors.lastName && <p style={styles}>{errors.lastName}</p>}
          </div>
          <div className="gv-input-container-register">
            <input
              className="gv-input-register"
              type="text"
              name="username"
              id="username"
              placeholder=" "
              value={form.username}
              onBlur={handleBlur}
              onChange={handleChange}
            />
            <label htmlFor="name" className="gv-label-register">Nombre de usuario</label>
            {errors.username && <p style={styles}>{errors.username}</p>}
          </div>
          <div className="gv-input-container-register">
            <input
              className="gv-input-register"
              type="email"
              name="email"
              id="email"
              placeholder=" "
              value={form.email}
              onBlur={handleBlur}
              onChange={handleChange}
            />
            <label htmlFor="email" className="gv-label-register">Correo electrónico</label>
            {errors.email && <p style={styles}>{errors.email}</p>}
          </div>
          <div className="gv-input-container-register">
            <input
              className="gv-input-register"
              type="number"
              name="phoneNumber"
              id="phoneNumber"
              placeholder=" "
              value={form.phoneNumber}
              onBlur={handleBlur}
              onChange={handleChange}
            />
            <label htmlFor="phone" className="gv-label-register">Número de telefono</label>
            {errors.phoneNumber && <p style={styles}>{errors.phoneNumber}</p>}
          </div>
          <div className="gv-input-container-register">
            <div className="unc-password">
              <input
                className="gv-input-register"
                type={showPassword ? "text" : "password"}
                name="password"
                id="password"
                placeholder=" "
                value={form.password}
                onBlur={handleBlur}
                onChange={handleChange}
              />
              <label htmlFor="password" className="gv-label-register">Contraseña</label>
              {showPassword ? <FontAwesomeIcon className="faEyeSlashIcon" icon={faEyeSlash} onClick={handleClickShowPassword} /> : <FontAwesomeIcon className="faEyeSlashIcon" icon={faEye} onClick={handleClickShowPassword} />}
            </div>
            {errors.password && <p style={styles}>{errors.password}</p>}
          </div>
          <div className="gv-input-container-register">
            <div className="unc-password">
              <input
                className="gv-input-register"
                type={showPasswordConfirmation ? "text" : "password"}
                name="confirmPassword"
                id="confirmPassword"
                placeholder=" "
                value={form.confirmPassword}
                onBlur={handleBlur}
                onChange={handleChange}
              />
              <label htmlFor="confirmPassword" className="gv-label-register">Confirmar contraseña</label>
              {showPasswordConfirmation ? <FontAwesomeIcon className="faEyeSlashIcon" icon={faEyeSlash} onClick={handleClickShowPasswordConfirmation} /> : <FontAwesomeIcon className="faEyeSlashIcon" icon={faEye} onClick={handleClickShowPasswordConfirmation} />}
            </div>
            {errors.confirmPassword && (
              <p style={styles}>{errors.confirmPassword}</p>
            )}
          </div>
          <div className='gv-checkbox-container'>
            <label className='gv-checkbox-label'>
              <input type="checkbox" className='gv-checkbox-input' name="emailSubscription" value={form.emailSubscription} />
              <span className='gv-checkbox-span'></span>
            </label>
            <p>Desea recibir publicidad</p>
          </div>
          <div className="unc-submit">
            <button type="submit" onClick={handlePost}>Crear cuenta</button>
            <span className="plc-span-form">
              ¿Ya tienes una cuenta?
              <Link className="anchor-link" to={"/login"}>Iniciar Sesión</Link>
            </span>
          </div>
        </form>
      </div>
    </>
  );
}
