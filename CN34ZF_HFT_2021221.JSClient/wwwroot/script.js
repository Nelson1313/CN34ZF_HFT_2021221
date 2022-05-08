let teams = [];
let connection = null;

let teamIdToUpdate = -1;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:56403/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamCreated", (user, message) => {
        getdata();
    });

    connection.on("TeamDeleted", (user, message) => {
        getdata();
    });

    connection.on("TeamUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:56403/team')
        .then(x => x.json())
        .then(y => {
            teams = y;
            //console.log(teams);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    teams.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.teamId + "</td><td>"
        + t.teamName + "</td><td>" + t.seat + "</td><td>" + t.manager + "</td><td>" + t.yearofFoundation + "</td><td>" +
        `<button type="button" onclick="remove(${t.teamId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.teamId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:56403/team/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('teamnametoupdate').value = teams.find(t => t['teamId'] == id)['teamName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    teamIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('teamnametoupdate').value;
    let stadium = document.getElementById('seattoupdate').value;
    let edzo = document.getElementById('managertoupdate').value;
    let alapitas = document.getElementById('yearofFoundationtoupdate').value;
    fetch('http://localhost:56403/team', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                teamId: teamIdToUpdate,
                teamName: name,
                seat: stadium,
                manager: edzo,
                yearofFoundation: alapitas
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('teamname').value;
    let stadium = document.getElementById('seat').value;
    let edzo = document.getElementById('manager').value;
    let alapitas = document.getElementById('yearofFoundation').value;
    let ligaaz = document.getElementById('leagueid').value;
    fetch('http://localhost:56403/team', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                teamName: name,
                seat: stadium,
                manager: edzo,
                yearofFoundation: alapitas,
                leagueId: ligaaz
            }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}