import PropTypes from 'prop-types';
import axios from 'axios';

function ShoppingListRow({ shoppingList }) {

    const handleRowClick = () => {
        window.location.href = `/indkobsliste/${shoppingList.id}`;
    }
    const handleDeleteShoppingList = async (event) => {
        event.stopPropagation();
        try {
            const response = await axios.delete(`https://localhost:7104/api/shoppinglists/${shoppingList.id}`);
            console.log("Shopping list deleted", response.data);
            alert("Indkøbsliste slettet");
            window.location.reload();
        } catch (error) {
            console.error("Error deleting shopping list", error);
            alert("Der opstod en fejl. Prøv igen senere.");            
        }
    }

    return (
            <tr onClick={handleRowClick} style={{ cursor: 'pointer' }}>
                <td>{shoppingList.name}</td>
                <td><button onClick={handleDeleteShoppingList} className="btn btn-danger">Slet</button></td>
            </tr>
    )
}

export default ShoppingListRow;

ShoppingListRow.propTypes = {
    shoppingList: PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
    }).isRequired
};