$(document).ready(function () {
    $('#hospitals_user').DataTable();
    $('#hospital_requests').DataTable();
    $('#hospitals_admin').DataTable();
    $('#hospitalAdmins_admin').DataTable();
    $('#hospitals_admin').DataTable();
    $('#patient_requests').DataTable();
    $('#doctors_hospAdmin').DataTable();
    $('#patients_hospAdmin').DataTable();
});
/*$(document).ready(function () {
    $('#doctors_hospAdmin').DataTable();
});
$(document).ready(function () {
    $('#doctors_hospAdmin').DataTable();
});*/


$('#selectDoctorPatient').on('change', function () {
    //alert(this.value);
    var email = this.value
    $.ajax({
        type: 'GET',
        url: '/Patient/MakeAppointment?doctorEmail=' + email,
        /*data: email,
        success: function () {
            location.reload();
        }*/
    })
        .done(function (result) {
            //window.location = "http://localhost:44305/Patient/MakeAppointment?doctorEmail=" + email;
            $('body').html(result);
        });
});

$(document).on('click', '.AppDateTimeDoc', function () {
    //alert("test");
    var tempInput = $('#dateTimeAppDocInput')[0];
    if (tempInput.value != "") {
        var tempId = $.trim(tempInput.value.replace(/\s\s+/g, ''));
        var tempButton = $('#' + tempId);
        tempButton.classList.remove("btn-secondary");
        tempButton.classList.add("btn-outline-secondary");
    }

    alert(this.parentElement.firstElementChild.innerText + " " + this.innerText);
    this.classList.remove("btn-outline-secondary");
    this.classList.add("btn-secondary");

    tempInput.value = this.parentElement.firstElementChild.innerText + " " + this.innerText;
    //tempInput.text(this.parentElement.firstElementChild.innerText + " " + this.innerText);
    
});

/*$('#btnDateTimeAppDoc').on('click', function () {
    alert("test");
});*/

/*function onClickAppButton(date, time) {
    $('#dateTimeAppDocInput').value = date + " " + time;
    //$('#dateTimeAppDocInput').value = val;
    $(this).removeClass('btn-outline-secondary')
    $(this).addClass('btn-secondary');
};*/
/*
 $('optionsforuser').on('change', function() {
  var form = $(this).closest('form');
  $.ajax({
    type: 'POST',
    url: 'urlHere',
    data: form.serialize(),
    complete: function(jqXHR, textStatus) {
      // Your callback code here
    }
  });
});

 */