function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == '') {
        return 'First Name should not be empty!';
    }
    else {  return ''; }
}

function IsFirstNameInValid() {
    if (document.getElementById('TxtFName').value.indexOf("@") != -1) {
        return 'First Name should not contain @';
    }
    else { return ''; }
}

function IsLastNameInvalid() {
    if (document.getElementById('TxtLName').value.length >= 5) {
        return 'Last Name length should not contain more than 5 character!';
    }
    else { return ''; }
}

function IsSalaryEmpty() {
    if (document.getElementById('TxtSalary').value == "") {
        return 'Salary should not be empty';
    }
    else { return ""; }
}
function IsSalaryInValid() {
    if (isNaN(document.getElementById('TxtSalary').value)) {
        return 'Enter valid salary';
    }
    else { return ""; }
}

function IsValid() {
    var FirstNameEmptyMessage = IsFirstNameEmpty();
    var FirstNameInvalidMessage = IsFirstNameInValid();
    var LastNameInvalidMessage = IsLastNameInvalid();
    var SalaryEmptyMessage = IsSalaryEmpty();
    var SalaryInvalidMessage = IsSalaryInValid();

    var FinalErrorMessage = 'Errors:';
    if (FirstNameEmptyMessage != '') {
        FinalErrorMessage += '\n' + FirstNameEmptyMessage;
    }

    if (FirstNameInvalidMessage != '') {
        FinalErrorMessage += '\n' + FirstNameInvalidMessage;
    }

    if (LastNameInvalidMessage != '') {
        FinalErrorMessage += '\n' + LastNameInvalidMessage;
    }

    if (SalaryEmptyMessage != '') {
        FinalErrorMessage += '\n' + SalaryEmptyMessage;
    }
    if (SalaryInvalidMessage != '') {
        FinalErrorMessage += '\n' + SalaryInvalidMessage;
    }

    if (FinalErrorMessage != 'Errors:') {
        alert(FinalErrorMessage);
        return false;
    }
    else {
        return true;
    }

}
