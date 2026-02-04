using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Domain.Aggregates
{
    public class RideInfoBase : BaseModel, IValidatableObject
    {
        public DateTime? TravelDate { get; set; }
        [Required(ErrorMessage = "Pickup time is required!")]
        public DateTime? PickupTime { get; set; }
        public DateTime? BoardingTime { get; set; }
        [Required(ErrorMessage = "Drop-off time is required!")]
        public DateTime? DropOffTime { get; set; }//this filed with update when rider reached to his/her destination
        public double? TravelDistance { get; set; }//metre need to discuss
        public double? TravelTime { get; set; }//seconds
        [Required(ErrorMessage = "Riders are required!")]
        [RegularExpression(@"^(100|[1-9][0-9]?)$", ErrorMessage = "Enter a valid number.")]
        public int TravelerCount { get; set; } = 1;

        //     [Required(ErrorMessage = "Lead passenger name is required!"), RegularExpression(@"^([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*)(\s([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*))*\s*(,\s*([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*)(\s([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*))*)*$",
        //ErrorMessage = "Please enter one or more valid names, separated by commas.")]
        public string LeadPassengerId { get; set; }
        [NotMapped]
        public string LeadPassengerName { get; set; }
        [Required(ErrorMessage = "Phone number is required!"), PhoneByCountry("CountryCode")]
        public string LeadPassengerPhoneNo { get; set; }
        //    [Required(ErrorMessage = "Passenger's name is required!"), RegularExpression(@"^([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*)(\s([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*))*\s*(,\s*([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*)(\s([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*))*)*$",
        //ErrorMessage = "Please enter one or more valid names, separated by commas.")]
        public string PassengersName { get; set; }
        public string NonSCIPassengers { get; set; }
        [Required(ErrorMessage = "Purpose are required!")]
        public string PurposeOfTravel { get; set; }
        [Required(ErrorMessage = "Purpose of use is required!")]
        public string PurposeOfUse { get; set; }
        //RegularExpression(@"^(?:\+8801|01)[3-9]\d{8}$", ErrorMessage = "Enter a valid Bangladeshi phone number.")

        public DateTime? RequestDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestNo { get; set; }

        [RegularExpression(@"^([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*)(\s([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*))*\s*(,\s*([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*)(\s([A-Za-z](?:\.)?|[A-Za-z]+(?:[.'’-][A-Za-z]+)*))*)*$",
    ErrorMessage = "Please enter one or more valid names, separated by commas.")]

        [NotMapped, PhoneByCountry("CountryCode")]
        public string NonSCIPassengerPhoneNo { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            RequestDate = RequestNo == 0 ? DateTime.Now : RequestDate;
            if (RequestDate?.AddHours(2) >= PickupTime)
            {
                yield return new ValidationResult(
                    "The pickup time must be set a minimum of two hours ahead of the request time.",
                    [nameof(PickupTime)]
                );
            }
            if (DropOffTime.HasValue && DropOffTime <= PickupTime)
            {
                yield return new ValidationResult(
                    "Drop-off time must be later than pickup time.",
                    [nameof(DropOffTime)]
                );
            }

            //if (string.IsNullOrWhiteSpace(ContactPhoneNo))
            //{
            //    yield return new ValidationResult(
            //        "Phone number is required!",
            //        new[] { nameof(ContactPhoneNo) }
            //    );
            //}
            //else
            //{
            //    var bdRegex = @"^(?:\+8801|01)[3-9]\d{8}$";
            //    var keRegex = @"^(?:\+254|0)7\d{8}$";

            //    if (string.Equals(CountryCode, "bd", StringComparison.OrdinalIgnoreCase) && !System.Text.RegularExpressions.Regex.IsMatch(ContactPhoneNo, bdRegex))
            //    {
            //        yield return new ValidationResult(
            //            "Enter a valid Bangladeshi phone number.",
            //            new[] { nameof(ContactPhoneNo) }
            //        );
            //    }

            //    if (string.Equals(CountryCode, "ke", StringComparison.OrdinalIgnoreCase) && !System.Text.RegularExpressions.Regex.IsMatch(ContactPhoneNo, keRegex))
            //    {
            //        yield return new ValidationResult(
            //            "Enter a valid Kenyan phone number.",
            //            new[] { nameof(ContactPhoneNo) }
            //        );
            //    }
            //}
        }
    }


    public class PhoneByCountryAttribute : ValidationAttribute
    {
        public string CountryProperty { get; }

        public PhoneByCountryAttribute(string countryProperty)
        {
            CountryProperty = countryProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var countryProp = validationContext.ObjectType.GetProperty(CountryProperty);
            if (countryProp == null)
                return new ValidationResult($"Unknown property: {CountryProperty}");

            var countryValue = countryProp.GetValue(validationContext.ObjectInstance, null)?.ToString();
            var phone = value?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(phone))
                return new ValidationResult("Phone number is required!");

            // Bangladesh regex
            var bdRegex = new Regex(@"^(?:\+8801|01)[3-9]\d{8}$");
            // Kenya regex (07xxxxxxxx or +2547xxxxxxxx)
            var keRegex = new Regex(@"^(?:\+254|0)7\d{8}$");

            if (string.Equals(countryValue, "bd", StringComparison.OrdinalIgnoreCase) && !bdRegex.IsMatch(phone))
                return new ValidationResult("Enter a valid Bangladeshi phone number.");

            if (string.Equals(countryValue, "ke", StringComparison.OrdinalIgnoreCase) && !keRegex.IsMatch(phone))
                return new ValidationResult("Enter a valid Kenyan phone number.");

            return ValidationResult.Success;
        }
    }

}
