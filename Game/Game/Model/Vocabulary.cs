using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class Vocabulary
    {
        public int Id { get; set; }
        public string EnglishWord { get; set; }
        public string Definition { get; set; }
        public string Pronunciation { get; set; }
        public string Spelling { get; set; }
        public string Image { get; set; }
        public bool IsLearned { get; set; }
        public virtual Theme Theme { get; set; }

    }
}
