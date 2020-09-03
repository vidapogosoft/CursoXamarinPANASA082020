using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRest.Model
{
    public class TodoItems
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
