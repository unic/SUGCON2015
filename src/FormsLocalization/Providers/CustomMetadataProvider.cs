namespace FormsLocalization.Providers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using Sitecore.Globalization;

    /// <summary>
    /// CREDITS: https://github.com/SUGCH/SitecoreMVCFormsLocalization
    /// </summary>
    public class CustomMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            // create the metadata as it normally would
            var propertyAttributes = attributes.ToList();
            var modelMetadata = base.CreateMetadata(propertyAttributes, containerType, modelAccessor, modelType, propertyName);

            // add translation based on your criteria
            if (IsTransformRequired(modelMetadata, propertyAttributes))
            {
                modelMetadata.DisplayName = Translate.Text(modelMetadata.PropertyName);
            }

            return modelMetadata;
        }

        private static bool IsTransformRequired(ModelMetadata modelMetadata, IList<Attribute> propertyAttributes)
        {
            if (string.IsNullOrWhiteSpace(modelMetadata.PropertyName)) return false;
            if (modelMetadata.PropertyName != "MetadataProviderPropertyName") return false;
            if (propertyAttributes.OfType<DisplayNameAttribute>().Any()) return false;
            return !propertyAttributes.OfType<DisplayAttribute>().Any();
        }
    }
}