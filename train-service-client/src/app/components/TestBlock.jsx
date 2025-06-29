import React, {useState} from "react";
import {Alert, Button, Card, Form, Spinner} from "react-bootstrap";
import check from "../../requests/completion/test/check.js";

const TestBlock = ({ test }) => {
    const [selectedOption, setSelectedOption] = useState(null);
    const [isChecked, setIsChecked] = useState(false);
    const [isLoading, setIsLoading] = useState(false);

    const handleChange = (e) => {
        setSelectedOption(e.target.value);
    };

    const handleCheck = async () => {
        const id = localStorage.getItem('user_id');
        if (!selectedOption) return;

        setIsLoading(true);
        const result = await check(id, test.id, selectedOption);
        setIsLoading(false);

        if (result.success) {
            setIsChecked(true);
            test.isResolved = result.data;
        }
    };

    return (
        <Card className="mb-3">
            <Card.Body>
                <Card.Title>{test.text}</Card.Title>
                <Form>
                    {test.options.map(option => (
                        <Form.Check type="radio" id={`opt-${option.id}`} disabled={test.isResolved}>
                            <Form.Check.Input
                                type="radio"
                                name={`test-${test.id}`}
                                value={option.id}
                                checked={selectedOption === option.id}
                                onChange={handleChange}
                                disabled={test.isResolved}
                            />
                            <Form.Check.Label
                                disabled={test.isResolved}
                                style={{
                                    display: 'block',
                                    backgroundColor: selectedOption === option.id ? '#e0f7fa' : '#fff',
                                    border: '1px solid #17a2b8',
                                    borderRadius: '6px',
                                    padding: '10px 12px',
                                    marginBottom: '8px',
                                    boxShadow: selectedOption === option.id ? '0 0 0 2px #17a2b8' : 'none',
                                    cursor: 'pointer'
                                }}
                            >
                                {option.text}
                            </Form.Check.Label>
                        </Form.Check>
                    ))}
                </Form>

                <div className="mt-3 d-flex align-items-center gap-2">
                    {!test.isResolved && (
                        <Button
                            onClick={handleCheck}
                            disabled={!selectedOption || isLoading}
                            variant="primary"
                        >
                            {isLoading ? (
                                <Spinner as="span" animation="border" size="sm" role="status" aria-hidden="true" />
                            ) : (
                                "Проверить"
                            )}
                        </Button>
                    )}

                    {isChecked && (
                        <Alert variant={test.isResolved ? "success" : "danger"} className="mb-0 py-1 px-2">
                            {test.isResolved ? "✅ Верно" : "❌ Неверно"}
                        </Alert>
                    )}
                </div>

                {test.isResolved && (<Card.Text>{`набрано баллов: ${test.value}`}</Card.Text>)}
            </Card.Body>
        </Card>
    );
};


export default TestBlock;
