using RickAndMortyWiki.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Navigation;

namespace RickAndMortyWiki.Wrappers
{
    public class CharacterWrapper 
    {
        public Character Character = new();

        public CharacterWrapper()
        {
                
        }
        public CharacterWrapper(Character character)
        {
            Id = character.id;
            Name = character.name;
            Status = character.status;
        }
        public int Id { get; set; }

        private string? name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string? status;

        public string Status
        {
            get
            {
                if (status.ToUpper() == "ALIVE")
                    return "VIVO";
                else return "desCOnheCiDO".ToUpper();
            }
            set
            {
                if (value.Length <= 3) return;

                status = value;
            }
        }

    }
}
