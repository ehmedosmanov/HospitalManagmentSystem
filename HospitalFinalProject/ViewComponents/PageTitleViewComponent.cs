using HospitalFinalProject.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalFinalProject.ViewComponents
{
    public class PageTitleViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public PageTitleViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string pageTitle, string[] breadcrumbs)
        {
            ViewBag.PageTitle = pageTitle;
            ViewBag.Breadcrumbs = breadcrumbs;
            return View();
        }
    }
}
