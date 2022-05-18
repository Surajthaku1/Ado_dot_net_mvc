using Ado_dot_net_mvc.Models;
using Ado_dot_net_mvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ado_dot_net_mvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private categorydb category = new categorydb();
        public ActionResult Index()
        {
            var dept = category.GetAllCategory();
            return View(dept);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            if(ModelState.IsValid)
            {
                category.Createcategory(cate);

                return RedirectToAction("Index");

            }
            return View(cate);
            
        }
        public ActionResult Delete(int id)
        {
            category.Deletecategory(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var result =category.Getcategorybyid(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Category cate)
        {
             category.Updatecategory(cate);
            return RedirectToAction("Index");
        }
    }
}