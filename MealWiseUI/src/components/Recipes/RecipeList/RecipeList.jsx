import './RecipeList.css';
import RecipeCard from '../RecipeCard/RecipeCard';
import axios from "axios";
import { useQuery } from "@tanstack/react-query";

const fetchRecipes = async () => {
    const response = await axios.get('https://localhost:7104/api/recipes');
    console.log('API response:', response.data); // Debug API-svaret
    return response.data.$values;
}

function RecipeList() {
    const {data, isLoading, error } = useQuery({
        queryKey: ['recipes'],
        queryFn: fetchRecipes
});

    if (isLoading) return <p>Loading...</p>
    if (error) return <p>Something went wrong: {error.message}</p>

    if (!Array.isArray(data)) return <p>No recipes found.</p>; // Håndter ikke-array-data
    
    return (
        <div>
            <h2>Opskrifter</h2>
            <ul>
                {data.map((recipe) => (
                    <RecipeCard key={recipe.id} recipe={recipe} />
                ))}
            </ul>
        </div>
    );
}

export default RecipeList