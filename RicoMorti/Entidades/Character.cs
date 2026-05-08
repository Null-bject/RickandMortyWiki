using System;
using System.Collections.Generic;
using System.Text;

namespace RicoMorti.Entidades
{
    internal class Character
    {
        public int id {  get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public string? species { get; set; }
        public string? type { get; set; }
        public string? genre { get; set; }

        public Origin? origin { get; set; }
        public Location? location { get; set; }
        public string? image { get; set; }
        public List<string>? episodes { get; set; }
        public DateTime? created { get; set; }


        public class Origin
        {
            public string? name { get; set; }
            public string? url { get; set; }

        }

    }


}
