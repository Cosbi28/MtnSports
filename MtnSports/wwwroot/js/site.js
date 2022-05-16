// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

datePickerId.min = new Date().toISOString().split("T")[0];


var currentDate = new Date();
currentDate.setDate(currentDate.getDate() + 1);

datePickerId2.min = currentDate.toISOString().split("T")[0];

datePickerId.value = new Date().toISOString().split("T")[0];

datePickerId2.value = currentDate.toISOString().split("T")[0];