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

$('#selectDoctorPatient').on('change', function () {
    //alert(this.value);
    var email = this.value
    $.ajax({
        type: 'GET',
        url: '/Patient/MakeAppointment?doctorEmail=' + email
    })
        .done(function (result) {
            $('body').html(result);
        });
});

$('#selectDoctor').on('change', function () {
    //alert(this.value);
    var email = this.value
    var patEmail = $('#selectPatient')[0].value;
    $.ajax({
        type: 'GET',
        url: '/HospitalAdmin/MakeAppointment?doctorEmail=' + email + "&patientEmail=" + patEmail
    })
        .done(function (result) {
            $('body').html(result);
        });
});

$('#schedulesId').on('change', function () {

    $('.scheduleInfoDiv').addClass('d-none');

    var id = $(this)[0].value;

    $('#schedule' + id).removeClass('d-none');
});
//schedulesId
//classForDays

$(document).on('click', '.AppDateTimeDoc', function () {
    //alert("test");
    var tempInput = $('#dateTimeAppDocInput')[0];
    if (tempInput.value != "") {
        $('.AppDateTimeDoc').removeClass('btn-secondary');
        $('.AppDateTimeDoc').addClass('btn-outline-secondary');
    }

    this.classList.remove("btn-outline-secondary");
    this.classList.add("btn-secondary");

    tempInput.value = this.parentElement.firstElementChild.innerText + " " + this.innerText;
    
});

/*$('#btnDateTimeAppDoc').on('click', function () {
    alert("test");
});*/

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