import React from 'react';
import {Image, ListGroup} from 'react-bootstrap';
import config from '../../app/config';
import './footer.css';

const Footer = () => {
    return (
        <footer className="footer">
            <ListGroup className="info" as="ul">
                <ListGroup.Item as="li" action variant="success" style={{marginBottom: '8px'}}>
                    телефон: {config.contactInfo.phone}
                </ListGroup.Item>
                <ListGroup.Item as="li" action variant="success">
                    почта: {config.contactInfo.email}
                </ListGroup.Item>
            </ListGroup>
            <div style={{margin: '0px auto 0px auto'}}>
                <Image src="/qrcode.png" rounded className="qr"></Image>
            </div>
        </footer>
    );
};

export default Footer;
