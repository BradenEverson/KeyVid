document.getElementById("send").disabled = true;

var connection = new signalR.HubConnectionBuilder().withUrl("./VideoHub").build();
connection.start().then(function () {
    document.getElementById("send").disabled = false;
    document.getElementById("cleaner").click();
});
connection.on("Added", function () {
    var ul = document.getElementById("contentList");
    var li = document.createElement("li");
    li.innerHTML = document.getElementById("content").value;
    li.setAttribute("class", "list-group-item border-info");
    li.setAttribute("style", "margin:2px");
    ul.appendChild(li);
    document.getElementById("content").value = "";
});
function add(guid) {
    if (document.getElementById("content").value != "") {
        connection.invoke("addToList", document.getElementById("content").value, guid).catch(function (err) {
            return console.error(err);
        });
    }
}
function clean(guid) {
    connection.invoke("clean", guid).catch(function (err) {
        return console.error(err);
    });
}