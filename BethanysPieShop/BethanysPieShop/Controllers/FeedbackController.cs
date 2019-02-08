using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {

        private readonly IFeedbackRepository _feedbackRepository;

      
        public FeedbackController(IFeedbackRepository feedbackRepository) 
        {
            _feedbackRepository = feedbackRepository;
        }

        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)

        {
            if (ModelState.IsValid)
            {

                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            return View(feedback);
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }

       
    }
}