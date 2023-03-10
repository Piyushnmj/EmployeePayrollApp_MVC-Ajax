$(document).ready(function () {
    ShowEmployeeData();
})

//Show employee details in Index Page
function ShowEmployeeData() {
    $.ajax({
        url: '/Employee/GetAllEmployees',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.empID + '</td>';
                object += '<td>' + item.empName + '</td>';
                //object += '<td>' + '<img src="@Url.Content(item.profileImg)"/>' + '</td>';
                object += '<td>' + item.profileImg + '</td>';
                object += '<td>' + item.gender + '</td>';
                object += '<td>' + item.department + '</td>';
                object += '<td>' + item.salary + '</td>';
                object += '<td>' + item.startDate + '</td>';
                object += '<td>' + item.notes + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.empID + ')">Edit</a> || <a href="#" class="btn btn-danger" onclick="Delete(' + item.empID + ')">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Cannot get data");
        }
    });
};

//Add employee popup
$('#btnAddEmployee').click(function () {
    //ClearTextBox();
    $('#EmployeeModal').modal('show');
    $('#empId').hide();
    $('#AddEmployeebtn').show();
    $('#Updatebtn').hide();
    $('#heading').text('Add Employee');
})

function AddEmployee() {
    debugger
    var objData = {
        EmpName: $('#name').val(),
        //ProfileImg: $('#image').val(),
        ProfileImg: $('input[name="img"]:checked').val(),
        //Gender: $('#gender').val(),
        Gender: $('input[name="gender"]:checked').val(),
        Department: $('#department').val(),
        Salary: $('#salary').val(),
        StartDate: $('#startdate').val(),
        Notes: $('#notes').val()
    }
    $.ajax({
        url: '/Employee/AddEmployee',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded; charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Data saved');
            ClearTextBox();
            ShowEmployeeData();
            HideModalPopUp();
        },
        error: function () {
            alert('Data not saved');
        }
    });
}

function Edit(id) {
    debugger
    $.ajax({
        url: '/Employee/EditDetails?id=' + id,
        type: 'Get',
        contentType: 'application/json; charset=utf-8;',
        dataType: 'json',
        success: function (response) {
            $('#EmployeeModal').modal('show');
            $('#employeeId').val(response.empID);
            $('#name').val(response.empName);
            $('#image').val(response.profileImg);
            $('#gender').val(response.gender);
            $('#department').val(response.department);
            $('#salary').val(response.salary);
            $('#startdate').val(response.startDate);
            $('#notes').val(response.notes);
            //$('#AddEmployeebtn').css('display', 'none');
            //$('#Updatebtn').css('display', 'block');
            $('#AddEmployeebtn').hide();
            $('#Updatebtn').show();
            $('#heading').text('Update Details');
        },
        error: function () {
            alert('Data not saved');
        }
    });
}

function Update() {
    debugger
    var objData = {
        EmpID: $('#employeeId').val(),
        EmpName: $('#name').val(),
        ProfileImg: $('#image').val(),
        Gender: $('#gender').val(),
        Department: $('#department').val(),
        Salary: $('#salary').val(),
        StartDate: $('#startdate').val(),
        Notes: $('#notes').val()
    }
    $.ajax({
        url: '/Employee/UpdateDetails',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded; charset=utf-8;',
        dataType: 'json',
        success: function () {
            debugger
            alert('Data saved');
            ClearTextBox();
            ShowEmployeeData();
            HideModalPopUp();
        },
        error: function () {
            alert('Data not saved');
        }
    });
}

function Delete(id) {
    debugger
    $.ajax({
        url: '/Employee/DeleteDetails?id=' + id,
        success: function () {
            alert('Data deleted');
            ShowEmployeeData();
        },
        error: function () {
            alert('Data not deleted');
        }
    });
}

function HideModalPopUp() {
    $('#EmployeeModal').modal('hide');
}

function ClearTextBox() {
    $('#employeeId').val('');
    $('#name').val('');
    $('#image').val('');
    $('#gender').val('');
    $('#department').val('');
    $('#salary').val('');
    $('#startdate').val('');
    $('#notes').val('');
}