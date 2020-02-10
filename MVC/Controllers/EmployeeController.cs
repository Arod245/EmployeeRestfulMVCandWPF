using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            // IEnumerable<mvcEmployeeModel> empList;
            using (HttpResponseMessage response = await GlobalVariables.webApiClient.GetAsync("api/Employee")) 
            {
                if (response.IsSuccessStatusCode)
                {
                    var empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
                    return View(empList);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
           
        }
      public async Task<ActionResult> AddOrEdit(int id =0)
        {
            if (id == 0)
            {
                return View(new mvcEmployeeModel());
            }
            else 
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("api/Employee/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("api/Employee", emp).Result;
               
            }
            else {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("api/Employee/"+emp.EmployeeID, emp).Result;
            }
            return RedirectToAction("Index");
        }
     

        public ActionResult Delete(int id)
        {
           
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("api/Employee/"+id.ToString()).Result;
            return RedirectToAction("Index");
        }


    }
}