import { Link } from "react-router-dom";
import "./settings.css";
import NavBar from "../Navbar/NavBar.jsx";
import React from "react"; 

function SettingsPage() {
    return (
        <div className="settings-page">
            <header className="header">
                <NavBar/>
            </header>
            
            <h2>Settings</h2>

            <section>
                <h3>Account</h3>
                <button>Change Username</button>
                <button>Change Password</button>
                <button className="danger-btn">Delete Account</button>
            </section>

            <section>
                <h3>Preferences</h3>
                <button>Toggle Dark Mode</button>
                <button>Change Background</button>
            </section>

            <section>
                <h3>Notifications</h3>
                <label>
                    <input type="checkbox" />
                    Enable Email Notifications
                </label>
            </section>

            <div className="settings-footer">
                <Link to="/homepage">
                    <button className="rounded-btn">Back to Home</button>
                </Link>
                <button className="rounded-btn">Log Out</button>
            </div>
        </div>
    );
}

export default SettingsPage;

