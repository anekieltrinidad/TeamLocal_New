using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TeamLocal.Data;
using TeamLocal.Models;
using Microsoft.AspNetCore.Authorization;

namespace TeamLocal.Controllers
{
    [Authorize(Roles = "BusinessOwner")]
    public class BusinessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Businesses.Include(b => b.Category).ToList();
            return View(list);
        }
        // View Page Per Category
        public IActionResult CarServices()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 1");
            return View(list);
        }
        public IActionResult Cleaning()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 3");
            return View(list);
        }
        public IActionResult Clothing()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 4");
            return View(list);
        }

        public IActionResult Food()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 5");
            return View(list);
        }
        public IActionResult Health()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 6");
            return View(list);
        }
        public IActionResult HomeImprovement()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 7");
            return View(list);
        }
        public IActionResult Technology()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 8");
            return View(list);
        }
        public IActionResult Other()
        {
            var list = _context.Businesses.FromSqlRaw("SELECT * FROM Businesses WHERE CategoryID = 9");
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Business record)
        {
            var selectedCategory = _context.CategoryBusinesses.Where(c => c.CategoryID == record.CategoryID).SingleOrDefault();
            var business = new Business();
            business.BusinessName = record.BusinessName;
            business.BusinessAddress = record.BusinessAddress;
            business.ContactInfo = record.ContactInfo;
            business.Overview = record.Overview;
            business.SocialMedia = record.SocialMedia;
            business.Category = selectedCategory;

            _context.Businesses.Add(business);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var business = _context.Businesses.Where(b => b.BusinessID == id).SingleOrDefault();
            if (business == null)
            {
                return RedirectToAction("Index");
            }

            return View(business);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Business record)
        {
            var business = _context.Businesses.Where(b => b.BusinessID == id).SingleOrDefault();
            var selectedCategory = _context.CategoryBusinesses.Where(c => c.CategoryID == record.CategoryID).SingleOrDefault();
            business.BusinessName = record.BusinessName;
            business.BusinessAddress = record.BusinessAddress;
            business.ContactInfo = record.ContactInfo;
            business.Overview = record.Overview;
            business.SocialMedia = record.SocialMedia;
            business.Category = selectedCategory;

            _context.Businesses.Update(business);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var business = _context.Businesses.Where(b => b.BusinessID == id).SingleOrDefault();
            if (business == null)
            {
                return RedirectToAction("Index");
            }

            _context.Businesses.Remove(business);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
