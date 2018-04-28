using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model.Enums
{
    public enum TypeSetCollection
    {
        [Description("Từ thuộc chủ đề")]
        Theme = 1,

        [Description("Từ thuộc tự chọn")]
        NoTheme = 2
    }
}
