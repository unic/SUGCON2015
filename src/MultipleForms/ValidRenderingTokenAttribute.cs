namespace MultipleForms
{
    using System;
    using System.Web.Mvc;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// CREDITS: http://www.reinoudvandalen.nl/blog/ultimate-fix-for-multiple-forms-on-one-page-with-sitecore-mvc/
    /// </summary>
    public class ValidRenderingTokenAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            var rendering = RenderingContext.CurrentOrNull;
            if (rendering == null) return false;

            Guid postedId;
            return Guid.TryParse(controllerContext.HttpContext.Request.Form["sc_rendering_uid"], out postedId) && postedId.Equals(rendering.Rendering.UniqueId);
        }
    }
}