class Word {
    constructor(value, partOfSpeech, transcription, definition, example) {
        this.value = value;
        this.partOfSpeech = partOfSpeech;
        this.transcription = transcription;
        this.definition = definition;
        this.example = example;
    }
}

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
    const words = [
        new Word("soap", "noun", "ˈsōp", "test def", "test example"),
        new Word("HORSE", "verb", "test transcription", "test def1", "test example1")
    ];
    sendWords(url, JSON.stringify(words));
}

async function sendWords(url, words) {
    const text = await sendRequest(url, "POST", words);
    prepareFileToDownload(text);
}

function prepareFileToDownload(text) {
    const resultText = text.substring(1, text.length - 1).replace(/\\r\\n/gi, "\n");
    const data = new Blob([resultText], { type: "text/plain" });
    const url = window.URL.createObjectURL(data);
    getById("download_link").href = url;
}

function loadOtherFields(j, i, partsOfSpeech, examples) {
    if (j > 0) {
        const html = toHtml(examples[j - 1], i + "_examples_select");
        getById(i + "_pof").innerText = partsOfSpeech[j - 1];
        getById(i + "_examples").innerHTML = html;
    } else {
        getById(i + "_pof").innerText = "";
        getById(i + "_examples").innerHTML = "";
    }
}

function toHtml(examples, id) {
    var html = "";
    if (examples.length > 0) {

        for (let i = 0; i < examples.length; i++) {
            html = html + `<option>${examples[i]}</option>`;
        }
        html = `<select id=${id}>${html}</select>`;
    }
    return html;
}

function getAllValues(m) {
    const words = [];
    for (let i = 1; i <= m; i++) {
        const word = new Word(
            getById(i + "_word").innerText,
            getById(i + "_pof").innerText,
            getById(i + "_pronId").innerText,
            getById(i + "_def").value,
            getById(i + "_examples_select") ? getById(i + "_examples_select").value : "");
        words.push(word);
    }

    return JSON.stringify(words);
}

function getById(id) { return document.getElementById(id); }