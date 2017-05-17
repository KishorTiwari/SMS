function delDealer(Id) {
    console.log("Delete Clicked");
    $.ajax({
        method: "DELETE",
        url: "DeleteDealer/"+Id,
        data: { Id }
    }).done(function () {
        console.log("Deleted");
    });
}