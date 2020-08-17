function mysearch() {
    let value = document.querySelector('#searchInput').value;
    location.href = "/Games/Search?name=" + value;
}