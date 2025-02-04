import { Container } from "react-bootstrap";
import MealPlanList from "../components/MealPlans/MealPlanList/MealPlanList"

function MealPlans() {
    return(
        <Container>
            <h1>Madplaner</h1>

            <Container>
                <MealPlanList numMealPlans={9} loadMore={true}/>
            </Container>
        </Container>
    )
}

export default MealPlans;