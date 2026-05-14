using Newtonsoft.Json;
using System;

namespace RickAndMortyWiki.models
{
    public class Character
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public string? species { get; set; }
        public string? image { get; set; }
        public List<string> episode { get; set; }
    }
}