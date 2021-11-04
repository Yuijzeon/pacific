using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 資料表 : Dictionary<string, object>
    {
        public void 刪除()
        {
            資料庫.刪除(this);
        }

        public void 新增OR更新()
        {
            if (this["Id"] == null)
            {
                資料庫.新增(this);
            }
            else
            {
                資料庫.更新(this);
            }
        }
    }
}