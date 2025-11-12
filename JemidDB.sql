-- Create database
CREATE DATABASE IF NOT EXISTS JemidDB;
USE JemidDB;

-- Clear table if it exists
DROP TABLE IF EXISTS Users;

-- Create Users table
CREATE TABLE Users (
    UserID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Example insert
INSERT INTO Users (Username, Email, PasswordHash)
VALUES ('JohnDoe', 'john@example.com', 'hashedlol');

-- Select all users
SELECT* FROM Users;

-- Example delete
DELETE FROM Users WHERE UserID = 2;
