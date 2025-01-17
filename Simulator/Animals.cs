using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                if (string.IsNullOrWhiteSpace(value)) /* and */
                {
                    description = "Unknown";
                }
                else
                {
                    value = Validator.Shortener(value, 3, 15, '#');
                    description = char.ToUpper(value[0]) + value.Substring(1);
                }
            }
        }
        public uint Size { get; set; } = 3; 
        public virtual string Info => $"{Description} <{Size}>";

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }

    }

}

