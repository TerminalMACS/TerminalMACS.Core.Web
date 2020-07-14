using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalMACS.Domain.Entitys
{
    public class testA:EntityBase
    {
        public string Name { get; set; }
        public List<testB> ModelBs { get; } = new List<testB>();
    }
}
