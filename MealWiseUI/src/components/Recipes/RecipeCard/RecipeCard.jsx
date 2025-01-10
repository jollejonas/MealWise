import PropTypes from 'prop-types';

function RecipeCard({ name }) {
    return <li>{name}</li>;
}

export default RecipeCard;

RecipeCard.propTypes = {
    name: PropTypes.string.isRequired,
};