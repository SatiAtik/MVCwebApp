using MVCwebApp.Filters;
using MVCwebApp.Models;
using MVCwebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCwebApp.Controllers
{
    public class BulkUploadController : AsyncController
    {
        // GET: BulkUpload
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        [AdminFilter]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {            
            List<Employee> employees = await Task.Factory.StartNew<List<Employee>> 
                (()=>GetEmployees(model));
            EmployeeBusinessLayer empbsl = new EmployeeBusinessLayer();
            empbsl.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader streamReader = new StreamReader(model.fileUpload.InputStream);
            streamReader.ReadLine(); // Assume first line is header
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var values = line.Split(','); // values separated with comma
                Employee emp = new Employee();
                emp.FirstName = values[0];
                emp.LastName = values[1];
                emp.Salary = int.Parse(values[2]);
                employees.Add(emp);
            }
            return employees;
        }
    }
}