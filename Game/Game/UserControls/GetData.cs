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
        public static List<Vocabulary> wordListTotal = new List<Vocabulary>();
        public static List<Vocabulary> wordList = new List<Vocabulary>();
        public static int curTheme = -1;
        public static bool isTheme = false;
        public static User currentUser = new User();
        public static bool didRegister = false;
        public static int volume = 0;
        public static Vocabulary curWord;
        public static int correctAnswer = 0;
    }
}
