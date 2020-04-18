// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function answerDiscrptionOnchange() {
    var descriptDOM = document.getElementById("des").value;
    var fileDOM = document.getElementById("fileinput");
    if (descriptDOM != "") {
        fileDOM.disabled = true;
    } else {
        fileDOM.disabled = false;
    }
}

function answerFileOnchange() {
    var descriptDOM = document.getElementById("des");
    var fileDOM = document.getElementById("fileinput").value;
    if (fileDOM != "") {
        descriptDOM.disabled = true;
    } else {
        descriptDOM.disabled = false;
    }
}