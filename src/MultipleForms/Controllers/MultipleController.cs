namespace MultipleForms.Controllers
{
    using System.Web.Mvc;

    using MultipleForms.Models;

    public class MultipleController : Controller
    {
        public ActionResult Action1()
        {
            return this.View(new FormModel());
        }

        [HttpPost]
        [ValidRenderingToken]
        [ValidateAntiForgeryToken]
        public ActionResult Action1(FormModel model)
        {
            return this.View(model);
        }

        public ActionResult Action2()
        {
            return this.View(new FormModel());
        }

        [HttpPost]
        [ValidRenderingToken]
        [ValidateAntiForgeryToken]
        public ActionResult Action2(FormModel model)
        {
            return this.View(model);
        }
    }
}