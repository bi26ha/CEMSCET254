using System.ComponentModel.DataAnnotations;

namespace CEMSCET254.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Event), nameof(ValidateDate))]
        public DateTime Date { get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        public string Description { get; set; }

        public List<Registration> Registrations { get; set; }

        public List<Activity> Activities { get; set; }

        // Custom Validation Method for Date
        public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
        {
            if (date < DateTime.Today)
            {
                return new ValidationResult("The event date cannot be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}