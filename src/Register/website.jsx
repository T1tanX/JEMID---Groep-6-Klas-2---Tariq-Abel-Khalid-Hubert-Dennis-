import React from "react";
import "./website.css"
import {Link} from "react-router-dom";

//This is the Register screen
function Website1(){
    return (
        <div className="page-container">
            <div className="roof"></div>
            <div className="bottom"></div>
            <hr className="top-hr" />
            <hr className="bottom-hr" />

            <div className="login-container">
                <form className="form-container">

                    {/* Role Selection */}
                    <div className="role-selection">
                        <label className="role-option">
                            <input type="radio" name="role" value="veilingmeester" defaultChecked />
                            <span>Veilingmeester</span>
                        </label>

                        <label className="role-option">
                            <input type="radio" name="role" value="aanvoerder" />
                            <span>Aanvoerder</span>
                        </label>

                        <label className="role-option">
                            <input type="radio" name="role" value="gebruiker" />
                            <span>Gebruiker</span>
                        </label>
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="username">Username:</label>
                        <input type="text" id="username" placeholder="Enter your username" required />
                    </div>

                    <div className="form-group">
                        <label htmlFor="email">Email:</label>
                        <input type="email" id="email" placeholder="Enter your email" required />
                    </div>

                    <div className="form-group">
                        <label htmlFor="password">Password:</label>
                        <input type="password" id="password" placeholder="Enter your password" required />
                    </div>

                    <div className="button-container">
                        <Link to="/login">
                            <button className="rounded-btn buttonSettings1" type="submit">
                                Register
                            </button>
                        </Link>

                        <Link to="/login">
                            <button className="rounded-btn buttonSettings1" type="button">
                                Go to login
                            </button>
                        </Link>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default Website1;

