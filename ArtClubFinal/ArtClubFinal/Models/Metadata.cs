using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtClubFinal.Models
{
    public class MemberMetadata
    {
        [Required(ErrorMessage = "*Introducerea numelui este obligatorie")]
        [Range(1, 50, ErrorMessage = "*Numarul maxim de caractere este 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Functia ocupata de membru este obligatorie")]
        public string Position { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }

    public class EventMetadata
    {
        public int EventID { get; set; }
        [Required(ErrorMessage = "Introducerea numelui este obligatorie")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Introducerea locatiei este obligatorie")]
        public string Location { get; set; }

    }
}