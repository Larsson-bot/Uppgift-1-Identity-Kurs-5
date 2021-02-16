function validateForm() {
    var x = document.Register.FirstName.value;
    if (x == "") {
        alert("First name must be filled out!")
        document.Register.FirstName.focus();
        return false;
    }
    if (document.Register.LastName.value == "") {
        alert("Last name must be filled out!!");
        document.Register.LastName.focus();
        return false;
    }
    if (document.Register.Email.value == "" || !/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(Register.Email.value)) {
        alert("Invalid email! Please type a valid email");
        document.Register.Email.focus();
        return false;
    }
    if (document.Register.Password.value.length < 6 || document.Register.Password.value != document.Register.ConfirmPassword.value) {
        alert("Password must be atleast 6 characters long and match!");
        return false;
    }
    if (document.Register.UserRole.value == 0) {
        alert("Choose a role!");
        return false;
    }

    
    return true;
 
}