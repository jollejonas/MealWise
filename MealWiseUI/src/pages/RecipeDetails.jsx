import Image from 'react-bootstrap/Image';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

function RecipeDetails() {
    let { id } = useParams();
    const [recipe, setRecipe] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function fetchRecipe() {
            try {
            const response = await axios.get(`https://localhost:7104/api/recipes/${id}`);
            setRecipe(response.data);
            setLoading(false);
        } catch (error) {
            console.error("Error fetching recipe", error);
        } finally {
            setLoading(false);
        }

    }
    fetchRecipe();
}, [id]);

if (loading) return <p>Loading...</p>;
if (!recipe) return <p>No recipe found.</p>;
    
if (recipe.imageUrl === null || recipe.imageUrl === "") {
    recipe.imageUrl = "https://fastly.picsum.photos/id/220/500/300.jpg?hmac=HVBg4X-ejEAUICcGyVo8L34MiRIAOWnfVqkXmr-W9e0";
} else if (!recipe.imageUrl.startsWith("http")) {
    recipe.imageUrl = ("https://localhost:7104/" + recipe.imageUrl);
}

    return (
    <div className='col'>
        <h1>{recipe.title}</h1>
        <Image rounded className="img-max" src={recipe.imageUrl} alt={recipe.title} />
        <p>{recipe.description}</p>
    </div>
    );
}

export default RecipeDetails;