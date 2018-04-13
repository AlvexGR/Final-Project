using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class Background
    {
        private int id;
        private string path;

        public Background(int id, string path)
        {
            this.id = id;
            this.path = path;
        }

        public int Id { get => id; set => id = value; }
        public string Path { get => path; set => path = value; }
    }
}
