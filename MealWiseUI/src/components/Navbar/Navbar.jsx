import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import { Link } from 'react-router';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import RecipeModal from '../Recipes/RecipeModal/RecipeModal';
import MealPlanModal from '../MealPlans/MealPlanModal/MealPlanModal';
import axios from 'axios';

function MainNavbar() {
    const [activeModal, setActiveModal] = useState(null);

    const handleOpenModal = (modalType => {
        setActiveModal(modalType);
    })

    const handleCloseModal = () => {
        setActiveModal(null);
    }

    const handleSave = async (newRecipe) => {
        try {
            const response = await axios.post('https://localhost:7104/api/recipes', newRecipe);
            console.log("Recipe created", response.data);
        }

        catch (error) {
            console.error("Error creating recipe", error);
        }
    };

    return (
        <>
        <Navbar className="d-flex justify-content-end px-4" bg="light" expand="lg">
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse className="justify-content-around" id="basic-navbar-nav">
                <Nav className="mr-auto">
                    <Nav.Link as={Link} to="/">Home</Nav.Link>
                    <Nav.Link as={Link} to="/opskrifter">Opskrifter</Nav.Link>
                    <Nav.Link as={Link} to="/madplaner">Madplaner</Nav.Link>
                    <Nav.Link as={Link} to="/indkobsliste">Indkøbsliste</Nav.Link>
                    <NavDropdown title="Opret" id="basic-nav-dropdown">
                        <NavDropdown.Item onClick={() => handleOpenModal("recipe")}>Opskrift</NavDropdown.Item>
                        <NavDropdown.Item onClick={() => handleOpenModal("mealPlan")}>Madplan</NavDropdown.Item>
                    </NavDropdown>
                </Nav>
                <Navbar.Brand href="#home">MealWise</Navbar.Brand>
                <Nav className="ml-auto">
                    <Nav.Link href="#link">Opret bruger</Nav.Link>
                    <Nav.Link href="#link">Login</Nav.Link>
                </Nav>
            </Navbar.Collapse>
        </Navbar>

        {activeModal === "recipe" && <RecipeModal show={true} handleClose={handleCloseModal} handleSave={handleSave} />}
        {activeModal === 'mealPlan' && <MealPlanModal show={true} handleClose={handleCloseModal} handleSave={() => {}}  />}
        </>
    );
};

export default MainNavbar;