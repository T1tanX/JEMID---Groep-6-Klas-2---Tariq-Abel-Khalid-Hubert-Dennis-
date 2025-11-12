// backend/server.js
import express from "express";
import mysql from "mysql2";
import cors from "cors";
import bodyParser from "body-parser";
import bcrypt from "bcrypt";

const app = express();
app.use(cors());
app.use(bodyParser.json());

// ✅ MySQL connection
const db = mysql.createConnection({
    host: "localhost",
    user: "root",         // your MySQL username
    password: "24074209190344",         // your MySQL password
    database: "JemidDB",  // your DB name
});

// ✅ Route for registration
app.post("/register", async (req, res) => {
    const { username, email, password } = req.body;

    // simple validation
    if (!username || !email || !password)
        return res.status(400).json({ error: "All fields required" });

    try {
        const hashedPassword = await bcrypt.hash(password, 10);
        const sql =
            "INSERT INTO Users (Username, Email, PasswordHash) VALUES (?, ?, ?)";
        db.query(sql, [username, email, hashedPassword], (err, result) => {
            if (err) {
                console.error("Error inserting user:", err);
                return res.status(500).json({ error: "Database error" });
            }
            res.status(201).json({ message: "User registered successfully!" });
        });
    } catch (err) {
        console.error("Error hashing password:", err);
        res.status(500).json({ error: "Server error" });
    }
});

app.post("/login", (req, res) => {
    const { email, password } = req.body;

    if (!email || !password)
        return res.status(400).json({ error: "Email and password required" });

    const sql = "SELECT * FROM Users WHERE Email = ?";
    db.query(sql, [email], async (err, results) => {
        if (err) {
            console.error("Error querying database:", err);
            return res.status(500).json({ error: "Database error" });
        }

        if (results.length === 0) {
            return res.status(401).json({ error: "Invalid email or password" });
        }

        const user = results[0];

        // Compare hashed password
        const match = await bcrypt.compare(password, user.PasswordHash);

        if (!match) {
            return res.status(401).json({ error: "Invalid email or password" });
        }

        // If correct
        res.json({ message: "Login successful" });
    });
});

// ✅ Start server
app.listen(5000, () => console.log("Server running on port 5000"));
