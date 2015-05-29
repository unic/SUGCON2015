namespace FormsLocalization.Pipelines
{
    using System.Web.Mvc;
    using Providers;
    using Sitecore.Pipelines;

    /// <summary>
    /// CREDITS: https://github.com/SUGCH/SitecoreMVCFormsLocalization
    /// </summary>
    public class AddMetadataProvider
    {
        public void Process(PipelineArgs args)
        {
            ModelMetadataProviders.Current = new CustomMetadataProvider();
        }
    }
}