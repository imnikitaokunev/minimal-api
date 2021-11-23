import React from "react";
import { NavLink } from "react-router-dom";

export const Navbar: React.FC = () => {
  return (
    <nav className="navbar navbar-expand navbar-light bg-light">
      <div className="container">
        <a href="/" className="navbar-brand">
          React + Typescript
        </a>
        <div className="d-flex">
          <ul className="ms-auto navbar-nav">
            <li className="nav-item">
              <NavLink className="nav-link active" aria-current="page" to="/">
                Todos
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/about">
                About
              </NavLink>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};
