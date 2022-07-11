import React, { useState, useEffect } from "react";
import { useStore } from "../../store/StoreProvider"
import { Link } from "react-router-dom";
import Header from "../header";
import { postReserva, payment } from "../../service/reserva.service";
import swal from "sweetalert";
import { useNavigate } from "react-router-dom";
const styles = {
  container: {
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
    height: "95vh",
    gap: "10px"
  },
  label: {
    display: "flex",
    alignItems: "center",
    justifyContent: "space-evenly",
    width: "800px",
    gap: "10px"
  },
  form: {
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
  },
  button: {
    padding: "1rem",
    boder: "1px solid #C63D20",
    boderRadius: "5px",
    cursor: "pointer"
  }
}


function Carroform() {
  const { user } = useStore();
  const [open, setOpen] = useState(false);
  const [reservationId, setReservationId] = useState(null)
  const [error, setError] = useState(null)
  const [cuit, setCuit] = useState(null)
  const navigate = useNavigate();
  const confirmarReserva = () => {
    
    const data = {
      totalPrice: 500,
      createDate: "2022-07-08T15:03:37.738Z",
      validDate: "2022-07-08T15:03:37.738Z",
      status: "inProgress"
    }
    const packageid = parseInt(window.location.pathname.split("/")[2]);
    postReserva(user.id, packageid, data).then(res => {
      if (res.status === 200) {
        setOpen(true);
        setReservationId(res.data.id);
      } else {
        setError("No se pudo procesar la reserva")
      }
    })
  }

  const handlePayment = () => {
    const data = {
      reservationId: reservationId,
      cuit: parseInt(cuit)
    }
    console.log(data);
    payment(data).then(res => {
      console.log(res);
      if (res.data === undefined) { swal("El pago no pudo procesarse, vuelva a intentarlo mas tarde") } else if
        (res.data.aprobada) { swal("El pago fue exitoso"); navigate("/") } else { swal("El pago fue rechazado"); }
    })
  }



  return (
    <div>
      <Header />
      <div className="gv-container-login" style={styles.container}>
        <h2>Iniciar una reserva</h2>
        <div style={styles.form}>
          <form >
            <div className="gv-input-container-login" style={styles.label}>
              <input
                type="text"
                id="username"
                name="username"
                placeholder=" "
                className="gv-input-login"
                value={user.firstName}
              />
              <label htmlFor="username" className="gv-label-login">Nombre</label>
            </div>
            <div className="gv-input-container-login" style={styles.label}>
              <input
                type="text"
                id="username"
                name="username"
                placeholder=" "
                className="gv-input-login"
                value={user.lastName}
              />
              <label htmlFor="username" className="gv-label-login">Apellido</label>
            </div>
            <div className="gv-input-container-login" style={styles.label}>
              <input
                type="text"
                id="username"
                name="username"
                placeholder=" "
                className="gv-input-login"
                value={user.email}
              />
              <label htmlFor="username" className="gv-label-login">Email</label>
            </div>
          </form>
        </div>
        {!open && <div className="button" onClick={confirmarReserva}>
          <p>Confirmar reserva</p>
        </div>}
        <>
          {open && <div>
            <h3 style={{textAlign: "center", padding:"1rem"}}>Introduzca dus datos para el pago</h3>
            <div style={styles.form}>
              <form >
                <div className="gv-input-container-login" style={styles.label}>
                  <input
                    type="number"
                    id="username"
                    name="username"
                    placeholder=" "
                    className="gv-input-login"
                    
                  />
                  <label htmlFor="username" className="gv-label-login">Numero de tarjeta</label>
                </div>
                <div className="gv-input-container-login" style={styles.label}>
                  <input
                    type="password"
                    id="username"
                    name="username"
                    placeholder=" "
                    className="gv-input-login"
                  />
                  <label htmlFor="username" className="gv-label-login">Código de tarjeta</label>
                </div>
                <div className="gv-input-container-login" style={styles.label}>
                  <input
                    type="number"
                    id="username"
                    name="username"
                    placeholder=" "
                    className="gv-input-login"
                    onChange={(e) => { setCuit(e.target.value) }}
                  />
                  <label htmlFor="username" className="gv-label-login">CUIT</label>
                </div>
              </form>
            </div>
            <div className="button" onClick={handlePayment}>
              <p>Pagar</p>
            </div>
          </div>}
        </>
      </div>
    </div>
  );
}



export default Carroform;
