import React, { useState } from "react";
import DropdownMenu from "../dropdownMenu/DropdownMenu";
import useWindowDimensions from "../../hooks/useWindowDimension";
import { useStore } from "../../store/StoreProvider"

const styles = {
    container: {
        display: "flex",
        cursor: "pointer"
    },
    infoContainer: {
        display: "flex",
        alignItems: "center",
        justifyContent: "space-around",
        gap: "0.5rem",
        width: "100px",
        height: "50px",
        borderRadius: "40px",
        boxShadow: "rgba(0, 0, 0, 0.16) 0px 3px 6px, rgba(0, 0, 0, 0.23) 0px 3px 6px",
        border: "1px solid #fff"
    },
    avatar: {
        width: "2.5rem",
        height: "2.5rem",
        borderRadius: "50%",
        backgroundColor: "var(--color2)",
        color: "var(--white)",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
    },
    p: {
        fontSize: "1rem",
        color: "#fff"
    },
    span: {
        width: "28px",
        height: "2px",
        borderRadius: "9999px",
        backgroundColor: "#fff"
    },
    spanContainer: {
        display: "flex",
        flexDirection: "column",
        height: "30px",
        alignItems: "center",
        justifyContent: "space-evenly",
        marginRight: "5px"
    }
}

const IconUserDesk = ({closeSession}) => {
    const [open, setOpen] = useState(false);
    const dimensions = useWindowDimensions();
    const handleOpen = () => {
        setOpen(!open);
    }
    const store = useStore();
    const { user } = store;

    return (
        <div >
            <div style={styles.container} onClick={handleOpen}>
                <div style={styles.infoContainer}>
                    <div style={styles.avatar}>
                        {user.firstName &&
                            user.firstName.split(" ").map((letter, index) => (
                                <p key={index} style={styles.p}>{letter.slice(0, 1).toUpperCase()}</p>
                            ))
                        }
                    </div>
                    <div style={styles.spanContainer}>
                        <span style={styles.span}></span>
                        <span style={styles.span}></span>
                        <span style={styles.span}></span>
                    </div>
                </div>
                {dimensions.width > 468 && open && <DropdownMenu handleOpen={handleOpen} closeSession={closeSession}/>}
            </div>
        </div>
    );
};

export default IconUserDesk;