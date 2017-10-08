using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StatesName_by_County.Models;

namespace StatesName_by_County.Controllers
{
    public class HomeController : Controller
    {
        EmployeesDbEntities db = new EmployeesDbEntities();
        // GET: Home
        public ActionResult Index()
        {
            var countries = db.Countries.ToList();
            ViewBag.dropdownVD = new SelectList(db.Countries.ToList(), "CountryId", "CountryName");
            return View();
        }

        public ActionResult GetStates(string countryId)
        {
            try
            {
                if (countryId == "")
                {
                    return Content("-1");
                }
                else
                {
                    var cId = Convert.ToInt32(countryId);
                    var states = db.States.Where(s => s.CountryId == cId).ToList();
                    var statesLists = new List<StateDto>();
                    foreach (var item in states)
                    {
                        statesLists.Add(new StateDto { StateId = item.StateId, StateName = item.StateName });
                    }
                    return new JsonResult { Data = statesLists, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            catch (Exception)
            {

                throw;
            }


        }


        public ActionResult GetCities(string stateId)
        {
            try
            {
                if (stateId == "-1")
                {
                    return Content("-1");
                }
                else
                {
                    var sId = Convert.ToInt32(stateId);
                    var cities = db.Cities.Where(c => c.StateId == sId).ToList();
                    var citiesLists = new List<CityDto>();
                    foreach (var item in cities)
                    {
                        citiesLists.Add(new CityDto { CityId = item.CityId, CityName = item.CityName });
                    }
                    return new JsonResult { Data = citiesLists, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}