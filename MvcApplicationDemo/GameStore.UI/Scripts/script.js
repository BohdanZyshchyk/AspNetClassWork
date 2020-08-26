function setDevelopers(event) {
    location.search = `type=Developer&name=${event.target.name}`;
}