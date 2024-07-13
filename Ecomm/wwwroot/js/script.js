    document.querySelector('.toggle-password').addEventListener('click', function (e) {
        // Toggle the type attribute
        const passwordInput = document.getElementById('exampleInputPassword');
    const passwordType = passwordInput.getAttribute('type');
    if (passwordType === 'password') {
        passwordInput.setAttribute('type', 'text');
    e.target.classList.remove('fa-eye');
    e.target.classList.add('fa-eye-slash');
        } else {
        passwordInput.setAttribute('type', 'password');
    e.target.classList.remove('fa-eye-slash');
    e.target.classList.add('fa-eye');
        }
    });
