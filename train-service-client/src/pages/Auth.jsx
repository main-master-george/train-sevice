import { useState } from "react";
import {Form, Button, Container, Col, Spinner} from "react-bootstrap";
import confirmEmail from "../requests/auth/confirm.js"
import register from "../requests/auth/register.js";
import login from "../requests/auth/login.js";
import {useNavigate} from "react-router-dom";
import getInformation from "../requests/user/getInformation.js";

const Auth = () => {
    const [isRegister, setIsRegister] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [code, setCode] = useState("");
    const [showCodeInput, setShowCodeInput] = useState(false);
    const [isLoading, setIsLoading] = useState(false);
    const [passwordError, setPasswordError] = useState("");

    const isPasswordValid = (password) => {
        const lengthCheck = password.length >= 8;
        const upperCaseCheck = /[A-Z]/.test(password);
        const lowerCaseCheck = /[a-z]/.test(password);
        const digitCheck = /\d/.test(password);
        const specialCharCheck = /[!*@#$%^&]/.test(password);
        return lengthCheck && upperCaseCheck && lowerCaseCheck && digitCheck && specialCharCheck;
    };

    const handlePasswordChange = (e) => {
        const newPassword = e.target.value;
        setPassword(newPassword);
        if (!isPasswordValid(newPassword)) {
            setPasswordError("Пароль должен содержать минимум 8 символов, включая заглавные и строчные латинские буквы, хотя бы одну цифру и один спецсимвол (!*@#$%^&)");
        } else {
            setPasswordError("");
        }
    };

    const navigate = useNavigate();

    const courses = () => {
        navigate("/courses", { replace: true });
    }

    const handleRegister = async (e) => {
        e.preventDefault();
        setIsLoading(true);

        const result = await register(code, email, password);
        setIsLoading(false);

        if (!result.success) {
            alert(result.message);
        } else {
            await handleLogin(e);
        }
    };

    const handleConfirmCode = async (e) => {
        e.preventDefault();
        setIsLoading(true);
        setShowCodeInput(true);

        const result = await confirmEmail(email);
        setIsLoading(false);
    };

    const handleLogin = async (e) => {
        e.preventDefault();
        setIsLoading(true);

        const result = await login(email, password);

        console.log(result);

        if (!result.success) {
            setIsLoading(false);
            alert(result.message);
        } else {
            const information = await getInformation(email);
            setIsLoading(false);

            console.log(information);

            if (information.success) {
                localStorage.setItem('user_id', information.data.id);
                localStorage.setItem('email', information.data.email);
                localStorage.setItem('role', information.data.role);
                courses();
            } else {
                alert(result.message);
            }
        }
    };

    return (
        <Container className="d-flex justify-content-center align-items-center vh-100">
            <Col md={6} className="border p-4 rounded shadow">
                <h2 className="text-center">{isRegister ? "Регистрация" : "Вход"}</h2>
                <Form onSubmit={isRegister ? (showCodeInput ? handleRegister : handleConfirmCode) : handleLogin}>
                    <Form.Group controlId="email">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" value={email} onChange={(e) => setEmail(e.target.value)} required />
                    </Form.Group>
                    <Form.Group controlId="password" className="mt-3">
                        <Form.Label>Пароль</Form.Label>
                        <Form.Control
                            type="password"
                            value={password}
                            onChange={handlePasswordChange}
                            isInvalid={!!passwordError}
                            required
                        />
                        <Form.Control.Feedback type="invalid">
                            {passwordError}
                        </Form.Control.Feedback>
                    </Form.Group>
                    {isRegister && showCodeInput && (
                        <Form.Group controlId="code" className="mt-3">
                            <Form.Label>Код подтверждения</Form.Label>
                            <Form.Control type="text" value={code} onChange={(e) => setCode(e.target.value)} required />
                        </Form.Group>
                    )}
                    <Button variant="primary" type="submit" className="mt-3 w-100" disabled={isLoading || (isRegister && showCodeInput && !!passwordError)}>
                        {isLoading ? (
                            <>
                                <Spinner animation="border" size="sm" role="status" className="me-2" />
                            </>
                        ) : isRegister ? (
                            showCodeInput ? "Подтвердить код" : "Зарегистрироваться"
                        ) : (
                            "Войти"
                        )}
                    </Button>
                    <Button
                        variant="link"
                        onClick={() => {
                            setIsRegister(!isRegister);
                            setShowCodeInput(false);
                        }}
                        className="mt-2 w-100"
                        disabled={isLoading}
                    >
                        {isRegister ? "Уже есть аккаунт? Войти" : "Нет аккаунта? Зарегистрироваться"}
                    </Button>
                </Form>
            </Col>
        </Container>
    );
}

export default Auth;