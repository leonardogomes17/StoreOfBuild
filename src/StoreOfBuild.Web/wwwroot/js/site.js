function formOnFail(error){

    if (error && error.status == 500)
        toastr.error(error.responseText);
}

function formOnSucessProduct(data){
    if (data && data.status == 200)
        window.location = window.location.protocol + '//' + window.location.host + '/Product/ListProducts';
}

function formOnSucess(data){
    if (data && data.status == 200)
        window.location = window.location.protocol + '//' + window.location.host + '/Category/';
}