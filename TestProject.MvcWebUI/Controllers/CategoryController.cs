using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Business.Abstract;
using TestProject.Entity.Concreate;
using TestProject.MvcWebUI.Models;

namespace TestProject.MvcWebUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult GetCategories()
        {
            var categoryViewModel = new CategoryViewModel
            {
                Categories = _categoryService.GetList()
            };

            return View(categoryViewModel);
        }
        public IActionResult Add(CategoryViewModel categoryView)
        {
            if (ModelState.IsValid)
            {
                var categoryforAdd = new Category
                {
                    AddedBy = "Şevki",
                    AddedDate = DateTime.Now,
                    IsActive = true,
                    Name = categoryView.Category.Name
                };
                try
                {
                    _categoryService.Add(categoryforAdd);
                    return RedirectToAction("GetCategories");
                }
                catch (Exception e)
                {
                }
            }
            return RedirectToAction("GetCategories");
        }

  
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return Json(0);

            }
            return Json(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoryIsValid = _categoryService.GetById(categoryViewModel.Category.Id);
                if (categoryIsValid == null)
                {
                    return RedirectToAction("GetCategories");

                }
                try
                {
                    var categoryForAdd = new Category
                    {
                        AddedBy = categoryIsValid.AddedBy,
                        AddedDate = categoryIsValid.AddedDate,
                        Id = categoryIsValid.Id,
                        IsActive = categoryViewModel.Category.IsActive,
                        Name = categoryViewModel.Category.Name
                    };
                    _categoryService.Update(categoryForAdd);
                    return RedirectToAction("GetCategories");
                }
                catch (Exception)
                {

                    return RedirectToAction("GetCategories");
                }
            }
            return RedirectToAction("GetCategories");
        }
        public JsonResult Delete(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }
            var categoryIsValid = _categoryService.GetById(id);
            if (categoryIsValid == null)
            {
                return Json(0);
            }
            try
            {
                _categoryService.Delete(categoryIsValid);
                return Json(1);
            }
            catch (Exception)
            {

                return Json(0);
            }
        }
    }
}
