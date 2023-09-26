using System.ComponentModel.DataAnnotations;

namespace uni_project.Core.Entity.UserModel
{
    public class UserModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCode { get; set; }

        [Required]
        [StringLength(40)]
        public string FieldofStudy { get; set; }

        [StringLength(200)]
        public string LastDocument { get; set; }

        [Required]
        [StringLength(20)]
        public string Job { get; set; }

        [StringLength(300)]
        public string JobAddress { get; set; }

        public UserModel() { }

        public UserModel(
        string firstName,
        string lastName,
        string phoneNumber,
        string nationalCode,
        string fieldOfStudy,
        string job,
        string? lastDocument = null,
        string? jobAddress = null)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            FieldofStudy = fieldOfStudy;
            Job = job;
            LastDocument = lastDocument;
            JobAddress = jobAddress;
        }
    }
}
