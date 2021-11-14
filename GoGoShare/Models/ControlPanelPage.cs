using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoShare.Models
{
    public class ControlPanelPage
    {
        public List<文章> 所有文章 {
            get
            {
                return new SQL任務().文章.OrderByDescending(x => x.Id).ToList();
            }
        }
        public List<用戶> 所有用戶
        {
            get
            {
                return new SQL任務().用戶.OrderByDescending(x => x.Id).ToList();
            }
        }
        public List<圖片> 所有圖片
        {
            get
            {
                return new SQL任務().圖片.OrderByDescending(x => x.Id).ToList();
            }
        }
    }
}