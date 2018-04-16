using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class Vocabulary
    {
        //private int id;
        //private int definition;
        //private string pronunciation;
        //private string name;
        //private string image;

        public int Id { get; set; }
        public string EnglishWord { get; set; }
        public string Definition { get; set; }
        public string Pronunciation { get; set; }
        public string Spelling { get; set; }
        public string Image { get; set; }
        public bool IsLearned { get; set; }
        public virtual Theme Theme { get; set; }

        //public Vocabulary(int id, int definition, string pronunciation, string name, string image, int themeId, string themeName, List<Vocabulary> vocabularies) : base(themeId, themeName, vocabularies)
        //{
        //    this.id = id;
        //    this.definition = definition;
        //    this.pronunciation = pronunciation;
        //    this.name = name;
        //    this.image = image;
        //}

        //public Vocabulary(int themeId, string themeName, List<Vocabulary> vocabularies) : base(themeId, themeName, vocabularies)
        //{

        //}
    }
}
