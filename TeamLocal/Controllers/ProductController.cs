using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TeamLocal.Data;
using TeamLocal.Models;

using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace TeamLocal.Controllers
{
    [Authorize(Roles = "BusinessOwner")]
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                var listAll = _context.Products.ToList();

                return View(listAll);
            }
            var list = _context.Products.Where(b => b.BusinessID == id).ToList();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product record)
        {
            var selectedBusiness = _context.Businesses.Where(b => b.BusinessID == record.BusinessID).SingleOrDefault();
            var product = new Product();

            product.ProductName = record.ProductName;
            product.Description = record.Description;
            product.Price = record.Price;
            product.Business = selectedBusiness;

            //if(ImagePath != null)
            //{
            //    if (ImagePath.Length > 0)
            //    {
            //        var filePath = Path.Combine(Directory.GetCurrentDirectory(),
            //            "wwwroot/images/products", ImagePath.FileName);

            //        using (var stream = new FileStream(filePath, FileMode.Create))
            //        {
            //            ImagePath.CopyTo(stream);
            //        }
            //        product.ImagePath = ImagePath.FileName;
            //    }
            //}

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Product record)
        {
            var product = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            product.ProductName = record.ProductName;
            product.Description = record.Description;
            product.Price = record.Price;

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var product = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
