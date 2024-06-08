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
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult GetProducts()
        {
            var productViewModel = new ProductViewModel
            {
                Products = _productService.GetList()
            };
            return View(productViewModel);
        }
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var productIsValid = _productService.GetByName(productViewModel.Product.Name);
                if (productIsValid != null)
                {
                    return RedirectToAction("GetProducts");
                }
                var productForAdd = new Product
                {
                    AddedDate = DateTime.Now,
                    AddedBy = "Sevki Uzun",
                    CategoryId = 1,
                    Explanation = productViewModel.Product.Explanation,
                    Height = productViewModel.Product.Height,
                    Name = productViewModel.Product.Name,
                    Weight = productViewModel.Product.Weight,
                    Width = productViewModel.Product.Width
                };
                try
                {
                    _productService.Add(productForAdd);
                    return RedirectToAction("GetProducts");
                }
                catch (Exception)
                {

                    return RedirectToAction("GetProducts");
                }
            }
            return RedirectToAction("GetProducts");
        }
        public JsonResult Edit(int id)
        {
            if (id > 0)
            {
                var result = _productService.GetById(id);
                return Json(result);
            }
            return Json(0);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var productIsValid = _productService.GetById(productViewModel.Product.Id);
                if (productIsValid == null)
                {
                    return RedirectToAction("GetProducts");
                }
                try
                {
                    var productForAdd = new Product
                    {
                        AddedBy = productIsValid.AddedBy,
                        AddedDate = productIsValid.AddedDate,
                        CategoryId = productViewModel.Product.CategoryId,
                        Name = productViewModel.Product.Name,
                        Explanation = productIsValid.Explanation,
                        Id = productIsValid.Id,
                        Height = productViewModel.Product.Height,
                        Weight = productViewModel.Product.Weight,
                        Width = productViewModel.Product.Width
                    };
                    _productService.Update(productForAdd);
                    return RedirectToAction("GetProducts");
                }
                catch (Exception)
                {

                    return RedirectToAction("GetProducts");
                }
            }
            return RedirectToAction("GetProducts");
        }
    }
}
