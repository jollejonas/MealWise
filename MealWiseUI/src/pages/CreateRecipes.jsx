import RecipeForm from '../components/Recipes/RecipeForm/RecipeForm';
import { Container } from 'react-bootstrap';

function CreateRecipe() {
    return(
        <Container className="w-50">
            <RecipeForm />
        </Container>
    );
}
   
export default CreateRecipe;