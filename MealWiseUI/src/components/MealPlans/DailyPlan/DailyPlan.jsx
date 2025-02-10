import { Container, Col } from "react-bootstrap"
import { useDroppable } from "@dnd-kit/core";
import { useState } from "react";
import { format, parseISO } from 'date-fns';
import PropTypes from 'prop-types';
import RemoveButton from "./RemoveButton";
import SelectRecipeModal from "../SelectRecipeModal/SelectRecipeModal";
import './DailyPlan.css';

const formatToDanishDate = (date) => format(date, 'dd-MM-yyyy');

const mealTypeEnum = {
    breakfast: 0,
    lunch: 1,
    dinner: 2,
    snack: 3,
};

function DailyPlan({ date, mealPlanRecipes, recipes, onRemoveMeal, onAddMeal}) {
    const [showModal, setShowModal] = useState(false);
    const [selectedMealType, setSelectedMealType] = useState("");

    
    const displayDate = formatToDanishDate(parseISO(date));

    const {setNodeRef: breakfastDroppable} = useDroppable({
        id: `${displayDate}-breakfast`,
    });
    const {setNodeRef: lunchDroppable} = useDroppable({
        id: `${displayDate}-lunch`,
    });
    const {setNodeRef: dinnerDroppable} = useDroppable({
        id: `${displayDate}-dinner`,
    });
    const {setNodeRef: snackDroppable} = useDroppable({
        id: `${displayDate}-snack`,
    });

    const getRecipeName = (id) => {
        const recipe = recipes.find((recipe) => recipe.id === id);
        return recipe ? recipe.title : "Ukendt opskrift";
    };

    const filterMeals = (mealType) => {
        const mealTypeValue = mealTypeEnum[mealType.toLowerCase()];
        const filtered = mealPlanRecipes.filter((r) => r.mealType === mealTypeValue);
        return filtered;
    }

    const handleOpenModal = (mealType) => {
        setSelectedMealType(mealType);
        setShowModal(true);
    };

    const handleSelectRecipe = (recipe) => {
        setShowModal(false);
        onAddMeal(date, selectedMealType, recipe.id);
    };

    return (
        <Col>
        <Container className="border border-dark">
            <h5> { displayDate }</h5>
            <p>Morgenmad</p>
            <div ref={breakfastDroppable} className="droppable-area" onClick={() => handleOpenModal("breakfast")}>
                    {filterMeals("breakfast").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={(event) => {
                                event.stopPropagation(); 
                                onRemoveMeal(r.recipeId, "breakfast", r.date);
                                }}
                            />
                        </div>
                    ))}
                    </div>
            <p>Frokost</p>
            <div ref={lunchDroppable} className="droppable-area" onClick={() => handleOpenModal("lunch")}>
                {filterMeals("lunch").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={(event) => {
                                event.stopPropagation(); 
                                onRemoveMeal(r.recipeId, "lunch", r.date);
                            }}
                            />
                        </div>
                    ))}</div>
            <p>Aftensmad</p>
            <div ref={dinnerDroppable} className="droppable-area" onClick={() => handleOpenModal("dinner")}>
                {filterMeals("dinner").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={(event) => {
                                event.stopPropagation(); 
                                onRemoveMeal(r.recipeId, "dinner", r.date);
                            }}
                            />
                        </div>
                    ))}</div>
            <p>Snack</p>
            <div ref={snackDroppable} className="droppable-area mb-2" onClick={() => handleOpenModal("snack")}>
                {filterMeals("snack").map((r, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(r.recipeId)}
                            <RemoveButton 
                                onClick={(event) => {
                                event.stopPropagation(); 
                                onRemoveMeal(r.recipeId, "snack", r.date);
                            }}
                            />
                        </div>
                    ))}
            </div>
        </Container>
        <SelectRecipeModal
            show={showModal}
            onClose={() => setShowModal(false)}
            onRecipeSelect={handleSelectRecipe}
            recipes={recipes}
        />
        </Col>
    )
    
}

DailyPlan.propTypes = {
    date: PropTypes.string.isRequired,
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
    onAddMeal: PropTypes.func.isRequired,
};

export default DailyPlan;