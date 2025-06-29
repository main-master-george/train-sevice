import React from "react";
import { Card } from "react-bootstrap";

const TextBlock = ({ text }) => (
    <Card className="mb-3">
        <Card.Body>
            <Card.Text>{text}</Card.Text>
        </Card.Body>
    </Card>
);

export default TextBlock;
