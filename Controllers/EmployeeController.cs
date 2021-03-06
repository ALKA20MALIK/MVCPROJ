﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCUsingBusinessObjects.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer =new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                foreach (string key in formCollection.AllKeys)
                {
                    Response.Write("Key = " + key + "  ");
                    Response.Write("Value = " + formCollection[key]);
                    Response.Write("<br/>");
                }
            }
            
            Employee employee = new Employee();
            // Retrieve form data using form collection
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
            employee.DateOfBirth =
                Convert.ToDateTime(formCollection["DateOfBirth"]);

            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }
        public ActionResult Edit()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        public ActionResult Details()
        {
            EmployeeBusinessLayer employeeBusinessLayer =new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        public ActionResult Delete()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        public string CCharpVersion()
        {
           string Version=Environment.Version.ToString();
            return Version;
        }

    }
}