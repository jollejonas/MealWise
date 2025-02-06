import { Link, useParams } from "react-router-dom";
import { Container, Table } from "react-bootstrap";
import { useEffect, useState } from "react";
import axios from "axios";

function ShoppingListDetails() {
    let { id } = useParams();
    const [shoppingList, setShoppingList] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function fetchShoppingList() {
            try {
                const response = await axios.get(`https://localhost:7104/api/shoppinglists/${id}`);
                setShoppingList(response.data);
                setLoading(false);
            } catch (error) {
                console.error("Error fetching shoppinglist", error);
            } finally {
                setLoading(false);
            }
    }
    fetchShoppingList();
}, [id]);
console.log(shoppingList);
if (loading) return <p>Loading...</p>;
if (!shoppingList) return <p>No shopping list found.</p>;

  return (
    <Container>
      <h1>Indkøbsliste: {shoppingList.name}</h1>
      <Table>
        <thead>
            <tr>
                <th>Ingrediens</th>
                <th>Mængde</th>
            </tr>
        </thead>
        <tbody>
      {shoppingList.items.map((item) => 
        <tr key={item.id}>
            <td>{item.ingredientName}</td>
            <td>{item.quantity}{item.unit}</td>
        </tr>
      )}
      
      </tbody>
      </Table>
      <Link to="/indkobslister">Tilbage til indkøbslister</Link>
    </Container>
  );
}

export default ShoppingListDetails;