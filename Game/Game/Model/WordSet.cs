using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class WordSet
    {
        public int Id { get; set; }


        public virtual Vocabulary Word { get; set; }

        public virtual Set Set { get; set; }
    }
}
