namespace MultipleForms
{
    using System.Web.Mvc;
    using Sitecore.Mvc.Helpers;

    /// <summary>
    /// CREDITS: http://www.reinoudvandalen.nl/blog/ultimate-fix-for-multiple-forms-on-one-page-with-sitecore-mvc/
    /// </summary>
    public static class SitecoreHelperExtensions
    {
        public static MvcHtmlString RenderingToken(this SitecoreHelper helper)
        {
            if (helper.CurrentRendering == null) return null;

            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes["type"] = "hidden";
            tagBuilder.Attributes["name"] = "sc_rendering_uid";
            tagBuilder.Attributes["value"] = helper.CurrentRendering.UniqueId.ToString();

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));

            // <input name="sc_rendering_uid" type="hidden" value="09f203da-ee7f-44dd-9959-2de246e077a6" />
        }
    }
}