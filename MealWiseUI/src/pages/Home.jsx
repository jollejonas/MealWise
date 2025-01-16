import RecipeList from "../components/Recipes/RecipeList/RecipeList";

function Home() {
    return (
        <div className="container">
            <h1>Velkommen til MealWise</h1>
            <h2>Nyeste Opskrifter</h2>
            <div className="row">
                    <RecipeList numRecipes={3} loadMore={false}/>
            </div>
        </div>
    );
}

export default Home;