import AuthenticatedHeader from "../features/header/AuthenticatedHeader.jsx";
import Footer from "../features/footer/Footer.jsx";
import {Col, Row, Spinner} from "react-bootstrap";
import {useEffect, useState} from "react";
import get from "../requests/completion/module/get.js";
import {useNavigate, useParams} from "react-router-dom";
import ModuleCard from "../app/components/ModuleCard.jsx";

const Modules = () => {
    const { courseId } = useParams();

    const [nav, setNav] = useState("modules");
    const [modules, setModules] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const handleShow = async () => {
        setIsLoading(true);
        const id = localStorage.getItem('user_id');
        const result = await get(courseId, id);
        setIsLoading(false);

        if (result.success) {
            setModules(result.data);
        }
    }

    const handleCardClick = (isPurchased, moduleId) => {
        navigate(`/pages/${moduleId}`);
    };

    useEffect(() => {
        handleShow();
    }, [nav]);

    return (
        <div>
            <div style={{
                display: 'flex',
                flexDirection: 'column',
                minHeight: '100vh'
            }}>
                <AuthenticatedHeader></AuthenticatedHeader>
                <div className="container mt-3">
                    {isLoading ? (
                        <div className="d-flex justify-content-center mt-5">
                            <Spinner animation="border" role="status" />
                        </div>
                    ) : modules.length > 0 ? (
                        <Row>
                            {modules.map(module => (
                                <Col md={4} className="d-flex" key={module.number} style={{ marginBottom: '16px' }}>
                                    <ModuleCard
                                        header={module.header}
                                        description={module.description}
                                        isPurchased={module.isPurchased}
                                        onClick={() => handleCardClick(module.isPurchased, module.id)}
                                        moduleId={module.id}
                                    />
                                </Col>
                            ))}
                        </Row>
                    ) : (
                        <h3 className="text-center">ℹ️ Не получилось загрузить модули курса.</h3>
                    )}
                </div>
            </div>
            <Footer></Footer>
        </div>
    );
};

export default Modules;