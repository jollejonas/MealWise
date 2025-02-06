import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { Row } from 'react-bootstrap';

function ShoppingListRow({ shoppingList }) {
    return (
        <Row>
            <Link to={`/indkobsliste/${shoppingList.id}`}> <p>Navn: {shoppingList.name} </p></Link>
        </Row>
    )
}

export default ShoppingListRow;

ShoppingListRow.propTypes = {
    shoppingList: PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
    }).isRequired
};