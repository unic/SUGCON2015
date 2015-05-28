namespace Areas.Site
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Sitecore.Configuration;
    using Sitecore.Mvc.Configuration;
    using Sitecore.Pipelines;

    /// <summary>
    /// CREDITS: http://www.chrisvandesteeg.nl/2014/06/13/sitecore-mvc-in-a-multisite-environment-areas/
    /// </summary>
    public class InitializeRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            // get the Sitecore route
            var scRoute = RouteTable.Routes[MvcSettings.SitecoreRouteName] as Route;
            var index = RouteTable.Routes.IndexOf(scRoute);

            // register the available areas
            AreaRegistration.RegisterAllAreas();

            // loop through the sites and search for a "mvcArea" property
            foreach (var info in Factory.GetSiteInfoList())
            {
                if (info.Properties["mvcArea"] != null)
                {
                    // create a clone from the Sitecore route
                    var newRoute = new Route(scRoute.Url,
                        new RouteValueDictionary(scRoute.Defaults),
                        new RouteValueDictionary(scRoute.Constraints),
                        new RouteValueDictionary(scRoute.Constraints),
                        scRoute.RouteHandler);

                    newRoute.DataTokens.Add("area", info.Properties["mvcArea"]);
                    
                    // add a new constraint to validate if the current site matches the area
                    newRoute.Constraints.Add("sc-issite", new IsCorrectSiteContraint { SiteId = info.Name });

                    // add the new route BEFORE the Sitecore route
                    RouteTable.Routes.Insert(index, newRoute);
                }
            }
        }

        public class IsCorrectSiteContraint : IRouteConstraint
        {
            public string SiteId { get; set; }

            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                return Sitecore.Sites.SiteContext.Current.Name == this.SiteId;
            }
        }
    }
}