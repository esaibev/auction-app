using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab2.Core;
using lab2.Core.Interfaces;
using lab2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using lab2.Persistence;

namespace lab2.Controllers
{
    [Authorize]
    public class AuctionsController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: Auctions
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAllActive();
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: Auctions/Details/5
        public ActionResult Details(int id)
        {
            var auction = _auctionService.GetAuctionById(id);
            var auctionVM = AuctionVM.FromAuction(auction);
            return View(auctionVM);
        }

        // GET: Auctions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auctions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVM vm)
        {
            if (vm.EndDate <= DateTime.Now)
            {
                ModelState.AddModelError("EndDate", "End date must be in the future.");
            }

            if (ModelState.IsValid)
            {
                Auction auction = new Auction()
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    StartingPrice = vm.StartingPrice,
                    EndDate = vm.EndDate,
                    Auctioneer = User.Identity.Name
                };
                
                _auctionService.AddAuction(auction);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Auctions/Edit/5
        public ActionResult Edit(int id)
        {
            var auction = _auctionService.GetAuctionById(id);

            if(!auction.Auctioneer.Equals(User.Identity.Name))
                return Unauthorized();

            var editAuctionVM = EditAuctionVM.FromAuction(auction);
            return View(editAuctionVM);
        }

        // POST: Auctions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditAuctionVM vm)
        {
            if (ModelState.IsValid)
            {
                var auction = _auctionService.GetAuctionById(id);

                if (!auction.Auctioneer.Equals(User.Identity.Name))
                    return Unauthorized();

                auction.Description = vm.Description;
                _auctionService.UpdateAuction(auction);

                return RedirectToAction(nameof(Details), new { id = auction.Id });
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeBid(int AuctionId, int BidAmount)
        {
            var auction = _auctionService.GetAuctionById(AuctionId);

            if (auction == null)
            {
                return NotFound("Auction not found.");
            }

            if (auction.Auctioneer.Equals(User.Identity.Name))
            {
                return BadRequest("Cannot bid on your own auction.");
            }

            if (!auction.BidIsValid(BidAmount))
            {
                return BadRequest("Bid amount must be higher than the starting price and the current highest bid.");
            }

            Bid bid = new Bid()
            {
                Bidder = User.Identity.Name,
                Amount = BidAmount,
                DateMade = DateTime.Now,

            };

            auction.addBid(bid);
            _auctionService.MakeBid(auction);
            return RedirectToAction(nameof(Details), new { id = auction.Id });
        }

        /*
        // GET: Auctions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auctions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}