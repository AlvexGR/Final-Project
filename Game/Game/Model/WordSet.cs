using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class WordSet
    {
        public int Id { get; set; }


        [ForeignKey("Word")]
        public int WordId { get; set; }
        public virtual Vocabulary Word { get; set; }

        [ForeignKey("Set")]
        public int SetId { get; set; }
        public virtual Set Set { get; set; }

        public int Star { get; set; }
    }
}
