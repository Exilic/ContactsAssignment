

function CreatePerson(event, contents) {
    event.preventDefault();    
    $.post(contents.action,
        {
            PersonName: contents.PersonName.value,
            PhoneNumber: contents.PhoneNumber.value,
            City: contents.City.value
        },
        function (data) {
            if (data.includes('onsubmit')) {
                $('#searchArea').html(data);
            } else {
                $("#listOfPeople").append(data);
            }   
         }
    );
}


function EditEntryForm(entryId) {

    $.get("/People/AjaxEditPost/" + entryId, function (partial) {
        $("#personId-" + entryId).html(partial);
    });
}

function PostEditedEntry(id, event, contents) {
    event.preventDefault();
    $.post(contents.action,
        {
            PersonName: contents.PersonName.value,
            PhoneNumber: contents.PhoneNumber.value,
            City: contents.City.value,
            Id: id
        },
        function (data) {
            $("#personId-"+id).html(data);
        }
    );
        

}

function Delete(id, event, contents) {
    event.preventDefault();
    console.log(contents);
    console.log(contents.action);

    $.post(contents.href,
        {
            Id: id
        },
        
        function (data) {
            console.log(data);
            document.getElementById(`personId-${id}`).remove();
            document.getElementById('message-area').innerHTML = `<h3>${data}</h3>`;
        }
    );
    
}