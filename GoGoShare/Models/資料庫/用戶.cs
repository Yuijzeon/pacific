using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoShare
{
    public partial class 用戶
    {
        public List<Hashtag> GetHashtag清單()
        {
            return this.Hashtag.ToList();
        }

        public List<文章> Get創作文章清單()
        {
            return new SQL任務().文章.Where(post => post.作者用戶_FK == this.Id).OrderByDescending(x => x.Id).ToList();
        }

        public List<文章> Get最新三筆文章()
        {
            return new SQL任務().文章.Where(post => post.作者用戶_FK == this.Id).OrderByDescending(x => x.Id).Take(3).ToList();
        }
    }
}