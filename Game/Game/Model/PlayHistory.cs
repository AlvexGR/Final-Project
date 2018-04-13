using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class PlayHistory
    {
        private int id;
        private DateTime date;
        private int score;

        public PlayHistory(int id, DateTime date, int score)
        {
            this.id = id;
            this.date = date;
            this.score = score;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Score { get => score; set => score = value; }
    }
}
