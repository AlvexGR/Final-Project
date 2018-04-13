using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class Theme
    {
        private int themeId;
        private string themeName;
        private List<Vocabulary> Vocabularies;

        public Theme(int themeId, string themeName, List<Vocabulary> vocabularies)
        {
            this.themeId = themeId;
            this.themeName = themeName;
            Vocabularies = vocabularies;
        }

        public int ThemeId { get => themeId; set => themeId = value; }
        public string ThemeName { get => themeName; set => themeName = value; }
        internal List<Vocabulary> Vocabularies1 { get => Vocabularies; set => Vocabularies = value; }
    }
}
