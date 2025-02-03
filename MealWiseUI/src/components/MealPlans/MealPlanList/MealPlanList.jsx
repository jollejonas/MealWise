import './RecipeList.css';
import RecipeCard from '../RecipeCard/RecipeCard';
import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import PropTypes from 'prop-types';
import { Container, Row } from 'react-bootstrap';

const fetchRecipes = async () => {
    const response = await axios.get('https://localhost:7104/api/mealplans');
    console.log('API response:', response.data); // Debug API-svaret
    return response.data.$values;
}

function RecipeList({ numMealPlans, loadMore }) {

    const handleLoadMore = () => {
        numMealPlans += 3;
    };

    const {data, isLoading, error } = useQuery({
        queryKey: ['mealplans'],
        queryFn: fetchRecipes
    });

    if (isLoading) return <p>Loading...</p>
    if (error) return <p>Something went wrong: {error.message}</p>

    if (!Array.isArray(data)) return <p>No mealplans found.</p>; // Håndter ikke-array-data
    
    return (
        <Container>
            <Row>
                {data.slice(0,numMealPlans).map((mealPlan) => (
                    <RecipeCard key={mealPlan.id} recipe={mealPlan} />
                ))}
            </Row>
            {loadMore && <button className='btn btn-primary' onClick={handleLoadMore}>Load more</button>}
        </Container>
    );
}

export default RecipeList

RecipeList.propTypes = {
    numMealPlans: PropTypes.number.isRequired,
    loadMore: PropTypes.bool.isRequired,
};