using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Animals
    {
        public string description = "Unknown";
        public string Description
        {
            get => description;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    description = "Unknown";
                }
                else
                {

                    value = value.Trim();
                    if (value.Length > 15)
                    {
                        value = value.Substring(0, 15).TrimEnd();
                    }


                    if (value.Length < 3)
                    {
                        value = value.PadRight(3, '#');
                    }

                    description = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }
        public uint Size { get; set; } = 3;
        public string Info => $"{Description} <{Size}>";

    }

}

