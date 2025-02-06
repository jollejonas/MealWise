import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import PropTypes from 'prop-types';
import { Container} from 'react-bootstrap';
import ShoppingListRow from '../ShoppingListRow/ShoppingListRow';

const fetchShoppingLists = async () => {
    const response = await axios.get('https://localhost:7104/api/shoppinglists');
    console.log('API response:', response.data); // Debug API-svaret
    return response.data;
}

function ShoppingListOverview() {

    const {data, isLoading, error } = useQuery({
        queryKey: ['shoppingLists'],
        queryFn: fetchShoppingLists
    });

    if (isLoading) return <p>Loading...</p>
    if (error) return <p>Something went wrong: {error.message}</p>

    if (!Array.isArray(data)) return <p>No shoppinglists found.</p>; // Håndter ikke-array-data
    
    return (
        <Container>
                {data.map((shoppingList) => (
                    <ShoppingListRow key={shoppingList.id} shoppingList={shoppingList} />
                ))}
        </Container>
    );
}

export default ShoppingListOverview

ShoppingListOverview.propTypes = {
    numMealPlans: PropTypes.number.isRequired,
    loadMore: PropTypes.bool.isRequired,
};