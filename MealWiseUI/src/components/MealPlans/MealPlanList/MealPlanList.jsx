import MealPlanRow from '../MealPlanRow/MealPlanRow';
import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import PropTypes from 'prop-types';
import { Container} from 'react-bootstrap';

const fetchMealPlans = async () => {
    const response = await axios.get('https://localhost:7104/api/mealplans');
    console.log('API response:', response.data); // Debug API-svaret
    return response.data;
}

function MealPlanList({ numMealPlans, loadMore }) {

    const handleLoadMore = () => {
        numMealPlans += 3;
    };

    const {data, isLoading, error } = useQuery({
        queryKey: ['mealplans'],
        queryFn: fetchMealPlans
    });

    if (isLoading) return <p>Loading...</p>
    if (error) return <p>Something went wrong: {error.message}</p>

    if (!Array.isArray(data)) return <p>No mealplans found.</p>; // Håndter ikke-array-data
    
    return (
        <Container>
                {data.slice(0,numMealPlans).map((mealPlan) => (
                    <MealPlanRow key={mealPlan.id} mealPlan={mealPlan} />
                ))}
            {loadMore && <button className='btn btn-primary' onClick={handleLoadMore}>Load more</button>}
        </Container>
    );
}

export default MealPlanList

MealPlanList.propTypes = {
    numMealPlans: PropTypes.number.isRequired,
    loadMore: PropTypes.bool.isRequired,
};