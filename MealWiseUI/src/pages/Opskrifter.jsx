import RecipeList from "../components/Recipes/RecipeList/RecipeList";

function Opskrifter() {
    return (
        <div className="container">
            <h1>Opskrifter</h1>
            <div className="row">
                <RecipeList numRecipes={9} loadMore={true}/>
            </div>
        </div>
    );
}

export default Opskrifter;