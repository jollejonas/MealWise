import axios from "axios";
import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { Container, Row, Col } from "react-bootstrap";
import "./MealPlanDetails.css"; // Hvis du vil tilføje styling separat

function MealPlanDetails() {
  let { id } = useParams();
  const [mealPlan, setMealPlan] = useState(null);
  const [loading, setLoading] = useState(true);
  const mealTypeLabels = ["Morgenmad", "Frokost", "Aftensmad", "Snack"];

  useEffect(() => {
    async function fetchMealPlan() {
      try {
        const response = await axios.get(`https://localhost:7104/api/mealplans/${id}`);
        setMealPlan(response.data);
      } catch (error) {
        console.error("Error fetching meal plan", error);
      } finally {
        setLoading(false);
      }
    }
    fetchMealPlan();
  }, [id]);

  if (loading) return <p>Loading...</p>;
  if (!mealPlan) return <p>No meal plan found.</p>;

  const createShoppingList = async () => {
    try {
      const response = await axios.post(`https://localhost:7104/api/shoppinglists/create/${id}`);
      console.log("Shopping list created", response.data);
      alert("Indkøbsliste oprettet");
    } catch (error) {
      console.error("Error creating shopping list", error);
      alert("Der opstod en fejl. Prøv igen senere.");
    }
  };

  // Gruppér måltider efter dato
  const mealsByDate = new Map();
  mealPlan.mealPlanRecipes.forEach((meal) => {
    if (!mealsByDate.has(meal.date)) {
      mealsByDate.set(meal.date, []);
    }
    mealsByDate.get(meal.date).push(meal);
  });

  // Lav en liste af datoer fra start til slut
  const startDate = new Date(mealPlan.startDate);
  const endDate = new Date(mealPlan.endDate);
  const dateList = [];
  for (let d = startDate; d <= endDate; d.setDate(d.getDate() + 1)) {
    dateList.push(new Date(d).toISOString().split("T")[0]); // Format: YYYY-MM-DD
  }

  return (
    <Container>
      <h1 className="text-center">{mealPlan.name}</h1>
      <Row>
        {dateList.map((date) => (
          <Col key={date} xs={12} sm={6} md={4} lg={3} className="mb-4">
            <div className="day-column">
              <h5 className="text-center">{new Date(date).toLocaleDateString()}</h5>
              {mealTypeLabels.map((mealType, index) => {
                const meals = mealsByDate.get(date)?.filter((m) => m.mealType === index) || [];
                return (
                  <div key={index} className="meal-slot">
                    <h6>{mealType}</h6>
                        <div className="meal-list">
                        {meals.length > 0 ? (
                          meals.map((meal) => (
                            console.log(meal),
                            <Link key={meal.id} to={`/opskrift/${meal.recipe.id}`} >
                              <div
                                className="meal-item"
                              >
                                <strong>{meal.recipe.title}</strong> ({meal.servingsOverride} pers.)
                              </div>
                            </Link>
                          ))
                        ) : (
                          <div className="empty-slot">Ingen måltid</div>
                        )}
                        </div>
                  </div>
                );
              })}
            </div>
          </Col>
        ))}
      </Row>
      <Row>
        <Col className="text-center">
          <button className="btn btn-primary" onClick={createShoppingList}>
            Opret indkøbsliste
          </button>
        </Col>
      </Row>
    </Container>
  );
}

export default MealPlanDetails;