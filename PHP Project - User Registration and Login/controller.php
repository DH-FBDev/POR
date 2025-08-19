<?php
// Enable error reporting for debugging (remember to always remove on production!)
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

// connect to SQLite database
function getDB() {
    $dbPath = __DIR__ . '/db.db';  // absolute path - same folder as controller.php
    $db = new SQLite3($dbPath);
    $db->enableExceptions(true);
    return $db;
}

// make sure users table exists
function createUsersTable() {
    $db = getDB();
    $sql = <<<SQL
CREATE TABLE IF NOT EXISTS users (
    uID INTEGER PRIMARY KEY AUTOINCREMENT,
    username TEXT NOT NULL UNIQUE,
    password TEXT NOT NULL,
    email TEXT NOT NULL UNIQUE,
    cDate TEXT DEFAULT CURRENT_TIMESTAMP,
    iDate TEXT DEFAULT CURRENT_TIMESTAMP
)
SQL;
    $db->exec($sql);
}

// register user function with case-insensitive duplicate check and input normalization
function registerUser($username, $password, $email) {
    $db = getDB();

    // normalize input to lowercase
    $username = strtolower(trim($username));
    $email = strtolower(trim($email));

    // check for duplicates case-insensitively
    $stmt = $db->prepare('SELECT COUNT(*) as count FROM users WHERE LOWER(username) = :username OR LOWER(email) = :email');
    $stmt->bindValue(':username', $username, SQLITE3_TEXT);
    $stmt->bindValue(':email', $email, SQLITE3_TEXT);
    $result = $stmt->execute();
    $row = $result->fetchArray(SQLITE3_ASSOC);

    $count = $row ? $row['count'] : 0;

    if ($count > 0) {
        return ['success' => false, 'message' => 'Username or Email already exists.'];
    }

    // Hash password
    $passwordHash = password_hash($password, PASSWORD_DEFAULT);

    // insert new user with normalized username and email
    $stmt = $db->prepare('INSERT INTO users (username, password, email, cDate, iDate) VALUES (:username, :password, :email, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)');
    $stmt->bindValue(':username', $username, SQLITE3_TEXT);
    $stmt->bindValue(':password', $passwordHash, SQLITE3_TEXT);
    $stmt->bindValue(':email', $email, SQLITE3_TEXT);

    $result = $stmt->execute();
    if ($result) {
        return ['success' => true, 'message' => 'Registration successful.'];
    } else {
        return ['success' => false, 'message' => 'Registration failed.'];
    }
}

// login user function with input normalization
function loginUser($username, $password) {
    $db = getDB();

    $username = strtolower(trim($username));

    $stmt = $db->prepare('SELECT * FROM users WHERE LOWER(username) = :username');
    $stmt->bindValue(':username', $username, SQLITE3_TEXT);
    $result = $stmt->execute();

    $user = $result->fetchArray(SQLITE3_ASSOC);

    if (!$user) {
        return ['success' => false, 'message' => 'Invalid username or password.'];
    }

    if (password_verify($password, $user['password'])) {
        // Update last login timestamp
        $update = $db->prepare('UPDATE users SET iDate = CURRENT_TIMESTAMP WHERE uID = :id');
        $update->bindValue(':id', $user['uID'], SQLITE3_INTEGER);
        $update->execute();

        return ['success' => true, 'message' => 'Login successful.', 'user' => $user];
    } else {
        return ['success' => false, 'message' => 'Invalid username or password.'];
    }
}

// main controller logic
createUsersTable();  // create the table if it doesn't exist

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['action'])) {
        $action = $_POST['action'];

        if ($action === 'register') {
            $username = $_POST['reg_username'] ?? '';
            $password = $_POST['reg_password'] ?? '';
            $email = $_POST['email'] ?? '';
            $result = registerUser($username, $password, $email);
            echo json_encode($result);

        } elseif ($action === 'login') {
            $username = $_POST['username'] ?? '';
            $password = $_POST['password'] ?? '';
            $result = loginUser($username, $password);
            echo json_encode($result);

        } else {
            echo json_encode(['success' => false, 'message' => 'Invalid action']);
        }
    } else {
        echo json_encode(['success' => false, 'message' => 'No action specified']);
    }
} else {
    echo json_encode(['success' => false, 'message' => 'Invalid request method']);
}
