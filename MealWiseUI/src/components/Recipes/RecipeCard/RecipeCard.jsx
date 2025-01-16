import PropTypes from 'prop-types';

function RecipeCard({ recipe }) {
    return (
    <li>{recipe.title}</li>
    )
}

export default RecipeCard;

RecipeCard.propTypes = {
    recipe: PropTypes.shape({
        title: PropTypes.string.isRequired,
    }).isRequired,
};