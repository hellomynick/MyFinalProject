import React from 'react'
import './App.css';
import  Navbar from './components/Navbar';
import {BrowserRouter as Router,Switch,Route} from 'react-router-dom'
import Home from "./pages/index"
import About from './pages/about';
function App() {
  return (
    <Router>
      <Navbar/>
      <Switch>
        <Route path="/" exact component={Home}/>
        <Route path="/about" exact component={About}/>
      </Switch>
    </Router>

  );
}

export default App;
