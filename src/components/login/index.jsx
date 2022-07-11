import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { Link, useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEyeSlash, faEye } from "@fortawesome/free-solid-svg-icons";
import "./index.css";
import { loginUser } from "../../service/user.service";
import Header from "../header";
import { useDispatch } from "../../store/StoreProvider";
import { types } from "../../store/StoreReducer";

export default function LoginForm() {
    const [showPassword, setShowPassword] = useState(false);
    const navigate = useNavigate();
    const [isLogged, setIsLogged] = useState(false);
    //El context del usuario 
    const dispatch = useDispatch();

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();

    const handleClickShowPassword = () => {
        setShowPassword(!showPassword);
    }

    const onSubmit = (data) => {
        const username = data.username;
        const password = data.password;
        loginUser(username, password).then((res) => {
            console.log(res)
            if (res.status === 200) {
                const userData = {
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
            };
        })
    }

    //Si el usuario ya se logeo, lo redirecciona al home
    useEffect(() => {
        if (isLogged) return navigate("/");
    }, [isLogged, navigate]);

    let styles = {
        fontWeight: "bold",
        color: "#FF0000",
        fontSize: "14px",
        textAlign: "end",
        position: "absolute",
        bottom: "-20px",
        right: "0px"
    };

    return (
        <>
            <Header />
            <div className="gv-container-login">
                <form className="formLogin" onSubmit={handleSubmit(onSubmit)}>
                    <h2>Iniciar sesión</h2>
                    <div className="gv-input-container-login">
                        <input
                            type="text"
                            id="username"
                            name="username"
                            placeholder=" "
                            className="gv-input-login"
                            {...register("username", {
                                required: {
                                    value: true,
                                    message: "El campo es requerido",
                                },
                                pattern: {

                                    message: "El formato no es correcto",
                                },
                            })}
                        />
                        <label htmlFor="username" className="gv-label-login">Username</label>
                        {errors.username && <p style={styles}>{errors.username.message}</p>}
                    </div>
                    <div className="gv-input-container-login">
                        <input
                            type={showPassword ? "text" : "password"}
                            id="pwd"
                            name="pwd"
                            placeholder=" "
                            className="gv-input-login"
                            {...register("password", {
                                required: {
                                    value: true,
                                    message: "El campo es requerido",
                                },
                                minLength: {
                                    value: 6,
                                    message: "La contraseña debe tener al menos 6 caracteres",
                                },
                            })}
                        />
                        <label htmlFor="pwd" className="gv-label-login">Contraseña</label>
                        {showPassword ? <FontAwesomeIcon className="faEyeSlashIcon" icon={faEyeSlash} onClick={handleClickShowPassword} /> : <FontAwesomeIcon className="faEyeSlashIcon" icon={faEye} onClick={handleClickShowPassword} />}
                        {errors.password && (
                            <p style={styles}>{errors.password.message}</p>
                        )}
                    </div>

                    <div className="unc-submit">
                        <button type="submit">Ingresar</button>
                        <span className="plc-span-form">
                            ¿Aún no tienes cuenta?
                            <Link className="anchor-link" to={"/register"}>  Registrate</Link>
                        </span>
                    </div>
                </form>
            </div>
        </>
    );
}
