using System;
using OnionArchitecture.Repository.Interfaces;

namespace OnionArchitecture.Repository.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool IsHero { get; set; }
        
        public string GetHeroName()
        {
            return $"{Name} {Alias}";
        }
    }
}