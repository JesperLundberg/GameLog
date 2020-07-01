function administrateGames_addGame() {
    // Get the form values
    var title = document.getElementById("GameToAdd_Title").value;
    var author = document.getElementById("GameToAdd_Author").value;
    var description = document.getElementById("GameToAdd_Description").value;

    $.ajax({
        type: "POST",
        url: 'AdministrateGames/AddGamesAjax/?title=' + title + '&author=' + author + '&description=' + description,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {
        // Present the response
        var saveResultMessage = document.getElementById("saveResultMessage");
        saveResultMessage.innerHTML = data.message.replaceAll('|', '<br/>');
        saveResultMessage.style.display = "block";

        administrateGames_setSuccessFailColor(data.success)
        
        if (data.success) {
            saveResultMessage.innerHTML += "<br/>Reloading in 5 seconds to show new entry..."
            // And reload page after 2 seconds to get new title to appear
            setTimeout(() => {
                location.reload();
            }, 5000);
        }
    })
}

function administrateGames_setSuccessFailColor(success) {
    if (success) {
        // On successful call - set green color
        saveResultMessage.classList.add("text-success");
        saveResultMessage.classList.remove("text-danger");
    } else {
        // On failed, set the text red
        saveResultMessage.classList.remove("text-success");
        saveResultMessage.classList.add("text-danger");
    }
}