import React from 'react';
import logout from "../../requests/auth/logout.js";
import {useNavigate} from "react-router-dom";
import Header from "./Header.jsx";

const AuthenticatedHeader = () => {
    const buttonStyle = {
        minWidth: '200px',
        marginLeft: 'auto'
    }

    const navigate = useNavigate();

    const start = () => {
        navigate("/", { replace: true });
    }

    const handleLogout = async () => {
        localStorage.removeItem('user_id');
        localStorage.removeItem('email');
        localStorage.removeItem('role');

        await logout();

        start();
    };

    return (
        <div>
            <Header buttonText={"выйти"}
                    buttonVariant={"danger"}
                    buttonStyle={buttonStyle}
                    onButtonClick={handleLogout}>
            </Header>
        </div>
    );
};

export default AuthenticatedHeader;