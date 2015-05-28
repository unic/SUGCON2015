namespace Areas.AreaPipeline
{
    using Sitecore.Mvc.Pipelines.Response.RenderRendering;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// CREDITS: http://jockstothecore.com/sitecore-support-for-mvc-areas/
    /// </summary>
    public class AddRenderingArea : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            var pageContext = PageContext.CurrentOrNull;
            var requestContext = pageContext.RequestContext;

            requestContext.RouteData.DataTokens["area"] = this.GetAreaName();
        }

        private string GetAreaName()
        {
            // run pipeline "mvc.getArea" to resolve the area

            return "Resolved Area";
        }
    }
}