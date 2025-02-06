import { Container } from "react-bootstrap";
import ShoppingListOverview from "../components/ShoppingLists/ShoppingListOverview/ShoppingListOverview";

function ShoppingLists() {
    return(
        <Container>
            <h1>Indkøbslister</h1>

            <Container>
                <ShoppingListOverview />
            </Container>
        </Container>
    )
}

export default ShoppingLists;