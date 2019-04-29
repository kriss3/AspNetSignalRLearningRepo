var conn = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

conn.on("ReceiveMessage", (user, message) => {
    const rec_msg = user + ":" + message;
    const li = document.createElement("li");
    li.textContent = rec_msg;
    document.getElementById("messageList").appendChild(li);
});

conn.start().catch(err => console.error(err.toString()));


document.getElementById("sendMessage").addEventListener("click", event => {

    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;

    conn.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});