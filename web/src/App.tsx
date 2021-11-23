import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Navbar } from "./components/Navbar";
import { AboutPage } from "./pages/AboutPage";
import { TodosPage } from "./pages/TodosPage";

const App: React.FC = () => {
  return (
    <BrowserRouter>
      <Navbar></Navbar>
      <div className="container">
        <Routes>
          <Route path="/" element={<TodosPage />}></Route>
          <Route path="/about" element={<AboutPage />}></Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
};

export default App;
