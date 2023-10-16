function companyAdd() {
    var company = new Object();
    company.CompanyName = $('#txtSirketAd_Add').val();
    company.Phone = $('#txtSirketPhone_Add').val();
    company.Address = $('#txtSirketAddress_Add').val();
    company.Email = $('#txtSirketEmail_Add').val();

    $.ajax({
        url: '/AddCompany',
        type: 'post',
        data: company,
    success: function (response) {
        // Handle success here
        location.reload();
    },
    error: function (err) {
        // Handle errors here
        alert("Error adding company");
    }
});
	
}

function companyRemove(id) {
    $.ajax({
        url: "/RemoveCompany/" + id,
        type: "post",
        data: id,
        success: function (response) {
            // Handle success here
            location.reload();
        },
        error: function (err) {
            // Handle errors here
            alert("Error adding company");
        }
    });
}






