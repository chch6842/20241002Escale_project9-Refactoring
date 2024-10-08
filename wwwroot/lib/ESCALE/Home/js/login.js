document.getElementById('loginForm').addEventListener('submit', function(event) {
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var errorMessage = document.getElementById('errorMessage');

    if (!username || !password) {
        errorMessage.textContent = '請填寫所有欄位';
        event.preventDefault();
    } else {
        errorMessage.textContent = '';
    }
});
