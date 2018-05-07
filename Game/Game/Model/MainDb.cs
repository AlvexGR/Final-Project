using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.Model
{
    public class MainDb : DbContext
    {
        public DbSet<Theme> Themes { get; set; }

        public DbSet<Vocabulary> Words { get; set; }

        //public DbSet<PlayHistory> PlayHistories { get; set; }

        public DbSet<Set> Sets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<WordSet> WordSets { get; set; }
    }
}
