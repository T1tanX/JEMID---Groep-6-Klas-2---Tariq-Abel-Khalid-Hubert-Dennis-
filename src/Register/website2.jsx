import React from "react";
import { Link } from "react-router-dom";
import "./website2.css";

function handleLogin() {
    alert("Login successful");
}
function Website2() {
    return (
        <div className="page-container">
            <div className="roof"></div>
            <div className="bottom"></div>
            <hr className="top-hr" />
            <hr className="bottom-hr" />

            <div className="login-container">
                <form className="form-container">
                    <div className="form-group">
                        <label htmlFor="email">Email:</label>
                        <input type="email" id="email" placeholder="Enter your email" required />
                    </div>

                    <div className="form-group">
                        <label htmlFor="password">Password:</label>
                        <input type="password" id="password" placeholder="Enter your password" required />
                    </div>

                    <div className="button-container">
                        <Link to="/register">
                            <button type="button" className="rounded-btn buttonSettings1">
                                Go to register
                            </button>
                        </Link>
                        
                        <button type="button" className="rounded-btn buttonSettings1" onClick={handleLogin}>
                            Login
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Website2;

