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

async function sendTestWords(url) {
    const words =
        "[{\"value\": \"soap\",\"partOfSpeech\": \"noun\",\"transcription\": \"ˈsōp\",\"definition\": \"test def\",\"example\": \"test example\"}" +
        ",{\"value\": \"HORSE\",\"partOfSpeech\": \"HORSE\",\"transcription\": \"ˈsōp\",\"definition\": \"test def1\",\"example\": \"test example1\"}]";
    sendWords(url, words);
}

async function sendWords(url, words) {
    const text = await sendRequest(url, "POST", words);
    prepareFileToDownload(text);
}

function prepareFileToDownload(text) {
    const resultText = text.substring(1, text.length - 1).replace(/\\r\\n/gi, "\n");
    const data = new Blob([resultText], { type: "text/plain" });
    const url = window.URL.createObjectURL(data);
    document.getElementById("download_link").href = url;
}

function loadOtherFields(j, i, partsOfSpeech, examples) {
    if (j > -1) {
        const html = toHtml(examples[j]);
        document.getElementById(i + "_pof").innerText = partsOfSpeech[j];
        document.getElementById(i + "_examples").innerHTML = html;
    } else {
        document.getElementById(i + "_pof").innerText = "";
        document.getElementById(i + "_examples").innerHTML = "";
    }
}

function toHtml(examples) {
    var html = "";
    if (examples.length > 0) {

        for (let i = 0; i < examples.length; i++) {
            html = html + `<option>${examples[i]}</option>`;
        }
        html = `<select>${html}</select>`;
    }
    return html;
}