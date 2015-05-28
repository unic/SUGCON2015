namespace MultipleForms.Controllers
{
    using System.Web.Mvc;

    using MultipleForms.Models;

    public class SampleController : Controller
    {
        [HttpGet]
        public ActionResult SampleAction()
        {
            return this.View(new FormModel());
        }

        [HttpPost]
        public ActionResult SampleAction(FormModel model)
        {
            return this.View(model);
        }
    }
}