namespace Areas.ControllerRunner
{
    using System.IO;

    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// CREDITS: http://sitecore-estate.nl/wp/2014/12/sitecore-mvc-areas/
    /// </summary>
    public class AreaControllerRenderer : Renderer
    {
        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public override void Render(TextWriter writer)
        {
            var controllerRunner = new AreaControllerRunner(this.Controller, this.Action, this.Area);
            var output = controllerRunner.Execute();

            if (string.IsNullOrWhiteSpace(output))
            {
                return;
            }

            writer.Write(output);
        }
    }
}