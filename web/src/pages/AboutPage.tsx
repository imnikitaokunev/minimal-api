import React from "react";
import { useNavigate } from "react-router-dom";

export const AboutPage: React.FC = () => {
  const navigate = useNavigate();
  return (
    <>
      <h1>About us</h1>
      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Harum laborum deleniti nulla. Sed asperiores itaque
        eveniet recusandae deserunt possimus quis unde suscipit quaerat molestias ea temporibus incidunt quos, quasi
        blanditiis.
      </p>
      <button className="btn btn-light" onClick={() => navigate("/")}>
        Back to todos
      </button>
    </>
  );
};
