import { useState } from 'react';
import { Container, Button, Form, Row, Col, Tab, Tabs, Accordion } from 'react-bootstrap';
import axios from 'axios';

const RecipeForm = () => {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [servings, setServings] = useState(0);
    const [prepTime, setPrepTime] = useState(0);
    const [cookTime, setCookTime] = useState(0);
    const [ingredientGroups, setIngredientGroups] = useState([]);
    const [image, setImage] = useState(null);

    const handleSave = async (newRecipe) => {
        try {
            console.log("Creating recipe", newRecipe);
            const response = await axios.post('https://localhost:7104/api/recipes', newRecipe);
            console.log("Recipe created", response.data);
        }

        catch (error) {
            console.error("Error creating recipe", error);
        }
    }; 
        const onSave = async () => {
            if (ingredientGroups.length === 0) {
                console.error("Opskriften skal have mindst én ingrediensgruppe.");
                return;
            }
            
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

            console.log("📌 Debug - IngredientGroups før payload:", JSON.stringify(ingredientGroups, null, 2));


            const newRecipe = {
                title: title,
                description,
                servings: parseInt(servings),
                prepTime: parseInt(prepTime),
                cookTime: parseInt(cookTime),
                imageUrl: finalImageUrl,
                ingredientGroups: ingredientGroups.map((group,) => ({ 
                    name: group.name.trim(),
                    ingredientGroupIngredients: group.ingredients
                        .map(ingredient => ({
                            id: 0,
                            ingredientId: ingredient.ingredientId ?? 0,
                            ingredient: ingredient.ingredientId ? null : {
                                id: 0,
                                name: ingredient.name.trim(),
                                unitType: ingredient.unitOverride?.trim() || null,
                            },
                            quantity: ingredient.quantity ? parseFloat(ingredient.quantity) : null,
                            unitOverride: ingredient.unitOverride?.trim() || null,

                    })),
                steps: group.steps.map((step, index) => ({
                    stepNumber: index + 1, 
                    instruction: step.instruction.trim(),
                }))
                    .filter(step => step.instruction),
            })).filter(group => group.ingredientGroupIngredients.length > 0)
        };

        console.log("Final Recipe Payload:", JSON.stringify(newRecipe, null, 2)); // 🚀 Debug
        handleSave(newRecipe);
    };

    const addIngredientGroup = () => {
        setIngredientGroups(prevGroups => [
            ...prevGroups,
            { 
                name: "Ny ingrediensgruppe", 
                ingredients: [{ name: "", quantity: 0, unitOverride: "" }], 
                steps: [{ instruction: "" }] 
            }
        ]);
    };

    const updateIngredientGroupName = (index, value) => {
        setIngredientGroups(prevGroups =>{
            const newGroups = prevGroups.map((group, i) =>
                i === index ? { ...group, name: value } : group
            );
            console.log("📌 Opdaterer ingredientGroups:", JSON.stringify(newGroups, null, 2));
            return newGroups;
        });
    };

    const removeGroup = (index) => {
        setIngredientGroups(ingredientGroups.filter((_, i) => i !== index));
    };

    const removeIngredient = (groupIndex, ingredientIndex) => {
        const newGroups = [...ingredientGroups];
        newGroups[groupIndex].ingredients = newGroups[groupIndex].ingredients.filter((_, i) => i !== ingredientIndex);
        setIngredientGroups(newGroups);
    };

    const removeStep = (groupIndex, stepIndex) => {
        const newGroups = [...ingredientGroups];
        newGroups[groupIndex].steps.splice(stepIndex, 1);
        setIngredientGroups(newGroups);
    };
    
    return (
        <Container>
                <h1>Opret ny opskrift</h1>
                <Tabs defaultActiveKey="details" className="mb-3">
                    <Tab eventKey="details" title="Detaljer">
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
                            </Form>
                        </Tab>
                        <Tab eventKey="ingredients-steps" title="Ingredienser & Fremgangsmåde">
                        <Accordion>
                        {ingredientGroups.map((group, index) => (
                                    <Accordion.Item eventKey={index.toString()} key={index}>
                                        <Accordion.Header>{group.name || "Ny gruppe"} </Accordion.Header>
                                        <Accordion.Body>
                                            <Form.Control 
                                                type="text" 
                                                placeholder="Gruppenavn" 
                                                value={group.name} 
                                                onChange={(e) => updateIngredientGroupName(index, e.target.value)} 
                                                />
                                            <Button variant="danger" className="mt-2" onClick={() => removeGroup(index)}>Fjern gruppe</Button>
                                            <Accordion>
                                                <Accordion.Item eventKey={`ingredients-${index}`}>
                                                    <Accordion.Header>Ingredienser</Accordion.Header>
                                                    <Accordion.Body>
                                                        {group.ingredients.map((ingredient, ingredientIndex) => (
                                                        <Row key={ingredientIndex} className="mt-2">
                                                            <Col>
                                                                <Form.Control type="text" placeholder="Ingrediens navn" value={ingredient.name} onChange={(e) => {
                                                                    const newGroups = [...ingredientGroups];
                                                                    newGroups[index].ingredients[ingredientIndex].name = e.target.value;
                                                                    setIngredientGroups(newGroups);
                                                                }} />
                                                            </Col>
                                                            <Col>
                                                                <Form.Control type="number" placeholder="Mængde" value={ingredient.quantity} onChange={(e) => {
                                                                    const newGroups = [...ingredientGroups];
                                                                    newGroups[index].ingredients[ingredientIndex].quantity = e.target.value;
                                                                    setIngredientGroups(newGroups);
                                                                }} />
                                                            </Col>
                                                            <Col>
                                                                <Form.Control type="text" placeholder="Enhed" value={ingredient.unitOverride} onChange={(e) => {
                                                                    const newGroups = [...ingredientGroups];
                                                                    newGroups[index].ingredients[ingredientIndex].unitOverride = e.target.value;
                                                                    setIngredientGroups(newGroups);
                                                                }} />
                                                            </Col>
                                                            <Col>
                                                                <Button variant="danger" onClick={() => removeIngredient(index, ingredientIndex)}>Fjern ingrediens</Button>
                                                            </Col>
                                                            </Row>
                                                            ))}
                                                            <Button variant="secondary" className="mt-2" onClick={() => {
                                                                const newGroups = [...ingredientGroups];
                                                                newGroups[index].ingredients.push({  name: "", quantity: '', unitOverride: '' });
                                                                setIngredientGroups(newGroups);
                                                            }}>Tilføj ingrediens</Button>
                                                </Accordion.Body>
                                            </Accordion.Item>
                                            <Accordion.Item eventKey={`steps-${index}`}>
                                                <Accordion.Header>Fremgangsmåde</Accordion.Header>
                                                <Accordion.Body>
                                                    {group.steps.map((step, stepIndex) => (
                                                        <Row key={stepIndex} className="mt-2">
                                                            <Col>
                                                                <h5>{stepIndex + 1}</h5>
                                                                <Form.Control as="textarea" rows={2} value={step.instruction} onChange={(e) => {
                                                                    const newGroups = [...ingredientGroups];
                                                                    newGroups[index].steps[stepIndex].instruction = e.target.value;
                                                                    setIngredientGroups(newGroups);
                                                                }} />
                                                            </Col>
                                                            <Col>
                                                                <Button variant="danger" onClick={() => removeStep(index, stepIndex)}>Fjern trin</Button>
                                                            </Col>
                                                            </Row>
                                                    ))}
                                                    <Button variant="secondary" onClick={() => {
                                                        const newGroups = [...ingredientGroups];
                                                        newGroups[index].steps.push({ instruction: '' });
                                                        setIngredientGroups(newGroups);
                                                    }}>Tilføj trin</Button>
                                                </Accordion.Body>
                                            </Accordion.Item>
                                        </Accordion>
                                    </Accordion.Body>
                                </Accordion.Item>
                            ))}
                            
                        </Accordion>
                            <Button variant="secondary" className="mt-3" onClick={addIngredientGroup}>
                                Tilføj ingrediensgruppe
                            </Button>
                        </Tab>
                    </Tabs>
                <Button variant="primary" onClick={onSave}>
                    Opret opskrift
                </Button>
            </Container>
    );
};

export default RecipeForm;