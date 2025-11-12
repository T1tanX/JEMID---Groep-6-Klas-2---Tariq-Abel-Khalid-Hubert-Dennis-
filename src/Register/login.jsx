import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import "./login.css";

function Website2() {
    const [formData, setFormData] = useState({
        email: "",
        password: "",
    });
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.id]: e.target.value });
    };

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch("http://localhost:5000/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(formData),
            });

            const result = await response.json();

            if (response.ok) {
                alert(result.message);
                navigate("/homepage"); // 👈 redirect to homepage
            } else {
                alert(result.error);
            }
        } catch (err) {
            alert("Something went wrong");
            console.error(err);
        }
    };

    return (
        <div className="page-container">
            <div className="roof"></div>
            <div className="bottom"></div>
            <hr className="top-hr" />
            <hr className="bottom-hr" />

            <div className="login-container">
                <form className="form-container" onSubmit={handleLogin}>
                    <div className="form-group">
                        <label htmlFor="email">Email:</label>
                        <input
                            type="email"
                            id="email"
                            placeholder="Enter your email"
                            value={formData.email}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="password">Password:</label>
                        <input
                            type="password"
                            id="password"
                            placeholder="Enter your password"
                            value={formData.password}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="button-container">
                        <Link to="/register">
                            <button type="button" className="rounded-btn buttonSettings1">
                                Go to register
                            </button>
                        </Link>

                        <button type="submit" className="rounded-btn buttonSettings1">
                            Login
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Website2;
