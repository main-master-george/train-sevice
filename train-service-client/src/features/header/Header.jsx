import React from 'react';
import {Button, Image} from 'react-bootstrap';
import config from '../../app/config';
import './header.css';

const Header = ({
    buttonText = "Войти или зарегистрироваться",
    buttonVariant = "primary",
    buttonStyle = {},
    onButtonClick = () => {}
                }) => {
    return (
        <header className="header">
            <h1 style={{marginLeft: '16px'}}>{config.siteName}</h1>
            <Image src="/logo.png" roundedCircle className="logo"></Image>
            <Button variant={buttonVariant} className="login" style={buttonStyle} onClick={onButtonClick}>
                {buttonText}
            </Button>
        </header>
    );
};

export default Header;