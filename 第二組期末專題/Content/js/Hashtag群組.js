class Hashtag群組 {
    目標容器;
    編輯模式 = false;
    name = 'hashtags';
    hashtags;

    onchange = () => {
        var 隱藏的input = this.目標容器.querySelector(`input[name="${this.name}"]`);
        隱藏的input.setAttribute('value', this.value);
        console.log(this.value);
    }

    get value() {
        var 選中 = this.目標容器.querySelectorAll('option[disabled="disabled"]');
        var result = [];
        for (var 選項 of 選中) {
            result.push(parseInt(選項.getAttribute('hashtag')));
        }
        return result;
    }

    隱藏的input = () => {
        var 隱藏的input = document.createElement('input');
        隱藏的input.type = 'hidden';
        隱藏的input.setAttribute('name', this.name);
        return 隱藏的input;
    };

    選擇器 = () => {
        var 選擇器 = document.createElement('input');
        選擇器.setAttribute('list', 'hashtags');
        return 選擇器;
    }

    選項表 = () => {
        var 選項表 = document.createElement('datalist');
        選項表.id = 'hashtags';
        return 選項表;
    }

    選項 = (hashtag) => {
        var 選項 = document.createElement('option');
        選項.setAttribute('hashtag', hashtag.Id);
        選項.setAttribute('category', hashtag.類別);
        選項.setAttribute('value', hashtag.名稱);
        return 選項;
    }

    標籤群組 = () => {
        var 標籤群組 = document.createElement('div');
        標籤群組.classList.add('tagcloud');
        return 標籤群組;
    };

    標籤 = (hashtag) => {
        var 標籤 = document.createElement('a');
        標籤.href = "/Search?hashtag=" + hashtag.Id;
        標籤.classList.add('tag-cloud-link');
        標籤.innerText = hashtag.名稱;
        return 標籤;
    };

    可移除標籤 = (hashtag) => {
        var 標籤 = document.createElement('a');
        標籤.classList.add('tag-cloud-link');
        標籤.style.cursor = 'pointer';
        標籤.setAttribute('alt', '刪除Hashtag');
        標籤.setAttribute('title', '刪除Hashtag');
        標籤.innerText = hashtag.名稱;
        標籤.onclick = () => {
            var 選中 = this.目標容器.querySelector(`option[hashtag="${hashtag.Id}"]`);
            選中.removeAttribute('disabled');
            標籤.remove();
            this.onchange();
        };
        return 標籤;
    };

    類別風格 = {
        "愛好": (標籤) => {
            標籤.classList.add('btn-warning');
            標籤.style.color = 'Black';
            return 標籤;
        },
        "地區": (標籤) => {
            標籤.classList.add('btn-info');
            標籤.style.color = 'White';
            return 標籤;
        }
    };

    constructor(hashtags, 設定值) {
        this.hashtags = hashtags;
        Object.assign(this, 設定值);
    }

    at(目標容器) {
        this.目標容器 = 目標容器;
        if (this.編輯模式) {
            this.#gen標籤選擇器(目標容器);
        }
        else {
            this.#gen標籤群組(目標容器);
        }
    }

    #gen標籤選擇器(目標容器) {
        var 目標容器 = 目標容器;
        var 隱藏的input = this.隱藏的input();
        var 標籤群組 = this.標籤群組();
        var 選擇器 = this.選擇器();
        var 選項表 = this.選項表();
        var 視窗 = this.#gen視窗();

        for (var hashtag of this.hashtags) {
            var 選項 = this.選項(hashtag);
            選項表.appendChild(選項);
        }

        選擇器.onchange = () => { this.#when選擇器改變(); };

        選擇器.appendChild(選項表);
        標籤群組.appendChild(選擇器);
        目標容器.appendChild(標籤群組);
        目標容器.appendChild(視窗);
        目標容器.appendChild(隱藏的input);
    }

    #when選擇器改變() {
        var 標籤群組 = this.目標容器.querySelector('div.tagcloud');
        var 選擇器 = this.目標容器.querySelector('input');
        var 選中項 = this.目標容器.querySelector(`option[value=${選擇器.value}]`);

        var when有選中項 = () => {
            選中項.setAttribute('disabled', 'disabled');
            var hashtag = this.#attributeToHashtag(選中項);
            var 標籤 = this.#gen可移除標籤(hashtag);
            標籤群組.insertBefore(標籤, 選擇器);
        };

        var when無選中項 = () => {
            jQuery.noConflict();
            $('#createHashtag').modal('show');
            $('#hashtag-name').val(選擇器.value);
            for (var 類別 of Object.keys(this.類別風格)) {
                console.log(類別);
                $('#createHashtagSelect').append($('<option>').text(類別))
            }
        };

        if (選中項) {
            when有選中項();
        }
        else {
            when無選中項();
        }

        this.onchange();

        選擇器.value = '';
    };

    #gen視窗() {
        var modal = document.createElement('div');
        modal.innerHTML = `
            <div class="modal fade" id="createHashtag" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="createHashtagLabel">新增 Hashtag</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <div class="form-group">
                      <label for="recipient-name" class="col-form-label">Hashtag 名稱:</label>
                      <input type="text" class="form-control" id="hashtag-name">
                      <label for="recipient-name" class="col-form-label">Hashtag 類別:</label>
                      <select class="form-control" id="createHashtagSelect"></select>
                    </div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
                    <button type="button" class="btn btn-primary" id="createHashtagSubmit">新增</button>
                  </div>
                </div>
              </div>
            </div>`;
        var that = this;
        modal.querySelector('#createHashtagSubmit').onclick = function() {
            $.ajax({
                type: 'POST',
                url: '/Post/AddHashtag',
                data: {
                    名稱: document.getElementById('hashtag-name').value,
                    類別: document.getElementById('createHashtagSelect').value
                }
            }).done(function (hashtag) {
                var 標籤群組 = that.目標容器.querySelector('div.tagcloud');
                var 選擇器 = that.目標容器.querySelector('input');

                var 新選項 = that.選項(hashtag[0]);
                新選項.setAttribute('disabled', 'disabled');
                that.目標容器.querySelector('datalist[id="hashtags"]').appendChild(新選項);

                var 標籤 = that.#gen可移除標籤(hashtag[0]);
                標籤群組.insertBefore(標籤, 選擇器);

                $('#createHashtag').modal('hide');
            });
        };
        return modal.firstElementChild;
    }

    #attributeToHashtag(element) {
        return {
            Id: element.getAttribute('hashtag'),
            類別: element.getAttribute('category'),
            名稱: element.getAttribute('value')
        }
    }

    #gen標籤群組(目標容器) {
        var 標籤群組 = this.標籤群組();
        
        for (var hashtag of this.hashtags) {
            var 標籤 = this.#gen標籤(hashtag);
            標籤群組.appendChild(標籤);
        }

        目標容器.appendChild(標籤群組);
    }

    #gen可移除標籤(hashtag) {
        var 標籤 = this.可移除標籤(hashtag);
        標籤 = this.類別風格[hashtag.類別](標籤);

        return 標籤;
    }

    #gen標籤(hashtag) {
        var 標籤 = this.標籤(hashtag);
        標籤 = this.類別風格[hashtag.類別](標籤);

        return 標籤;
    }
}