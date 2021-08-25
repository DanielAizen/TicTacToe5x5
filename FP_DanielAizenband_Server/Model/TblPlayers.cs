using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FP_DanielAizenband_Server.Model
{
    public class TblPlayers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*You must choose a vaild Username")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "*The length of username must be from 3-30 letters")]
        [RegularExpression(@"[a-zA-Z0-9\s]*", ErrorMessage = "No numbers and special charcrters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*You must choose a vaild Password")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "*The length of username must be from 3-10 letters")]
        [RegularExpression(@"[a-zA-Z0-9!@#$%^&\s]*", ErrorMessage = "You must choose a password that contains !,@,#,$,%,^,&")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*You must enter phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "*The length of phone number must be from 10 numbers")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "*You must enter email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
