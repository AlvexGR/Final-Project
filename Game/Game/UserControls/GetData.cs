using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UserControls
{
    public static class GetData
    {
        public static List<Vocabulary> wordList = new List<Vocabulary>();
        public static int curTheme = -1;
        public static bool isTheme = false;
        public static bool isManual = false;
    }
}
