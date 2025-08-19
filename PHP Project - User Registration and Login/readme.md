# README for User Registration and Login (PHP and SQLite)

## Overview
This project is a simple PHP-based user registration and login system using an SQLite database. It demonstrates practical use of PHP with SQLite3, secure password handling, and JSON-based API responses. Designed to be lightweight, test-friendly, and suitable for showcasing SQL skills in an application developer portfolio.

## Features
- **User Registration:** New users can register with a unique username and email.
- **Secure Password Handling:** Passwords are hashed using PHP’s `password_hash` for security.
- **User Login:** Registered users can log in with their credentials.
- **Case-Insensitive Duplicate Check:** Ensures usernames and emails are unique regardless of letter case.
- **JSON API Responses:** Communicates success or error states clearly for integration with frontend or testing.
- **SQLite Database:** Uses a standalone SQLite database file for simplicity and portability.
- **Automatic Table Creation:** The users table is created automatically if it doesn’t exist.

## Database
- This project uses **SQLite** only — no other database engines are required.
- The repository already includes an initial `db.db` file in the project directory:
  - This file will be used automatically by `controller.php`.
  - It includes example login credentials so you can test user login immediately.
- If the file is missing, it will be created automatically when the project is run
  (but it will be empty until you register new users).

## How to Use
1. Host the PHP files on a server or local environment with PHP and SQLite3 enabled.
2. Submit user registration or login forms (via POST) to `controller.php` with appropriate fields and an `action` parameter (`register` or `login`).
3. Receive JSON responses indicating success, errors, or user data.
4. The database file `db.db` will be created and updated in the project directory.

## Example API Commands (via POST)
- Registration:
  - `action=register`
  - `reg_username=yourusername`
  - `reg_password=yourpassword`
  - `email=youremail@example.com`
  
(the included `db.db` already contains a demo user matching the example credentials above, so you can log in right away. name: yourusername password: yourpassword)
  
- Login:
  - `action=login`
  - `username=yourusername`
  - `password=yourpassword`

## Code Structure
- **controller.php:** Main controller handling registration and login requests, database connection, and user management logic.
- **SQLite database (`db.db`):** Stores registered users with fields for ID, username, hashed password, email, and timestamps.
- **Functions:**
  - `getDB()`: Establishes SQLite connection.
  - `createUsersTable()`: Creates user table if missing.
  - `registerUser()`: Handles registration including duplicate checks and password hashing.
  - `loginUser()`: Manages login and password verification.
- Outputs consistent JSON responses for API consumption.

## How to Run
1. Ensure PHP 7+ with SQLite3 extension is installed and enabled on your server or local machine.
2. Place `controller.php` and any frontend files in a web-accessible directory.
3. Use an HTTP client, form submissions, or frontend code to POST requests to `controller.php`.
4. Inspect JSON responses for registration and login status.
5. Use SQLite database browsers or CLI tools to inspect `db.db` as needed (ensure no active locks).
