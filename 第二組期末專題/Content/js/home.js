//document.write('<script src="~/Content/js/QuillDeltaToHtmlConverter.bundle.js"></script>');

$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '../Home/GetJourneys'
    }).done(生成精選旅程);
});

function 生成精選旅程(文章s) {
    console.log(文章s);

    var html = "";
    for (var 文章 of 文章s) {
        var 未結束旅程 = 旅程是否開始(文章);
        if (!未結束旅程) continue;

        //var delta = JSON.parse(文章.內容);
        //var converter = new window.QuillDeltaToHtmlConverter(delta.ops);
        //文章.內容 = converter.convert();
        //Quill 編輯器的資料格式 Delta 以 JSON 格式運作
        //先將(文章.內容)從 string 轉成 JSON 物件
        //這裡渲染器用的是 QuillDeltaToHtmlConverter
        //https://github.com/nozer/quill-delta-to-html

        html += `
            <div class="item">
                <div class="blog-entry justify-content-end">
                    <a href="blog-single.html" class="block-20"
                        style="background-image: url('../../Content/images/${文章.路徑}');">
                    </a>
                    <div class="text">
                        <div class="d-flex align-items-center mb-4 topp">
                            <div class="one">
                                <span class="day">${未結束旅程.date}</span>
                            </div>
                            <div class="two">
                                <span class="yr">${未結束旅程.year}</span>
                                <span class="mos">${未結束旅程.month}</span>
                            </div>
                        </div>
                        <h3 class="heading"><a href="#">${文章.標題}</a></h3>
                        <!-- <p>A small river named Duden flows by their place and supplies it with the necessary regelialia.</p> -->
                        <p class="mb-4">${文章.內容}</p>
                        <div class="btn-group" role="group" style="width: 100%;">
                            <button type="button" class="btn btn-danger">不感興趣</button>
                            <button type="button" class="btn btn-success">了解更多</button>
                        </div>
                    </div>
                </div>
            </div>
        `;
    }
    $('#精選旅程').append(html);

    重設輪播();
}

function 旅程是否開始(文章) {
    var today = new Date();
    var 開始day = new Date(文章.日期起始);
    var 結束day = new Date(文章.日期結束);

    //if (開始day > today) {
        console.log(`活動 ${文章.標題} 於 ${開始day} 開始`);

        return {
            year: 開始day.getFullYear(),
            month: 開始day.toLocaleString('en', { month: 'long' }),
            date: 開始day.getDate()
        };
    //}
}

function 重設輪播() {
    $('.owl-carousel').owlCarousel({
        center: true,
        loop: true,
        items: 1,
        margin: 30,
        stagePadding: 0,
        nav: false,
        navText: ['<span class="ion-ios-arrow-back">', '<span class="ion-ios-arrow-forward">'],
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
    })
}