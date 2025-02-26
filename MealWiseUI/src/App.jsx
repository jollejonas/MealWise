import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router'
import Home from './pages/Home'
import Recipes from './pages/Recipes.jsx'
import MainNavbar from './components/Navbar/Navbar.jsx'
import RecipeDetails from './pages/RecipeDetails.jsx'
import CreateRecipe from './pages/CreateRecipes.jsx'
import CreateMealPlan from './pages/CreateMealPlan.jsx'
import MealPlanDetails from './pages/MealPlanDetails.jsx'
import MealPlans from './pages/MealPlans.jsx'
import ShoppingLists from './pages/ShoppingLists.jsx'
import ShoppingListDetails from './pages/ShoppingListDetails.jsx'
import Login from './pages/Login.jsx'
import Logout from './pages/Logout.jsx'
import { isAuthenticated } from './services/authService.js'
import { Container } from 'react-bootstrap'

function App() {

  return (
    <Container fluid className="m-0">
    <Router>
      <MainNavbar />
        <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/opskrifter" element={<Recipes />} />
        <Route path="/opret-opskrift" element={<CreateRecipe />} />
        <Route path="/opskrift/:id" element={<RecipeDetails />} />
        <Route path="/madplaner" element={<MealPlans />} />
        <Route path="/opret-madplan" element={<CreateMealPlan />} />
        <Route path="/madplan/:id" element={<MealPlanDetails />} />
        <Route path="/indkobslister" element={<ShoppingLists />} />
        <Route path="/indkobsliste/:id" element={<ShoppingListDetails />} />

        <Route path="/login" element={<Login />} />
        <Route path="/logout" 
        element={isAuthenticated() ? <Logout /> : <Navigate to ="/login" />} />

        </Routes>
      </Router>
    </Container>
  )
}

export default App
