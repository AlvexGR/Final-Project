using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    class Setting
    {
        private int volume;
        private int fontSize;
        private Background background;
        private int numberOfVocabulary;

        public Setting(int volume, int fontSize, Background background, int numberOfVocabulary)
        {
            this.volume = volume;
            this.fontSize = fontSize;
            this.background = background;
            this.numberOfVocabulary = numberOfVocabulary;
        }

        public int Volume { get => volume; set => volume = value; }
        public int FontSize { get => fontSize; set => fontSize = value; }
        public int NumberOfVocabulary { get => numberOfVocabulary; set => numberOfVocabulary = value; }
        internal Background Background { get => background; set => background = value; }
    }
}
