import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import { Link } from 'react-router';
import 'bootstrap/dist/css/bootstrap.min.css';

function MainNavbar() {

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
                    <NavDropdown title="Opret" id="basic-nav-dropdown">
                        <Nav.Link as={Link} to="/opret-opskrift">Opskrift</Nav.Link>
                        <Nav.Link as={Link} to="/opret-madplan">Madplan</Nav.Link>
                    </NavDropdown>
                </Nav>
                <Navbar.Brand href="#home">MealWise</Navbar.Brand>
                <Nav className="ml-auto">
                    <Nav.Link href="#link">Opret bruger</Nav.Link>
                    <Nav.Link href="#link">Login</Nav.Link>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
       </>
    );
};

export default MainNavbar;