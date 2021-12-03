
function chkData() {
    event.preventDefault();
    if (proForm.name1.value === "" || proForm.number1.value === "") {
        alert("Your must to fill both product name and product number!")
    } else if (proForm.number1.value.search(/\w{3}-\d{7}/) == -1 || proForm.number1.value.length < 10) {
        alert("input number of product must like (rrr-1234567)")
    } else if (isNaN(proForm.price1.value) || proForm.price1.value === "") {
        alert("Please enter the price of product and make sure make it number");
    } else if (proForm.year1.value !== 4 && proForm.year1.value % 2 != 0) {
        alert("the year must be a positive number and contain at least four number")
    } else if (proForm.price1.value < 0 || proForm.price1.value > 10000 && proForm.price1.value % 2 != 0) {
        alert("the price must be positive and between 0-10000")
    } else if (! /^[A-Za-z0-9]+$/.test(proForm.type1.value)) {
        alert("Please make sure if the field contain only letters and numbers")
    } else {
        window.location = "Result.html";
    }
}



