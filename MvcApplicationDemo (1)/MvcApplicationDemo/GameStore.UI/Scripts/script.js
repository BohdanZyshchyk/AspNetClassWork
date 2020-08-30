function setDevelopers(event) {
   //location.search = `type=Developer&name=${event.target.name}`;
    
    $("#games").load(`/Games/Filter?type=Developer&name=${encodeURIComponent(event.target.name)}`);
}

function setGenres(event) {
    //location.search = `type=Developer&name=${event.target.name}`;

    $("#games").load(`/Games/Filter?type=Genre&name=${encodeURIComponent(event.target.name)}`);
}