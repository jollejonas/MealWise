import PropTypes from 'prop-types';

function RecipeCard({ recipe }) {
    return (
    <div className='col'>
        <h3>{recipe.title}</h3>
        <img src={recipe.image} alt={recipe.title} />
        <p>{recipe.description}</p>
    </div>
    )
}

export default RecipeCard;

RecipeCard.propTypes = {
    recipe: PropTypes.shape({
        title: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        image: PropTypes.string.isRequired,
    }).isRequired
};