import AuthenticatedHeader from "../features/header/AuthenticatedHeader.jsx";
import Footer from "../features/footer/Footer.jsx";
import {Col, Row, Spinner} from "react-bootstrap";
import {useEffect, useState} from "react";
import CourseCard from "../app/components/CourseCard.jsx";
import getPurchased from "../requests/completion/course/getPurchased.js";
import getNotPurchased from "../requests/completion/course/getNotPurchased.js";
import {useNavigate} from "react-router-dom";

const Courses = () => {
    const [nav, setNav] = useState("courses");
    const [courses, setCourses] = useState([]);
    const [myCourses, setMyCourses] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

    const handleShow = async () => {
        setIsLoading(true);
        const userId = localStorage.getItem('user_id');
        const purchasedResult = await getPurchased(userId, 0, 100);
        const purchased = purchasedResult.success ? purchasedResult.data : [];
        const notPurchasedResult = await getNotPurchased(userId, 0, 100);
        const notPurchased = notPurchasedResult.success ? notPurchasedResult.data : [];
        setMyCourses(purchased);
        setCourses(notPurchased);
        setIsLoading(false);
    }

    const handleCardClick = (courseId) => {
        navigate(`/modules/${courseId}`);
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
                    ) : (
                        <>
                            <Row>
                                {courses.map(course => (
                                    <Col md={4} className="d-flex" key={course.id} style={{ marginBottom: '16px' }}>
                                        <CourseCard
                                            name={course.name}
                                            description={course.description}
                                            isPurchased={false}
                                            onClick={() => handleCardClick(course.id)}
                                            courseId={course.id}
                                        />
                                    </Col>
                                ))}
                                {myCourses.map(course => (
                                    <Col md={4} className="d-flex" key={course.courseId} style={{ marginBottom: '16px' }}>
                                        <CourseCard
                                            name={course.name}
                                            description={course.description}
                                            isPurchased={true}
                                            onClick={() => handleCardClick(course.courseId)}
                                            courseId={course.courseId}
                                        />
                                    </Col>
                                ))}
                            </Row>

                            {myCourses.length + courses.length === 0 && <h3 className="text-center">ℹ️ Не удалось загрузить курсы.</h3>}
                        </>)}
                </div>
            </div>
            <Footer></Footer>
        </div>
    );
};

export default Courses;