import { useState } from 'react';
import PropTypes from 'prop-types';
import { Modal, Button, Form } from 'react-bootstrap';

const MealPlanModal = ({ show, handleClose, handleSave }) => {
    const [recipeName, setRecipeName] = useState('');
    const [ingredients, setIngredients] = useState('');
    const [instructions, setInstructions] = useState('');

    const onSave = () => {
        const newRecipe = {
            name: recipeName,
            ingredients: ingredients.split(','),
            instructions
        };
        handleSave(newRecipe);
        handleClose();
    };

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Create New Meal Plan</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group controlId="formRecipeName">
                        <Form.Label>Recipe Name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter recipe name"
                            value={recipeName}
                            onChange={(e) => setRecipeName(e.target.value)}
                        />
                    </Form.Group>
                    <Form.Group controlId="formIngredients">
                        <Form.Label>Ingredients</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter ingredients, separated by commas"
                            value={ingredients}
                            onChange={(e) => setIngredients(e.target.value)}
                        />
                    </Form.Group>
                    <Form.Group controlId="formInstructions">
                        <Form.Label>Instructions</Form.Label>
                        <Form.Control
                            as="textarea"
                            rows={3}
                            placeholder="Enter cooking instructions"
                            value={instructions}
                            onChange={(e) => setInstructions(e.target.value)}
                        />
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
                <Button variant="primary" onClick={onSave}>
                    Save Recipe
                </Button>
            </Modal.Footer>
        </Modal>
    );
};
MealPlanModal.propTypes = {
    show: PropTypes.bool.isRequired,
    handleClose: PropTypes.func.isRequired,
    handleSave: PropTypes.func.isRequired,
};

export default MealPlanModal;