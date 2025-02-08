import PropTypes from 'prop-types';
import axios from 'axios';

function MealPlanRow({ mealPlan }) {
    const handleRowClick = () => {
        window.location.href = `/madplan/${mealPlan.id}`;
    };

    const handleDeleteMealPlan = async (event) => {
        event.stopPropagation();
        try {
            const response = await axios.delete(`https://localhost:7104/api/mealplans/${mealPlan.id}`);
            console.log("Meal plan deleted", response.data);
            alert("Madplan slettet");
            window.location.reload();
        } catch (error) {
            console.error("Error deleting meal plan", error);
            alert("Der opstod en fejl. Prøv igen senere.");
        }
    }

    return (
                <tr onClick={handleRowClick} style={{ cursor: 'pointer' }}>
                    <td>{mealPlan.name}</td>
                    <td>{mealPlan.startDate}</td>
                    <td>{mealPlan.endDate}</td>
                    <td><button onClick={handleDeleteMealPlan} className="btn btn-danger">Slet</button></td>
                </tr>
            
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