import Register from "./Register/register.jsx"
import Login from "./Register/login.jsx"
import Homepage from "./Homepage/home.jsx"
import SettingsPage from "./Settings/settings.jsx"
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";


function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Register />} />
                <Route path="/register" element={<Register />} />
                <Route path="/login" element={<Login />} />
                <Route path="/homepage" element={<Homepage />} />
                <Route path="/settings" element={<SettingsPage />} />
            </Routes>
        </Router>
    );
}

export default App
