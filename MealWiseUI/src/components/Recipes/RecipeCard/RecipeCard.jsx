import './RecipeCard.css';
import PropTypes from 'prop-types';
import Image from 'react-bootstrap/Image';
import { Link } from 'react-router-dom';
import { Col } from 'react-bootstrap';

function RecipeCard({ recipe }) {
    if (recipe.imageUrl === null || recipe.imageUrl === "") {
        recipe.imageUrl = "https://picsum.photos/seed/food/500/300";
    } else if (!recipe.imageUrl.startsWith("http")) {
        recipe.imageUrl = ("https://localhost:7104/" + recipe.imageUrl);
    }
    return (
        <Col>
            <h4 className="py-3">{recipe.title}</h4>
            <Image rounded className="img-max" src={recipe.imageUrl} alt={recipe.title} />
            <p>{recipe.description}</p>
            <Link to={`/opskrift/${recipe.id}`}> Se opskrift
            </Link>
        </Col>
    )
}

export default RecipeCard;

RecipeCard.propTypes = {
    recipe: PropTypes.shape({
        id: PropTypes.number.isRequired,
        title: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        imageUrl: PropTypes.string.isRequired,
    }).isRequired
};