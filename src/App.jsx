import Website from "./Register/website.jsx"
import Website2 from "./Register/website2.jsx"
import Website3 from "./Homepage/home.jsx"
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";


function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Website />} />
                <Route path="/register" element={<Website />} />
                <Route path="/login" element={<Website2 />} />
                <Route path="/homepage" element={<Website3 />} />
            </Routes>
        </Router>
    );
}

export default App
