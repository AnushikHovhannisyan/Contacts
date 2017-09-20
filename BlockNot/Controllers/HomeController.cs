using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlockNot.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockNot.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext db;
        public HomeController(ContactContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Contacts.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            db.Contacts.Add(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id != null)
            {
                Contact contact = await db.Contacts.FirstOrDefaultAsync(p => p.ID == id);
                if (contact != null)
                    return View(contact);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            db.Contacts.Update(contact);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Contact contact = await db.Contacts.FirstOrDefaultAsync(p => p.ID == id);
                if (contact != null)
                {
                    return View(contact);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id!=null)
            {
                Contact contact = await db.Contacts.FirstOrDefaultAsync(p => p.ID == id);
                if (contact !=null)
                {
                    db.Contacts.Remove(contact);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
