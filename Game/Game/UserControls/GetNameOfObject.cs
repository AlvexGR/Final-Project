using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.UserControls
{
    public static class GetNameOfObject
    {
        public static string GetName(string s)
        {
            List<string> lst = s.Split('.').ToList<string>();
            return lst[lst.Count - 1];
        }
    }
}
