// UserDTO.cs is a part of the GDPR Bachelor project. Created: 14, 03, 2017.
// Creators: Dennis Thinh Tan Nguyen & Thor Valentin Aakjær Olesen Nielsen.

using System;

namespace OnionArchitecture.Data.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsHero { get; set; }
    }
}