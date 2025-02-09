import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import PropTypes from 'prop-types';
import { Container, Table} from 'react-bootstrap';
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
            <Table>
                <thead>
                    <tr>
                        <th>Navn</th>
                        <th>Slet</th>
                    </tr>
                </thead>
                <tbody>
                {data.map((shoppingList) => (
                    <ShoppingListRow key={shoppingList.id} shoppingList={shoppingList} />
                ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default ShoppingListOverview

ShoppingListOverview.propTypes = {
    numMealPlans: PropTypes.number.isRequired,
    loadMore: PropTypes.bool.isRequired,
};