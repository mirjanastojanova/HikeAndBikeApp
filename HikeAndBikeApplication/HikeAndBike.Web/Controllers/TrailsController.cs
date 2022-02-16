using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HikeAndBike.Domain.DTO;
using HikeAndBike.Domain.Domain;
using HikeAndBike.Service.Interface;

namespace HikeAndBike.Web.Controllers
{
    public class TrailsController : Controller
    {
        private readonly ITrailService _trailService;

        public TrailsController(ITrailService trailService)
        {
            _trailService = trailService;
        }

        // GET: Trails
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                var allTrails = this._trailService.GetAllTrails();
                return View(allTrails);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult AddTrailToShoppingCart(Guid? id)
        {
            var model = this._trailService.GetShoppingCartInfo(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTrailToShoppingCart([Bind("TrailId", "Quantity")] AddTrailToShoppingCartDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._trailService.AddToShoppingCart(item, userId);

            if (result)
            {
                return RedirectToAction("Index", "Trails");
            }

            return View(item);
        }

        // GET: Trails/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = this._trailService.GetDetailsForTrail(id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // GET: Trails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Image,Difficulty,Price,Date,Length,Guide")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                this._trailService.CreateNewTrail(trail);
                return RedirectToAction(nameof(Index));
            }
            return View(trail);
        }

        // GET: Trails/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = this._trailService.GetDetailsForTrail(id);
            if (trail == null)
            {
                return NotFound();
            }
            return View(trail);
        }

        // POST: Trails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Description,Image,Difficulty,Price,Date,Length,Guide")] Trail trail)
        {
            if (id != trail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._trailService.UpdateExistingTrail(trail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailExists(trail.Id))
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
            return View(trail);
        }

        // GET: Trails/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = this._trailService.GetDetailsForTrail(id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // POST: Trails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._trailService.DeleteTrail(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrailExists(Guid id)
        {
            return this._trailService.GetDetailsForTrail(id) != null;
        }
    }
}
