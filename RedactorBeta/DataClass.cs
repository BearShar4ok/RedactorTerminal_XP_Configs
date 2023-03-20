using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactorBeta
{
    //instance of this class is serializable via json
    public class DataClass
    {
        public int HackAttempts { get; set; } = 10;
        public bool CanBeChanged { get; set; } = false;
        public bool CanBeCopied { get; set; } = false;
        public bool CanBeDeleted { get; set; } = false;
        public bool HasPassword { get; set; } = false;
        public bool CanBeHacked { get; set; } = false;
        public Dictionary<string, string> LoginsAndPasswords { get; set; } = new Dictionary<string, string>();
    }
    public class MyTuple
    {
        public string Log { get; set; } = "";
        public string Pas { get; set; } = "";
    }
}
