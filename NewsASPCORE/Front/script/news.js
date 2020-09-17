var arrayNews = [];

function GetAllNews() {
    fetch("https://localhost:44353/api/News", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json'
        }
    }).then((response) => {
        return response.json();
    }).then((data) => {
        arrayNews = data;
        console.log(arrayNews)
        for (let i = 0; i < data.length; i++) {
            document.getElementById("listNews").innerHTML +=
                `
            <div class="card mb-3">
                <img src="${data[i].linkImage}" class="card-img-top" alt="..." height="200px">
                <div class="card-body">
                    <h5 class="card-title">${data[i].title}</h5>
                    <button onclick="setModal(${i})" class="btn btn-info" data-toggle="modal" data-target="#exampleModal" href="">Read more</button>
                    <button class="btn" onclick="deleteNews(${data[i].id})"><i class="fas fa-trash"></i></button>
                </div>
            </div>
            `
        }
        console.log(arrayNews);
    }).catch((error) => {
        console.log(error);
    });
}

function postNews() {
    var title = document.getElementById("txtTitle").value;
    var date = document.getElementById("txtDate").value;
    var descr = document.getElementById("txtDecr").value;
    var image = document.getElementById("txtURL").value;
    var obj = {
        Title: title,
        DatePost: date,
        linkImage: image,
        Description: descr
    }

    fetch("https://localhost:44353/api/News/postNews", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    }).then((data) => {
        console.log(data);
        if (data.status == 200) {
            alert("NEWS ADDED!!!");
            document.getElementById("listNews").innerHTML = "";
            GetAllNews();
        } else {
            alert("SERVER ERROR!!!");

        }
    }).catch((error) => {
        alert("client error")
    });
}

function deleteNews(id) {
    deleteUrl = "https://localhost:44353/api/News/removeNews/" + id;
    fetch(deleteUrl, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json'
        }
    }).then((data) => {
        console.log(data);
        document.getElementById("listNews").innerHTML = "";
        GetAllNews();
    }).catch((error) => {
        alert("client error")
    });
}

function setModal(id) {
    document.getElementById("myModal").innerHTML =
        `
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                <img src="${arrayNews[id].linkImage}" class="card-img-top" alt="..." height="100px">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">${arrayNews[id].title}</h5>
                    </div>
                    <div class="modal-body">
                        <p>${arrayNews[id].description}</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    `

}
GetAllNews();