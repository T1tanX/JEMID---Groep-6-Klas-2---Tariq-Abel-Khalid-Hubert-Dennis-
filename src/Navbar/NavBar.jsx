import React from "react";
import { Link } from "react-router-dom";
import "./NavBar.css";

function NavBar() {
    return (
        <header className="navbar-container">
            <div className="brand">
                <div className="avatar">😊</div>
                <div>
                    <div className="subtext">earchannel</div>
                    <div className="logo">PlantBid</div>
                </div>
            </div>

            <nav className="nav">
                <Link to="/homepage">Home</Link>
                <Link to="/veilingen">Mijn veilingen</Link>
                <Link to="/gebruiker">Gebruiker</Link>
                <Link to="/settings">Settings</Link>
                <Link to="/contact">Contact</Link>
            </nav>
        </header>
    );
}

export default NavBar;
