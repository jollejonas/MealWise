import RecipeList from "../components/Recipes/RecipeList/RecipeList";

function Home() {
    return (
        <div>
            <h1>Velkommen til MealWise</h1>
            <div className="row">
                <div className="col-md-6">
                    <RecipeList />
                </div>
            </div>
        </div>
    );
}

export default Home;