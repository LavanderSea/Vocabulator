// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function loadFile(control) {
    const  reader = new FileReader();
    const url = control.baseURI + "next";

    reader.onload = async function (event) {
        const result = await sendRequest(url, event.target.result);
        alert(result);
    };

    reader.onerror = function(event) {
        console.error(`Error with file reading. Code: ${event.target.error.code}`);
    };

    reader.readAsText(control.files[0]);
}

async function sendRequest(url, text) {

    const response = await fetch(url,
        {
            method: "POST",
            headers: new Headers({
                'Content-Type': "application/json",
                'Accept': "application/json"
            }),
            body: JSON.stringify(text)
        });

    return response.status === 200 ? await response.text() : undefined;
}
