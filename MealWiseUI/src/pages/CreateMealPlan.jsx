import { Container } from 'react-bootstrap'
import { DndContext } from '@dnd-kit/core'
import { useState } from 'react'
import { useQuery } from "@tanstack/react-query";
import DailyPlan from '../components/MealPlans/DailyPlan/DailyPlan'
import DraggableRecipe from '../components/MealPlans/DraggableRecipe/DraggableRecipe';
import axios from 'axios';

const initialMealPlan = {
    Mandag: { breakfast: [], lunch: [], dinner: [], snack: [] },
    Tirsdag: { breakfast: [], lunch: [], dinner: [], snack: [] },
    Onsdag: { breakfast: [], lunch: [], dinner: [], snack: [] },
    Torsdag: { breakfast: [], lunch: [], dinner: [], snack: [] },
    Fredag: { breakfast: [], lunch: [], dinner: [], snack: [] },
    Lørdag: { breakfast: [], lunch: [], dinner: [], snack: [] },
    Søndag: { breakfast: [], lunch: [], dinner: [], snack: [] },
};

const fetchRecipes = async () => {
    const response = await axios.get('https://localhost:7104/api/recipes');
    console.log('API response:', response.data); // Debug API-respons

    // Ensure IDs are numbers
    const recipes = response.data.$values || response.data;
    return recipes.map((recipe) => ({
        ...recipe,
        id: Number(recipe.id), // Convert ID to number
    }));
};

function CreateMealPlan() {
    const [mealPlan, setMealPlan] = useState(initialMealPlan);


    const {data, isLoading, error } = useQuery({
        queryKey: ['recipes'],
        queryFn: fetchRecipes
    });

    console.log(data);

    const handleDragEnd = (event) => {
        const { active, over } = event;
        if(over) {
            const [day, mealType] = over.id.split('-');
            const recipeId = parseInt(active.id.split('-')[1], 10); // Convert to number

            setMealPlan((prev) => {
                const updatedDay = { ...prev[day] };
                updatedDay[mealType] = [...updatedDay[mealType], recipeId];
                return { ...prev, [day]: updatedDay };
            });
        }
    };
    
    if (isLoading) return <p>Loading...</p>
    if (error) return <p>Something went wrong: {error.message}</p>

    if (!Array.isArray(data)) return <p>No recipes found.</p>; // Håndter ikke-array-data

    return (    
        <Container>
            <DndContext onDragEnd={handleDragEnd}>
            <div style={{ display: "flex" }}>
                <div style={{ width: "200px", marginRight: "20px" }}>
                    <h3>Favoritter</h3>
                    {data.map((recipe) => (
                        <DraggableRecipe key={recipe.id} recipeId={recipe.id} name={recipe.title} />
                    ))}
                </div>

                
                <div style={{ flexGrow: 1, display: "grid", gridTemplateColumns: "repeat(7, 1fr)", gap: "10px" }}>
                    {Object.keys(mealPlan).map((day) => (
                        <DailyPlan key={day} day={day} meals={mealPlan[day]} recipes={data} />
                    ))}
                </div>
            </div>
            </DndContext>
        </Container>
    );
}

export default CreateMealPlan;