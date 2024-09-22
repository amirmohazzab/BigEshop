'use strict';

var chatterName = 'visitor';

var connection = new signalR.HubConnectionBuilder().withUrl('/chatHub').build();

connection.on('ReceiveMessage', renderMessage);

connection.start();


function ready()
{
    var chatForm = document.getElementById('chatForm');
    chatForm.addEventListener('submit', function (e) {
        e.preventDefault();
        var text = e.target[0].value;
        e.target[0].value = '';
        sendMessage(text);
    });
}

function sendMessage(text)
{
    if (text && text.length)
        connection.invoke('SendMessage', chatterName, text);
}

function renderMessage(name, time, message)
{

}

document.addEventListener('DomContentLoaded', ready)