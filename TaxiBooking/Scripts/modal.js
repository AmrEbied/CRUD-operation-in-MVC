var addValidator;
var updateValidator;
function addModalHide() {
    $('#addModal').modal('hide');
    addValidator.resetForm();
    document.getElementById("FormAddCar").reset();
}

function addModalShow() {
    addValidator.resetForm();
    $('#addModal').modal('show');
}

function updateModalHide() {
    $('#updateModal').modal('hide');
    updateValidator.resetForm();
    document.getElementById("FormUpdateCar").reset();
}

function updateModalShow(id) {
    updateValidator.resetForm();
    GetCarById(id);    
}