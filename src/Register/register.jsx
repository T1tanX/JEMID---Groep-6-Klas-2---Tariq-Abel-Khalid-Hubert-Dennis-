import React, { useState } from "react";
import { Link } from "react-router-dom";   // 👈 import Link
import "./register.css";

function Website1() {
    const [formData, setFormData] = useState({
        username: "",
        email: "",
        password: "",
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.id]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch("http://localhost:5000/register", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(formData),
            });

            const result = await response.json();
            alert(result.message || result.error);
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
                <form className="form-container" onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="username">Username:</label>
                        <input
                            type="text"
                            id="username"
                            value={formData.username}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="email">Email:</label>
                        <input
                            type="email"
                            id="email"
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
                            value={formData.password}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="button-container">
                        <button className="rounded-btn buttonSettings1" type="submit">
                            Register
                        </button>

                        {/* 👇 Add a Go to Login button */}
                        <Link to="/login">
                            <button
                                className="rounded-btn buttonSettings1"
                                type="button"
                                style={{ marginLeft: "10px" }}
                            >
                                Go to Login
                            </button>
                        </Link>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Website1;
