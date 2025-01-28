import './RecipeCard.css';
import PropTypes from 'prop-types';
import Image from 'react-bootstrap/Image';

function RecipeCard({ recipe }) {
    return (
    <div className='col'>
        <h3>{recipe.title}</h3>
        <Image rounded className="img-max" src={"https://localhost:7104/" + recipe.imageUrl} alt={recipe.title} />
        <p>{recipe.description}</p>
    </div>
    )
}

export default RecipeCard;

RecipeCard.propTypes = {
    recipe: PropTypes.shape({
        title: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        imageUrl: PropTypes.string.isRequired,
    }).isRequired
};