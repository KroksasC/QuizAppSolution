import { BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import './App.css';
import QuizPage from './Components/QuizPage';
import DashboardPage from './Components/QuizDashboardPage';
import { Navbar } from "./Components/Navbar";
function App() {
    return (
        <Router>
            <div className="App">
                <Navbar />
                <Routes>
                    <Route  path="/" element={<QuizPage />} />
                    <Route path="/dashboard" element={<DashboardPage/>} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;