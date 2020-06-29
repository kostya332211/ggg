using System;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using LABA3.Models;
using PhonesBook.Core.Entities;
using PhonesBook.Core.Repositories;

namespace LABA3.Controllers
{
    public class DictController : Controller
    {
        private readonly IUnitOfWork _uow;

        public DictController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public ActionResult Index()
        {
            return View(_uow.PersonRepository.All());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new PersonValidationModel());
        }

        public ActionResult Partial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(PersonValidationModel person)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            try
            {
                _uow.PersonRepository.Insert(new Person()
                {
                    Id = Guid.NewGuid(),
                    PersonName = person.PersonName,
                    PhoneNumber = person.PhoneNumber
                });
                _uow.Commit();
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException?.InnerException != null)
                    Response.Write(e.InnerException.InnerException.Message);
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public void DeleteSave(string phone)
        {
            try
            {
                Predicate<Person> predicate = x => x.PhoneNumber == phone;
                _uow.PersonRepository.Delete(predicate);
                _uow.Commit();
                Response.Redirect("~/Dict/Index");
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException?.InnerException != null)
                    Response.Write(e.InnerException.InnerException.Message);
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
        }

        public ActionResult Update()
        {
            return View();
        }

        public void UpdateSave()
        {
            try
            {
                Predicate<Person> predicate = x => x.PhoneNumber == Request.Params["phone"].ToString();
                var person = _uow.PersonRepository.Get(predicate);
                if (Request.Params["phoneNew"] != null)
                {
                    person.PhoneNumber = Request.Params["phoneNew"];
                }
                person.PersonName = Request.Params["name"];
                _uow.Commit();
                Response.Redirect("~/Dict/Index");
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException?.InnerException != null)
                    Response.Write(e.InnerException.InnerException.Message);
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
        }

    }
}