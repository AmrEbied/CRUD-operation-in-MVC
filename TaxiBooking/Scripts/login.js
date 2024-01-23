function Submit() {
    var dataObject = JSON.stringify(
        {
            logIn: {
                'UserName': $('#userName').val(),
                'Password': $('#password').val()
            }
        });
    $.ajax({
        url: "/User/LogIn",
        type: "POST",
        contentType: 'application/json',
        data: dataObject,
        success: function (result) {
            console.log(result);
        },
        failure: function (info) {
            console.log(info);
        }
    });

}