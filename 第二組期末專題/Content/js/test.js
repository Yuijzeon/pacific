$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '../Test/GetAllUser'
    }).done(生成用戶列表);
});

function 生成用戶列表 (資料s) {
        var 資料表 = $('<table>').attr('class', 'table');

        var 標題列 = $('<tr>');
        for (var 欄位名稱 in 資料s[0]) {
            標題列.append(
                $('<th>').text(欄位名稱)
            );
        }
        標題列.append(
            $('<th>').text('刪除')
        );
        資料表.append(標題列);

        for (var 資料 of 資料s) {
            var 資料列 = $('<tr>');
            for (var 欄位名稱 in 資料) {
                資料列.append(
                    $('<td>').attr('class', 欄位名稱).text(資料[欄位名稱])
                );
            }

            資料列.append(
                $('<td>').append(
                    $('<button>').attr({
                        type: "button",
                        class: "btn btn-danger"
                    }).text('🗑️').on('click', 刪除資料列)
                )
            );
            資料表.append(資料列);
        }
        $('#showAllUserData').append(資料表);
    }

function 刪除資料列() {
    var 資料列 = $(this).closest('tr');
    $.ajax({
        type: 'GET',
        url: '../Test/DeleteUser?id=' + 資料列.children('.Id').text()
    }).done(function (新資料s) {
        $('#showAllUserData').html('');
        生成用戶列表(新資料s)
    });
}