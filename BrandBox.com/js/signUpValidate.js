function ValidateForm() {
    var name = document.forms["SignUpForm"]["name"].value;

    if (name == null || name == "") {
        document.getElementsByName("name")[0].placeholder = "Please Enter Name";
        document.forms["SignUpForm"]["name"].style.outline = "5px solid #ff0000";
        document.forms["SignUpForm"]["name"].focus();
        return false;
    }

    else
        document.write("Aa");
}
