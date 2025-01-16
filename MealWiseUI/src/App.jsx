import './App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router'
import Home from './pages/Home'
import Opskrifter from './pages/Opskrifter.jsx'
import MainNavbar from './components/Navbar/Navbar.jsx'

function App() {

  return (
    <div className="container-fluid">
    <Router>
      <MainNavbar />
        <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/opskrifter" element={<Opskrifter />} />
        </Routes>
      </Router>
    </div>
  )
}

export default App
