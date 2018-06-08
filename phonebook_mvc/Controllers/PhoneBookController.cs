using phonebook_mvc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Optimization;

namespace phonebook_mvc.Controllers
{
    public class PhoneBookController : Controller
    {
        //
        // GET: /Phonebook/
        public ActionResult Index()
        {
            IEnumerable<PhoneDetails> phonebooklist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("PhoneBook").Result;
            phonebooklist = response.Content.ReadAsAsync<IEnumerable<PhoneDetails>>().Result;
            return View(phonebooklist);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new PhoneDetails());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("PhoneBook/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<PhoneDetails>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(PhoneDetails phno)
        {
            if (ModelState.IsValid)
            {
                if (phno.ContactID == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("PhoneBook", phno).Result;
                    TempData["SuccessMessage"] = "Saved Successfully";
                }

                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("PhoneBook/" + phno.ContactID, phno).Result;
                    TempData["SuccessMessage"] = "Updated Successfully";
                }
                return RedirectToAction("Index");
            }
            return View("AddorEdit");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("PhoneBook/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
