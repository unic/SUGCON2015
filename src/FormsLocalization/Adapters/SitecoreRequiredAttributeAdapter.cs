namespace FormsLocalization.Adapters
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Sitecore.Globalization;

    /// <summary>
    /// CREDITS: https://github.com/SUGCH/SitecoreMVCFormsLocalization
    /// </summary>
    public class SitecoreRequiredAttributeAdapter : RequiredAttributeAdapter
    {
        public SitecoreRequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute) : base(metadata, context, attribute)
        {
        }

        private string GetMessage()
        {
            // consider the error message as a key, fall back to the attribute type name
            var key = this.Attribute.ErrorMessage;

            return Translate.Text(key);
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var message = this.GetMessage();
            
            return new[] { new ModelClientValidationRequiredRule(message) };
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // create the validation context
            var context = new ValidationContext(container ?? this.Metadata.Model, null, null)
            {
                DisplayName = this.Metadata.GetDisplayName()
            };

            // handle the validation process 
            var result = this.Attribute.GetValidationResult(this.Metadata.Model, context);
            if (result == ValidationResult.Success) yield break;

            // override the result message
            yield return new ModelValidationResult { Message = this.GetMessage() };
        }
    }
}