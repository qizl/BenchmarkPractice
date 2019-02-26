using System;
using System.Collections.Generic;

namespace BenchmarkPractice.Nfx.Models
{
    public class Obj
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }

        public List<Child> Childs { get; set; }
    }

    public class Child : Obj
    {
        public bool Sex { get; set; }
    }
}
