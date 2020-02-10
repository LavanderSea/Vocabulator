// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function readFile(control) {
    var reader = new FileReader();

    reader.onload = function (event) {
        var contents = event.target.result;
        console.log("Содержимое файла: " + contents);
    };

    reader.onerror = function (event) {
        console.error("Файл не может быть прочитан! код " + event.target.error.code);
    };

    reader.readAsText(control.files[0]);
}