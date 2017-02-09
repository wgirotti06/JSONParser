"use strict";

var app = app || {};

app.upload = function () {
    var uploadForm = $("#upload form");
    if (uploadForm.find(":file").val() === "") {
        uploadForm.find(".form-group").addClass("has-error");
        alert("No file selected.");
        return;
    }
    uploadForm.submit();
}