import './RecipeList.css';
import RecipeCard from '../RecipeCard/RecipeCard';
import { useState } from 'react';

function RecipeList() {
    const [recipes, setRecipes] = useState(['Lasagna', 'Tacos', 'Salad']);
    const [newRecipe, setNewRecipe] = useState('');

    const addRecipe = () => {
        setRecipes([...recipes, newRecipe]);
        setNewRecipe('');
    }
    const removeRecipe = (index) => {
        const newRecipes = [...recipes];
        newRecipes.splice(index, 1);
        setRecipes(newRecipes);
    }

    return (
        <div>
            <h2>Opskrifter</h2>
            <ul>
                {recipes.map((recipe, index) => (
                    <div key={index}>
                    <RecipeCard name = {recipe}/>
                    <button onClick={() => removeRecipe(index)}>Fjern opskrift</button>
                    </div>
                ))}
            </ul>
            <input
                type='text'
                value={newRecipe}
                onChange={(e) => setNewRecipe(e.target.value)}
            />
            <button onClick={addRecipe}>Tilføj opskrift</button>
        </div>
    );
}

export default RecipeList