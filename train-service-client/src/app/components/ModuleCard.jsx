import {useState} from "react";
import {Button, Card, Spinner} from "react-bootstrap";
import {LockFill} from "react-bootstrap-icons";
import append from "../../requests/completion/module/append.js";

const ModuleCard = ({header, description, isPurchased, onClick, moduleId}) => {
    const [loading, setLoading] = useState(false);
    const [purchased, setPurchased] = useState(isPurchased);

    const handlePurchase = async (e) => {
        e.stopPropagation();
        setLoading(true);
        const userId = localStorage.getItem('user_id');
        const result = await append(userId, [moduleId]);
        setPurchased(result.success);
        setLoading(false);
    };

    const handleCardClick = () => {
        if (purchased) {
            onClick();
        }
    };

    return (
        <Card
            onClick={handleCardClick}
            style={{
                position: 'relative',
                cursor: purchased && onClick ? 'pointer' : 'default'
            }}
        >
            {!purchased && (
                <div style={{
                    position: 'absolute',
                    top: '8px',
                    right: '8px',
                    backgroundColor: 'rgba(255, 255, 255, 0.8)',
                    borderRadius: '50%',
                    padding: '6px',
                    zIndex: 1
                }}>
                    <LockFill color="black" size={18}/>
                </div>
            )}
            <Card.Body>
                <Card.Title>{header}</Card.Title>
                <Card.Text>{description}</Card.Text>
                {!purchased && (
                    <Button
                        variant="primary"
                        onClick={handlePurchase}
                        disabled={loading}
                    >
                        {loading ? (
                            <>
                                <Spinner
                                    as="span"
                                    animation="border"
                                    size="sm"
                                    role="status"
                                    aria-hidden="true"
                                    className="me-2"
                                />
                            </>
                        ) : (
                            "Открыть доступ"
                        )}
                    </Button>
                )}
            </Card.Body>
        </Card>
    );
};

export default ModuleCard;
