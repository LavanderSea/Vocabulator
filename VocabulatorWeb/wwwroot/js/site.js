async function loadFile(control) {
    const reader = new FileReader();
    const url = control.baseURI.replace("load", "next");

    reader.onload = async function(event) {
        await sendRequest(url, "POST", event.target.result);
    };

    reader.onerror = function(event) {
        console.error(`Error with file reading. Code: ${event.target.error.code}`);
    };

    reader.readAsText(control.files[0]);
}

async function sendRequest(url, method, text) {

    const response = await fetch(url,
        {
            method: method,
            headers: new Headers({
                'Content-Type': "application/json",
                'Accept': "application/json"
            }),
            body: JSON.stringify(text)
        });

    return response.status === 200 ? await response.text() : undefined;
}

async function setDictionaryType(url, type) {
    await sendRequest(url + "setDictionaryType", "PUT", type);
}

async function sendWords(url) {
    const word =
        "[{\"value\": \"soap\",\"partOfSpeech\": \"noun\",\"transcription\": \"ˈsōp\",\"definition\": \"test def\",\"example\": \"test example\"}" +
            ",{\"value\": \"HORSE\",\"partOfSpeech\": \"HORSE\",\"transcription\": \"ˈsōp\",\"definition\": \"test def1\",\"example\": \"test example1\"}]";
    const text = await sendRequest(url, "POST", word);
    prepareFileToDownload(text);
}

function prepareFileToDownload(text) {
    const resultText = text.substring(1, text.length - 1).replace(/\\r\\n/gi, "\n");
    const data = new Blob([resultText], { type: "text/plain" });
    const url = window.URL.createObjectURL(data);
    document.getElementById("download_link").href = url;
}


