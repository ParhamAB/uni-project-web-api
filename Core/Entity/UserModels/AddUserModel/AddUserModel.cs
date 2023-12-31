﻿using System.ComponentModel.DataAnnotations;

namespace uni_project.Core.Entity.User.AddUserModel
{
    public class AddUserModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string NationalCode { get; set; }

        [Required]
        public string FieldofStudy { get; set; }

        public string Email { get; set; }

        public string LastDocument { get; set; }

        [Required]
        public string Job { get; set; }

        public string JobAddress { get; set; }

        public AddUserModel(
        string firstName,
        string lastName,
        string phoneNumber,
        string nationalCode,
        string fieldOfStudy,
        string job,
        string email,
        string? lastDocument = null,
        string? jobAddress = null)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            FieldofStudy = fieldOfStudy;
            Job = job;
            Email = email;
            LastDocument = lastDocument;
            JobAddress = jobAddress;
        }
    }
}
