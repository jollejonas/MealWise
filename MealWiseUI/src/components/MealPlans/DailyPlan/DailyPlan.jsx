import { Container, Col } from "react-bootstrap"
import { useDroppable } from "@dnd-kit/core";
import PropTypes from 'prop-types';
import RemoveButton from "./RemoveButton";
import './DailyPlan.css';

function DailyPlan({ day, mealPlanRecipes, recipes, onRemoveMeal}) {
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
            <div ref={breakfastDroppable} className="droppable-area">
                    {filterMeals("breakfast").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={() => onRemoveMeal(r.recipeId, "breakfast", r.date)}
                            />
                        </div>
                    ))}
                    </div>
            <p>Frokost</p>
            <div ref={lunchDroppable} className="droppable-area">
                {filterMeals("lunch").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={() => onRemoveMeal(r.recipeId, "lunch", r.date)}
                            />
                        </div>
                    ))}</div>
            <p>Aftensmad</p>
            <div ref={dinnerDroppable} className="droppable-area">
                {filterMeals("dinner").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={() => onRemoveMeal(r.recipeId, "dinner", r.date)}
                            />
                        </div>
                    ))}</div>
            <p>Snack</p>
            <div ref={snackDroppable} className="droppable-area mb-2">
                {filterMeals("snack").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={() => onRemoveMeal(r.recipeId, "snack", r.date)}
                            />
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
    onRemoveMeal: PropTypes.func.isRequired,
};

export default DailyPlan;