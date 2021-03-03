using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TInvoiceWeb.Data
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Employee name is required")]
        public string FullName { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Email format not right")]
        public string Email { get; set; }
        [MaxLength(2000)]
        [Required(ErrorMessage = "Employee password is required")]
        public string Password { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
        
        [Required(ErrorMessage = "Employee level is required")]
        public int Level { get; set; }
        [MaxLength(12)]
        [Required(ErrorMessage = "Employee contact is required")]
        public string Contact { get; set; }
        public string Note { get; set; }


        public bool ShouldSerializePassword()
        {
            return false;
        }
        public bool ShouldSerializeSalt()
        {
            return false;
        }
        public Employee ForResponse()
        {
            Password = null;
            return this;
        }

    }

}
