<?php
session_start();

// 顯示錯誤訊息
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

$host = 'ns1';
$db = 'membership_db';
$user = 'root';
$pass = '1qaz@wsx';

// 建立資料庫連線
$conn = new mysqli($host, $user, $pass, $db);

// 檢查連線是否成功
if ($conn->connect_error) {
    die('資料庫連接失敗: ' . $conn->connect_error);
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = $conn->real_escape_string($_POST['username']);
    $password = $conn->real_escape_string($_POST['password']);

    // 確保SQL查詢語句無誤
    $query = "SELECT * FROM members WHERE username='$username' AND password='$password'";
    $result = $conn->query($query);

    // 檢查查詢是否成功
    if (!$result) {
        die('查詢失敗: ' . $conn->error);
    }

    if ($result->num_rows === 1) {
        $_SESSION['username'] = $username;
        echo "<script>
                localStorage.setItem('userName', '$username');
                window.location.href = '../index.html';
              </script>";
        exit();
    } else {
        header('Location: login.html?error=1');
        exit();
    }
}

$conn->close();
