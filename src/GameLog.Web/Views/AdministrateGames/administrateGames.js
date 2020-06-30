function addGame() {
    // Get the form values
    var title = document.getElementById("GameToAdd_Title").value;
    var author = document.getElementById("GameToAdd_Author").value;
    var description = document.getElementById("GameToAdd_Description").value;

    $.ajax({
        type: "POST",
        url: '@Url.Action("AddGamesAjax")/?title=' + title + '&author=' + author + '&description=' + description,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {
        // Present the response
        var saveResultMessage = document.getElementById("saveResultMessage");
        saveResultMessage.innerText = data.message;
        saveResultMessage.style.display = "block";

        setSuccessFailColor(data.success)
    })
}

function setSuccessFailColor(success) {
    if (success) {
        // On successful call - set green color
        saveResultMessage.classList.add("text-success");
        saveResultMessage.classList.remove("text-danger");

        // And reload page after 2 seconds to get new title to appear
        // TODO: Insert it via JS instead and don't reload?
        setTimeout(() => {
            location.reload();
        }, 2000);
    } else {
        // On failed, set the text red
        saveResultMessage.classList.remove("text-success");
        saveResultMessage.classList.add("text-danger");
    }
}