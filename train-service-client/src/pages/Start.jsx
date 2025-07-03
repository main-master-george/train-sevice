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
            <div style={{
                backgroundColor: '#fff3cd',
                color: '#856404',
                padding: '16px',
                textAlign: 'center',
                borderBottom: '1px solid #ffeeba'
            }}>
                <strong>Внимание!</strong> Сайт находится в разработке. Регистрация является временной, и после завершения разработки все данные пользователей, зарегистрированных в пробный период, будут удалены. Курсы на текущий момент являются демонстрационными и могут быть изменены.
            </div>

            <Header onButtonClick={auth} />
            <Main />
            <Footer />
        </div>
    );
};

export default Start;
