import { useState } from 'react';
import PropTypes from 'prop-types';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';
import DynamicIngredients from '../../Ingredients/DynamicIngreidents/DynamicIngredientsModal';
import axios from 'axios';

const RecipeModal = ({ show, handleClose, handleSave }) => {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [servings, setServings] = useState(0);
    const [prepTime, setPrepTime] = useState(0);
    const [cookTime, setCookTime] = useState(0);
    const [instructions, setInstructions] = useState('');
    const [ingredients, setIngredients] = useState([{ name: '', quantity: '', unit: '' }]);
    const [image, setImage] = useState(null);

 
        const onSave = async () => {
            let finalImageUrl = "";

            if (image) {
                try {
                    const formData = new FormData();
                    formData.append('file', image);
                
                    const response = await axios.post('https://localhost:7104/api/recipes/upload-image', formData, {
                        headers: { 'Content-Type': 'multipart/form-data' },
                    });
                    finalImageUrl = response.data.imageUrl;
                    console.log('Image uploaded:', finalImageUrl);
                }
                catch (error) {
                    console.error('Error uploading image', error);
                    return;
                }
            }

            const newRecipe = {
                title: title,
                description,
                servings: parseInt(servings),
                prepTime: parseInt(prepTime),
                cookTime: parseInt(cookTime),
                instructions,
                imageUrl: finalImageUrl,
                recipeIngredients: ingredients.map((ingredient) => ({ 
                    ingredient: { name: ingredient.name, unitType: ingredient.unit }, 
                    quantity: parseFloat(ingredient.quantity) || 0
                })),
        };
        console.log(newRecipe)
        handleSave(newRecipe);
        handleClose();
    };

    return (
        <Modal show={show} onHide={handleClose} size="lg">
            <Modal.Header closeButton>
                <Modal.Title>Opret ny opskrift</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group controlId="formTitle">
                        <Form.Label>Opskrifts navn</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Skriv opskriftens navn"
                            value={title}
                            onChange={(e) => setTitle(e.target.value)}
                        />
                    </Form.Group>
                    <Form.Group controlId="formDescription">
                        <Form.Label>Beskrivelse</Form.Label>
                        <Form.Control
                            as="textarea"
                            rows={3}
                            placeholder="Skriv en beskrivelse"
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                        />
                    </Form.Group>
                    <Form.Group controlId="formImage">
                        <Form.Label>Billede</Form.Label>
                        <Form.Control
                            type="file"
                            accept="image/*"
                            onChange={(e) => setImage(e.target.files[0])}
                        />
                    </Form.Group>
                    <Form.Group controlId="formServings">
                        <Form.Label>Portioner</Form.Label>
                        <Form.Control
                            type="number"
                            min={1}
                            max={2000}
                            value={servings}
                            onChange={(e) => setServings(e.target.value)}
                        />
                    </Form.Group>
                    <Form.Group controlId="formPrepTime">
                        <Form.Label>Forberedelsestid</Form.Label>
                        <Row>
                            <Col xs={3}>
                                <Form.Control
                                    type="number"
                                    value={prepTime}
                                    step={5}
                                    onChange={(e) => setPrepTime(e.target.value)}
                                />
                            </Col>
                            <Col xs={9}>
                                <Form.Range 
                                    min={0}
                                    max={120}
                                    step={5}
                                    value={prepTime}
                                    onChange={(e) => setPrepTime(e.target.value)}
                                />
                            
                            </Col>
                        </Row>
                    </Form.Group>
                    <Form.Group controlId="formPrepTime">
                        <Form.Label>Tilberedelsestid</Form.Label>
                        <Row>
                            <Col xs={3}>
                                <Form.Control
                                    type="number"
                                    value={cookTime}
                                    step={5}
                                    onChange={(e) => setCookTime(e.target.value)}
                                />
                            </Col>
                            <Col xs={9}>
                                <Form.Range 
                                    min={0}
                                    max={120}
                                    step={5}
                                    value={cookTime}
                                    onChange={(e) => setCookTime(e.target.value)}
                                />
                            
                            </Col>
                        </Row>
                    </Form.Group>
                    <Form.Group controlId="formInstructions">
                        <Form.Label>Fremgangsmåde</Form.Label>
                        <Form.Control
                            as="textarea"
                            rows={3}
                            placeholder="Beskriv fremgangsmåden"
                            value={instructions}
                            onChange={(e) => setInstructions(e.target.value)}
                        />
                    </Form.Group>
                    <Form.Group controlId="formIngredients">
                        <Form.Label>Ingredients</Form.Label>
                        <DynamicIngredients ingredients={ingredients} setIngredients={setIngredients} />
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Luk vindue
                </Button>
                <Button variant="primary" onClick={onSave}>
                    Opret opskrift
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

RecipeModal.propTypes = {
    show: PropTypes.bool.isRequired,
    handleClose: PropTypes.func.isRequired,
    handleSave: PropTypes.func.isRequired,
};

export default RecipeModal;