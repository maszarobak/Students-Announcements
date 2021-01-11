using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students_Announcement.Models;
using Students_Announcements.Models;


namespace Students_Announcement.Controllers
{
    [Authorize]
    public class AnnouncementsController : Controller
    {
        private readonly AnnouncementContext _context;

        public AnnouncementsController(AnnouncementContext context)
        {
            _context = context;
        }

        [ResponseCache(Duration = 60)]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchBy, string search)
        {
            //var countries = from m in _context.Announcements
            //   select m;
            if (searchBy == "tytul")
            {
                return View( _context.Announcements.Where(x => x.tytul.StartsWith(search) || search == null).ToList());
            } 
            else if(searchBy == "kategoria")
            {
                return View( _context.Announcements.Where(x => x.kategoria.StartsWith(search) || search == null).ToList());

            }
            else if(searchBy == "uczelnia")
            {
                return View(_context.Announcements.Where(x => x.uczelnia.StartsWith(search) || search == null).ToList());
            } 
            else  
            {
                return View(await _context.Announcements.ToListAsync());
            } 
        }

        [ResponseCache(Duration = 60)]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .FirstOrDefaultAsync(m => m.id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }
        
    

        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,uczelnia,wydzial,autor,tytul,kategoria,opis")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(announcement);
                    await _context.SaveChangesAsync();
                    // return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                TempData["Info"] = "Dodano ogloszenie: " + announcement.tytul;
               
                return RedirectToAction(nameof(Create));
            }
            return View(announcement);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }

       
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,uczelnia,wydzial,autor,tytul,kategoria,opis")] Announcement announcement)
        {
            if (id != announcement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(announcement);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .FirstOrDefaultAsync(m => m.id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.id == id);
        }
    }
}
