using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Entity
{
    public class EmployeeEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "First Name can not be greater than 120 characters.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(120, ErrorMessage = "Last Name can not be greater than 120 characters.")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Email can not be greater than 100 characters.")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Email can not be greater than 10 digit.")]
        public string Mobile { get; set; }

        public static explicit operator Task<object>(EmployeeEntity v)
        {
            throw new NotImplementedException();
        }
    }
}
