using System;

namespace RickAndMortyWiki.models
{
    public class Location
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? dimension { get; set; }
    }
}