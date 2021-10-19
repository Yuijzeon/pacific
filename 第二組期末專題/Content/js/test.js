$(document).ready(function () {
    $.ajax({
        method: 'GET',
        url: '../Test/GetAllUser',
    }).done( GenUserList );
});

function GenUserList(datas) {
    var myTable = $('<table>').attr('class', 'table');

    var headRow = $('<tr>');
    for (var colName in datas[0]) {
        headRow.append($('<th>').text(colName));
    }
    myTable.append(headRow);

    for (var data of datas) {
        var myRow = $('<tr>');
        for (var colName in data) {
            myRow.append($('<td>').text(data[colName]));
        }
        myTable.append(myRow);
    }
    $('#showAllUserData').append(myTable);
}