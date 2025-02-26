import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import { Link } from 'react-router';
import { logout, isAuthenticated } from '../../services/authService';
import 'bootstrap/dist/css/bootstrap.min.css';
import UserModal from '../User/UserModal';
import LoginForm from '../User/LoginForm';
import RegisterForm from '../User/RegisterForm';

function MainNavbar() {
    const [isLoggedIn, setIsLoggedIn] = useState(isAuthenticated());
    const [showModal, setShowModal] = useState(false);
    const [isRegister, setIsRegister] = useState(false);

    const handleShowLogin = () => {
        setShowModal(true);
        setIsRegister(false);
    }

    const handleShowRegister = () => {
        setShowModal(true);
        setIsRegister(true);
    }

    const handleClose = () => {
        setShowModal(false);
    }

    const handleLogout = () => {
        logout();
        setIsLoggedIn(false);
    }

    useEffect(() => {
        const handleStorageChange = () => {
            setIsLoggedIn(isAuthenticated());
        };

        window.addEventListener("storage", handleStorageChange);
        return () => window.removeEventListener("storage", handleStorageChange);
    }, []);

    return (
        <>
        <Navbar className="d-flex justify-content-end px-4" bg="light" expand="lg">
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse className="justify-content-around" id="basic-navbar-nav">
                <Nav className="mr-auto">
                    <Nav.Link as={Link} to="/">Home</Nav.Link>
                    <Nav.Link as={Link} to="/opskrifter">Opskrifter</Nav.Link>
                    <Nav.Link as={Link} to="/madplaner">Madplaner</Nav.Link>
                    <Nav.Link as={Link} to="/indkobslister">Indkøbsliste</Nav.Link>
                    {isLoggedIn && (
                    <NavDropdown title="Opret" id="basic-nav-dropdown">
                        <Nav.Link as={Link} to="/opret-opskrift">Opskrift</Nav.Link>
                        <Nav.Link as={Link} to="/opret-madplan">Madplan</Nav.Link>
                    </NavDropdown>
                    )}
                </Nav>
                <Navbar.Brand href="#home">MealWise</Navbar.Brand>
                <Nav className="ml-auto">
                    {!isLoggedIn ? (
                    <>
                        <Nav.Link onClick={handleShowRegister}>Opret bruger</Nav.Link>
                        <Nav.Link onClick={handleShowLogin}>Login</Nav.Link>
                        </>
                    ) : (
                        <Nav.Link onClick={handleLogout}>Log ud</Nav.Link>
                    )}
                </Nav>
            </Navbar.Collapse>
        </Navbar>

        <UserModal
            show={showModal}
            handleClose={handleClose}
            isRegister={isRegister}
            formComponent={isRegister ? RegisterForm : LoginForm}
        />
       </>
    );
};

export default MainNavbar;