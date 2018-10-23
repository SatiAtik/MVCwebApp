using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCwebApp.Filters;
using MVCwebApp.Models;
using MVCwebApp.ViewModels;

namespace MVCwebApp.Controllers
{
    public class EmployeeController : Controller
    {
        [HeaderFooterFilter]
        [Authorize]
        public ActionResult Index()
        {
            List<EmployeeViewModel> vmEmpList = new List<EmployeeViewModel>();
            EmployeeBusinessLayer empBsl = new EmployeeBusinessLayer();
            List<Employee> empList = empBsl.GetEmployees();
            EmployeeListViewModel vmlEmp = new EmployeeListViewModel();

            for (int i = 0; i < empList.Count; i++)
            {
                EmployeeViewModel evm = new EmployeeViewModel();

                evm.EmployeeName = empList[i].FirstName + " " + empList[i].LastName;
                evm.Salary = string.Format("{0:C}", empList[i].Salary);
                if (empList[i].Salary > 15000)
                {
                    evm.SalaryColor = "yellow";
                }
                else
                {
                    evm.SalaryColor = "green";
                }
                vmEmpList.Add(evm);
            }
            vmlEmp.Employees = vmEmpList;
            return View("Index", vmlEmp);
        }

        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel createEmployeeViewModel = new CreateEmployeeViewModel();
            return View("CreateEmployee", createEmployeeViewModel);
        }

        [HeaderFooterFilter]
        [AdminFilter]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case ("Save Employee"):

                    if (ModelState.IsValid) { 
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;

                        if (e.Salary.HasValue)
                        {
                            vm.Salary = string.Format("{0:C}", e.Salary);
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm);
                    }
                case ("Cancel"):
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        [ChildActionOnly]
        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}