using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model.Enums;

namespace Game.Model
{
    public class Set
    {
        public int Id { get; set; }

        public User User { get; set; }

        public bool IsCreatedByTheme { get; set; }
    }
}
