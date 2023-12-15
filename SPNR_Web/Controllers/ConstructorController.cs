﻿using Microsoft.AspNetCore.Mvc;
using SPNR_Web.DataAccess;
using SPNR_Web.Models.DataBase;
using SPNR_Web.Utils;

namespace SPNR_Web.Controllers
{
    public class ConstructorController : Controller
    {
        IUnitOfWork _unit;
        IFileHandler _fileHandler;
        public ConstructorController(IUnitOfWork unit, IFileHandler fileHandler) 
        {
            _unit = unit;
            _fileHandler = fileHandler;
        }
        public IActionResult Event()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Event(Event @event, IFormFile? file)
        {
            _fileHandler.Save(file);
            return ToHome();
        }

        [HttpPost]
        public IActionResult News(News news)
        {
            if (news is null) return BadRequest();
            news.Id = Guid.NewGuid();
            _unit.NewsRepo.Add(news);
            _unit.Save();
            return Ok(news.Id);
        }

        [HttpPost]
        public IActionResult Media(MediaLink link)
        {
            if (link is null) link = new MediaLink();
            link.Id = Guid.NewGuid();
            _unit.MediaLinkRepo.Add(link);
            _unit.Save();
            return Ok(link.Id);
        }

        [HttpDelete]
        public IActionResult Event(Guid id) 
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult News(Guid id)
        {
            News news = _unit.NewsRepo.ReadFirst(n => n.Id == id);
            if (news is null) return BadRequest();
            _unit.NewsRepo.Remove(news);
            _unit.Save();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Media(Guid id)
        {
            MediaLink link = _unit.MediaLinkRepo.ReadFirst(l => l.Id == id);
            if (link is null) return BadRequest();
            _unit.MediaLinkRepo.Remove(link);
            _unit.Save();
            return Ok();
        }

        [NonAction]
        IActionResult ToHome()
        {
            return RedirectToRoute(new RouteValueDictionary()
            {
                { "controller", "Home" },
                { "action", "Index" }
            });
        }
    }
}
