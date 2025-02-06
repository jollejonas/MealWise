import { Container, Row } from "react-bootstrap";
import RecipeList from "../components/Recipes/RecipeList/RecipeList";

function Recipes() {
    return (
        <Container>
            <h1>Opskrifter</h1>
            <Row>
                <RecipeList numRecipes={9} loadMore={true}/>
            </Row>
        </Container>
    );
}

export default Recipes;