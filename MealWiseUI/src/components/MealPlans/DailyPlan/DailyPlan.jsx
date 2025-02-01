import { Container, Col } from "react-bootstrap"
import { useDroppable } from "@dnd-kit/core";
import PropTypes from 'prop-types';
import './DailyPlan.css';

function DailyPlan({ day, mealPlanRecipes, recipes }) {
    const {setNodeRef: breakfastDroppable} = useDroppable({
        id: `${day}-breakfast`,
    });
    const {setNodeRef: lunchDroppable} = useDroppable({
        id: `${day}-lunch`,
    });
    const {setNodeRef: dinnerDroppable} = useDroppable({
        id: `${day}-dinner`,
    });
    const {setNodeRef: snackDroppable} = useDroppable({
        id: `${day}-snack`,
    });

    const getRecipeName = (id) => {
        const recipe = recipes.find((recipe) => recipe.id === id);
        return recipe ? recipe.title : "Ukendt opskrift";
    };

    const filterMeals = (mealType) => {
        console.log(mealPlanRecipes);
        return mealPlanRecipes.filter((r) => r.mealType.toLowerCase() === mealType.toLowerCase());
    }

    return (
        <Col>
        <Container className="border border-dark">
            <h5> { day }</h5>
            <p>Morgenmad</p>
            <div ref={breakfastDroppable} className="border border-black sizing">
                    {filterMeals("breakfast").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(r.recipeId))}
                        </div>
                    ))}
                    </div>
            <p>Frokost</p>
            <div ref={lunchDroppable} className="border border-black sizing">
                {filterMeals("lunch").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(r.recipeId))}
                        </div>
                    ))}</div>
            <p>Aftensmad</p>
            <div ref={dinnerDroppable} className="border border-black sizing">
                {filterMeals("dinner").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(r.recipeId))}
                        </div>
                    ))}</div>
            <p>Snack</p>
            <div ref={snackDroppable} className="border border-black sizing">
                {filterMeals("snack").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(r.recipeId))}
                        </div>
                    ))}
            </div>
        </Container>
        </Col>
    )
}

DailyPlan.propTypes = {
    day: PropTypes.string.isRequired,
    mealPlanRecipes: PropTypes.arrayOf(
        PropTypes.shape({
            date: PropTypes.string.isRequired,
            mealType: PropTypes.string.isRequired,
            recipeId: PropTypes.number.isRequired,
        })
    ).isRequired,
    recipes: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.number.isRequired,
            title: PropTypes.string.isRequired,
        })
    ).isRequired,
};

export default DailyPlan;