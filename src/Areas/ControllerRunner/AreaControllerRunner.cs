namespace Areas.ControllerRunner
{
    using Sitecore.Mvc.Controllers;
    using Sitecore.Mvc.Presentation;
    using System.Web.Mvc;

    /// <summary>
    /// CREDITS: http://sitecore-estate.nl/wp/2014/12/sitecore-mvc-areas/
    /// </summary>
    public class AreaControllerRunner : ControllerRunner
    {
        public string Area { get; set; }
        
        public AreaControllerRunner(string area, string controllerName, string actionName)
            : base(controllerName, actionName)
        {
            this.Area = area;
        }

        protected override IController CreateController()
        {
            var requestContext = PageContext.Current.RequestContext;
            requestContext.RouteData.DataTokens.Add("area", this.Area);
            return base.CreateController();
        }
    }
}