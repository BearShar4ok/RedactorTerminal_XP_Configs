﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedactorBeta
{
    public class MainConfigModel
    {
        public string Theme { get; set; }
        public ushort FontSize { get; set; }
        public float Opacity { get; set; }
        public string TerminalColor { get; set; }
        public bool UsingDelayFastOutput { get; set; }
        public uint DelayFastOutput { get; set; }
        public uint DelayUpdateCarriage { get; set; }
        public string SpecialSymbol { get; set; }
        public uint RatioSpawnWords { get; set; }
        public uint LengthHackString { get; set; }
        public bool DifficultyInfo { get; set; }
        public string FontName { get; set; }
    }
}
