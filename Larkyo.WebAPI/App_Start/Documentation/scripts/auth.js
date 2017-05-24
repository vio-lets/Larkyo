function handleAjaxResponse() {
    if (this.readyState === 4 && this.status === 200) {
        parseResponse(this.responseText);
    }
}

function parseResponse(response) {
    if (response.indexOf("access_token") < 0) return;

    const authResponse = JSON.parse(response);
    const accessToken = `Bearer ${authResponse.access_token}`;
    $("input[name='Authorization']")
        .val(accessToken);
}

XMLHttpRequest.prototype.originalSend = XMLHttpRequest.prototype.send;
XMLHttpRequest.prototype.send = function (value) {
    this.addEventListener("readystatechange", handleAjaxResponse, false);
    this.originalSend(value);
}