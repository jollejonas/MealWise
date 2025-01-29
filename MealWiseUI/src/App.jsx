import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router'
import Home from './pages/Home'
import Recipes from './pages/Recipes.jsx'
import MainNavbar from './components/Navbar/Navbar.jsx'
import RecipeDetails from './components/Recipes/RecipeDetails/RecipeDetails.jsx'
import CreateRecipe from './pages/CreateRecipes.jsx'
import CreateMealPlan from './pages/CreateMealPlan.jsx'

function App() {

  return (
    <div className="container-fluid">
    <Router>
      <MainNavbar />
        <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/opskrifter" element={<Recipes />} />
        <Route path="/opret-opskrift" element={<CreateRecipe />} />
        <Route path="/opskrift/:id" element={<RecipeDetails />} />
        <Route path="/opret-madplan" element={<CreateMealPlan />} />
        </Routes>
      </Router>
    </div>
  )
}

export default App
