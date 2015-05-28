namespace Areas.ControllerRunner
{
    using Sitecore.Data;
    using Sitecore.Mvc.Pipelines.Response.GetRenderer;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// CREDITS: http://sitecore-estate.nl/wp/2014/12/sitecore-mvc-areas/
    /// </summary>
    public class GetAreaControllerRendering : GetRendererProcessor
    {
        public override void Process(GetRendererArgs args)
        {
            // the new "Area Controller Rendering" template has to be added with a new field "Area"
            var areaControllerRendering = new ID("2A3E91A0-7987-44B5-AB34-35C2D9DE83B9");

            if (!args.RenderingTemplate.DescendsFromOrEquals(areaControllerRendering))
            {
                return;
            }

            args.Result = this.GetRender(args.Rendering);
        }

        private Renderer GetRender(Rendering rendering)
        {
            var action = rendering.RenderingItem.InnerItem["controller action"];
            var controller = rendering.RenderingItem.InnerItem["controller"];
            
            // get from the new field
            var area = rendering.RenderingItem.InnerItem["area"];

            return new AreaControllerRenderer { Action = action, Controller = controller, Area = area };
        }
    }
}