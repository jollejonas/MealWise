import { Container, Col } from "react-bootstrap"
import { useDroppable } from "@dnd-kit/core";
import PropTypes from 'prop-types';
import './DailyPlan.css';

function DailyPlan({ day, meals, recipes }) {
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

    return (
        <Col>
        <Container className="border border-dark">
            <h4> { day }</h4>
            <p>Morgenmad</p>
            <div ref={breakfastDroppable} className="border border-black sizing">
                    {meals.breakfast.map((id, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(id))}
                        </div>
                    ))}
                    </div>
            <p>Frokost</p>
            <div ref={lunchDroppable} className="border border-black sizing">
                    {meals.lunch.map((id, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(id))}
                        </div>
                    ))}</div>
            <p>Aftensmad</p>
            <div ref={dinnerDroppable} className="border border-black sizing">
                    {meals.dinner.map((id, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(id))}
                        </div>
                    ))}</div>
            <p>Snack</p>
            <div ref={snackDroppable} className="border border-black sizing">
                    {meals.snack.map((id, index) => (
                        <div key={index} className="dropped-recipe">
                            {getRecipeName(Number(id))}
                        </div>
                    ))}
            </div>
        </Container>
        </Col>
    )
}

DailyPlan.propTypes = {
    day: PropTypes.string.isRequired,
    meals: PropTypes.shape({
        breakfast: PropTypes.arrayOf(PropTypes.number).isRequired,
        lunch: PropTypes.arrayOf(PropTypes.number).isRequired,
        dinner: PropTypes.arrayOf(PropTypes.number).isRequired,
        snack: PropTypes.arrayOf(PropTypes.number).isRequired,
    }).isRequired,
    recipes: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.number.isRequired,
            title: PropTypes.string.isRequired,
        })
    ).isRequired,
};

export default DailyPlan;