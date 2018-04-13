using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class Vocabulary : Theme
    {
        private int id;
        private int definition;
        private string pronunciation;
        private string name;
        private string image;
        public Vocabulary(int id, int definition, string pronunciation, string name, string image, int themeId, string themeName, List<Vocabulary> vocabularies) : base(themeId, themeName, vocabularies)
        {
            this.id = id;
            this.definition = definition;
            this.pronunciation = pronunciation;
            this.name = name;
            this.image = image;
        }

        public Vocabulary(int themeId, string themeName, List<Vocabulary> vocabularies) : base(themeId, themeName, vocabularies)
        {
            
        }
    }
}
