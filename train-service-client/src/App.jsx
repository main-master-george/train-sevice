import React from 'react';
import {Route, BrowserRouter as Router, Routes} from "react-router-dom";
import Start from './pages/Start'
import Courses from "./pages/Courses";
import Auth from "./pages/Auth.jsx";
import Modules from "./pages/Modules.jsx";
import Pages from "./pages/Pages.jsx";

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Start />} />
                <Route path="/courses" element={<Courses />} />
                <Route path="/auth" element={<Auth/>} />
                <Route path="/modules/:courseId" element={<Modules/>} />
                <Route path="/pages/:moduleId" element={<Pages/>} />
            </Routes>
        </Router>
    );
};

export default App;
