import { useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import PropTypes from "prop-types";

function SelectRecipeModal({ show, onClose, onRecipeSelect, recipes }) {
    const [search, setSearch] = useState("");

    const filteredRecipes = recipes.filter((recipe) => {
        return recipe.title.toLowerCase().includes(search.toLowerCase());
    });

    return (
        <Modal show={show} onHide={onClose}>
            <Modal.Header closeButton>
                <Modal.Title>Vælg opskrift</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form.Control
                    type="text"
                    placeholder="Søg efter en opskrift"
                    value={search}
                    onChange={(e) => setSearch(e.target.value)}
                />
                
                <ul className="list-group mt-2">
                    {filteredRecipes.map((recipe) => (
                        <li
                            key={recipe.id}
                            className="list-group-item"
                            onClick={() => {
                                onRecipeSelect(recipe)}}
                            style={{ cursor: "pointer" }}
                        >
                            {recipe.title}
                        </li>
                    ))}
                </ul>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onClose}>
                     Luk
                </Button>
            </Modal.Footer>
        </Modal>
    )
}

SelectRecipeModal.propTypes = {
    show: PropTypes.bool.isRequired,
    onClose: PropTypes.func.isRequired,
    onRecipeSelect: PropTypes.func.isRequired,
    recipes: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.number.isRequired,
            title: PropTypes.string.isRequired,
        })
    ).isRequired
};

export default SelectRecipeModal;