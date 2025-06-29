import React from 'react';
import Header from '../features/header/Header';
import Main from '../features/main/Main';
import Footer from '../features/footer/Footer';
import { useNavigate } from "react-router-dom";

const Start = () => {
    const navigate = useNavigate();

    const auth = () => {
        navigate("/auth");
    }

    return (
        <div>
            <Header onButtonClick={auth} />
            <Main />
            <Footer />
        </div>
    );
};

export default Start;