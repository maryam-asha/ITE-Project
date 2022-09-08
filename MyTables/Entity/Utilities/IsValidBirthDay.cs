using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyTables.Entity.Utilities
{
    public sealed class  IsValidBirthDay: ValidationAttribute,
          IClientValidatable
    {
        private readonly string StartDatePropertyName;
        //init
        public IsValidBirthDay(string StartDatePropertyAttrName)
        {
            this.StartDatePropertyName = StartDatePropertyAttrName;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            throw new NotImplementedException();
        }

        //override IsValid
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.StartDatePropertyName);
            /// Get Start Date Value 
            var StartDateValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
            // init start date 
            DateTime StartDate = DateTime.MinValue;
           

            if (DateTime.TryParse(StartDateValue.ToString(), out StartDate))
            {

                // Implement your logic
                    if (DateTime.Now.Year - StartDate.Year >= 10)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(FormatErrorMessage("Your age must be over 10 years old"));

                    }

               

            }
            else
            {
                return new ValidationResult(FormatErrorMessage("Your age must be over 10 years old"));
            }
        }

    }
}
