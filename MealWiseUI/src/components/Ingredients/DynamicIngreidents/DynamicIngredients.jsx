import { Form, Button, Row, Col } from 'react-bootstrap';
import PropTypes from 'prop-types';

function DynamicIngredients({ ingredients, setIngredients }) {

  // Håndtering af ændringer i felterne
  const handleIngredientChange = (index, field, value) => {
    const updatedIngredients = [...ingredients];
    updatedIngredients[index][field] = value;
    setIngredients(updatedIngredients);
  };

  // Tilføj ny ingrediens
  const addIngredient = () => {
    setIngredients([...ingredients, { name: '', quantity: '', unit: '' }]);
  };

  // Fjern en ingrediens
  const removeIngredient = (index) => {
    const updatedIngredients = ingredients.filter((_, i) => i !== index);
    setIngredients(updatedIngredients);
  };

  return (
    <>
      {ingredients.map((ingredient, index) => (
        <Row key={index} className="align-items-center mb-3">
          {/* Ingrediens navn */}
          <Col xs={5}>
            <Form.Control
              type="text"
              placeholder="Ingrediens"
              value={ingredient.name}
              onChange={(e) => handleIngredientChange(index, 'name', e.target.value)}
            />
          </Col>

          {/* Mængde */}
          <Col xs={3}>
            <Form.Control
              type="number"
              placeholder="Mængde"
              value={ingredient.quantity}
              onChange={(e) => handleIngredientChange(index, 'quantity', e.target.value)}
            />
          </Col>

          {/* Enhed */}
          <Col xs={3}>
            <Form.Select
              value={ingredient.unit}
              onChange={(e) => handleIngredientChange(index, 'unit', e.target.value)}
            >
              <option value="">Vælg måleenhed</option>
              <option value="g">g</option>
              <option value="kg">kg</option>
              <option value="ml">ml</option>
              <option value="dl">dl</option>
              <option value="l">l</option>
              <option value="stk">stk</option>
              <option value="tsk">tsk</option>
              <option value="spsk">spsk</option>
              <option value="fed">fed</option>
              <option value="efter behov">efter behov</option>
            </Form.Select>
          </Col>

          {/* Fjern ingrediens */}
          <Col xs={1}>
            <Button
              variant="danger"
              onClick={() => removeIngredient(index)}
              disabled={ingredients.length === 1} // Sørg for, at mindst én ingrediens forbliver
            >
              X
            </Button>
          </Col>
        </Row>
      ))}

      {/* Tilføj ingrediens */}
      <Button className="my-2" variant="primary" onClick={addIngredient}>
        Tilføj en ingrediens
      </Button>
      </>
  );
}
DynamicIngredients.propTypes = {
  ingredients: PropTypes.arrayOf(
    PropTypes.shape({
      name: PropTypes.string,
      quantity: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
      unit: PropTypes.string,
    })
  ).isRequired,
  setIngredients: PropTypes.func.isRequired,
};

export default DynamicIngredients;