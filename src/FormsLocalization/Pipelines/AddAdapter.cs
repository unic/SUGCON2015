namespace FormsLocalization.Pipelines
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using FormsLocalization.Adapters;
    using Sitecore.Pipelines;

    /// <summary>
    /// CREDITS: https://github.com/SUGCH/SitecoreMVCFormsLocalization
    /// </summary>
    public class AddAdapter
    {
        public void Process(PipelineArgs args)
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(SitecoreRequiredAttributeAdapter));
        }
    }
}