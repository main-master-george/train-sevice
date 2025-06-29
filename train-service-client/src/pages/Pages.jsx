import AuthenticatedHeader from "../features/header/AuthenticatedHeader.jsx";
import Footer from "../features/footer/Footer.jsx";
import {Button, ButtonGroup, Row, Spinner} from "react-bootstrap";
import {useEffect, useState} from "react";
import get from "../requests/completion/page/get.js";
import getText from "../requests/completion/text/get.js";
import getTests from "../requests/completion/test/get.js";
import getTestPoints from "../requests/completion/testPoint/get.js";
import {useParams} from "react-router-dom";
import Page from "../app/components/Page.jsx";

const Pages = () => {
    const { moduleId } = useParams();

    const [pages, setPages] = useState([]);
    const [currentPageIndex, setCurrentPageIndex] = useState(0);
    const [isLoading, setIsLoading] = useState(false);

    const handleShow = async () => {
        setIsLoading(true);
        const id = localStorage.getItem('user_id');
        const pagesResult = await get(moduleId);
        if (!pagesResult.success) {
            return;
        }

        const enriched = await Promise.all(
            pagesResult.data.map(async (page) => {
                const textsResult = await getText(page.id);
                const texts = textsResult.success ? textsResult.data : [];

                const testsResult = await getTests(page.id, id);
                const tests = testsResult.success ? testsResult.data : [];

                const testsWithOptions = await Promise.all(
                    tests.map(async (test) => {
                        const optionsResult = await getTestPoints(test.id);
                        return {
                            ...test,
                            options: optionsResult.success ? optionsResult.data : []
                        };
                    })
                );

                return {
                    ...page,
                    texts,
                    tests: testsWithOptions
                };
            })
        );
        console.log(enriched);

        setPages(enriched);
        setIsLoading(false);
    };

    useEffect(() => {
        handleShow();
    }, []);

    const handlePageChange = (index) => {
        setCurrentPageIndex(index);
    };

    return (
        <div>
            <div style={{
                display: 'flex',
                flexDirection: 'column',
                minHeight: '100vh'
            }}>
                <AuthenticatedHeader />
                <div className="container mt-3">
                    {isLoading ? (
                        <div className="d-flex justify-content-center mt-5">
                            <Spinner animation="border" role="status" />
                        </div>
                    ) : pages.length > 0 ? (
                        <>
                            <div className="d-flex justify-content-center mb-3">
                                <ButtonGroup>
                                    {pages.map((_, index) => (
                                        <Button
                                            key={index}
                                            variant={index === currentPageIndex ? "primary" : "outline-primary"}
                                            onClick={() => handlePageChange(index)}
                                        >
                                            {index + 1}
                                        </Button>
                                    ))}
                                </ButtonGroup>
                            </div>

                            <Row className="justify-content-center">
                                <Page {...pages[currentPageIndex]} />
                            </Row>
                        </>
                    ) : (
                        <h3 className="text-center">ℹ️ Не получилось загрузить страницы курса.</h3>
                    )}
                </div>
            </div>
            <Footer />
        </div>
    );
};

export default Pages;
