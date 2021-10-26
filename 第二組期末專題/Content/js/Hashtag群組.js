class Hashtag群組 {
    constructor(selector, target) {
        var that = this;
        
        this.hashtags = this.AJAX取Hashtags();

        this.選擇框 = this.get選擇框();
        this.選擇框.change(function () {
            that.add標籤(this, that);
            $('target').val(that.value);

            console.log(that.value);
        });

        
        $(selector).append(this.選擇框);
    }

    get value() {
        var 已選中的 = this.選擇框.find('option[disabled]');

        var ID列表 = [];
        for (var 其中一個 of 已選中的) {
            ID列表.push($(其中一個).attr('hashtag'));
        }
        return ID列表;
    }

    add標籤(選中, Hashtag群組) {
        var 刪除鈕 = $('<span style="cursor: pointer;">').text(' × ');
        刪除鈕.click(function () {
            var 標籤 = $(this).closest('span[hashtag]');
            $(this).remove();
            標籤.parent().find(`option:contains(${標籤.children().text()})`).removeAttr('disabled');
            標籤.remove();
        });

        var 標籤 = $('<span hashtag>').append($('<span class="badge badge-primary">').text(選中.value).append(刪除鈕)).append(' ');
        $(選中).find(`option:contains('${選中.value}')`).attr('disabled', 'disabled');
        $(選中).before(標籤);
        $(選中).val('');
    }

    get選擇框() {
        var 待選清單 = $('<datalist id="hashtags">');

        for (var hashtag of this.hashtags) {
            待選清單.append($(`<option hashtag="${hashtag.Id}" 類別="${hashtag.類別}" >`).text(hashtag.名稱));
        }

        return $('<input list="hashtags">').append(待選清單);
    }
    
    AJAX取Hashtags() {
        // $.ajax({
        //     type: 'GET',
        //     url: '../Post/GetHashtags'
        // }).done(function (Hashtags) {
        //     return Hashtags;
        // });
        return [{Id: 1, 名稱: '自然', 類別: '愛好'},
        {Id: 2, 名稱: '樂園', 類別: '愛好'},
        {Id: 3, 名稱: '水上', 類別: '愛好'},
        {Id: 4, 名稱: '台中', 類別: '地區'},
        {Id: 5, 名稱: '台南', 類別: '地區'},
        {Id: 6, 名稱: '高雄', 類別: '地區'}];
    }
}
