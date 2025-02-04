import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { Row } from 'react-bootstrap';

function MealPlanRow({ mealPlan }) {
    return (
        <Row>
            <Link to={`/madplan/${mealPlan.id}`}> <p>Navn: {mealPlan.name} - Start dato: {mealPlan.startDate} - Slut dato: {mealPlan.endDate}</p> </Link>
        </Row>
    )
}

export default MealPlanRow;

MealPlanRow.propTypes = {
    mealPlan: PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        startDate: PropTypes.string.isRequired,
        endDate: PropTypes.string.isRequired,
    }).isRequired
};