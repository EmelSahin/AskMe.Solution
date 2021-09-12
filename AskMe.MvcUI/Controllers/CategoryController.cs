using AskMe.Entities.Model;
using AskMe.Interfaces;
using AskMe.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskMe.MvcUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _category;



        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        public ActionResult List()
        {
            var categoryList = _category.GetAll();
            return View(categoryList);
        }

        public ActionResult Edit(int id)
        {
            var category = _category.Get(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            try
            {
                var getCategori = _category.Get(model.Id);
                getCategori.Name = model.Name;
                getCategori.Description = model.Description;
                getCategori.EditDate = DateTime.Now;
                getCategori.EditUser = 1;
                _category.Update(getCategori);
                return RedirectToAction("List", "Category");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                Category category = new Category()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreateDate = DateTime.Now,
                    CreateUser = 1
                };

                _category.Add(category);
                return RedirectToAction("List", "Category");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult Remove(int id)
        {
            var getCategory = _category.Get(id);
            _category.Remove(getCategory.Id);
            return Redirect("/category/list");
        }
    }
}