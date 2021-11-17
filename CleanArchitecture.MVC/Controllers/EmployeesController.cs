﻿using CleanArchitecture.DataAccess.Core.Entities;
using CleanArchitecture.DataAccess.Core.Interfaces;
using CleanArchitecture.MVC.ViewModels;
using PagedList;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _unitOfWork.Employees.GetAll();
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var viewModel = new EmployeeViewModel()
            {
                Departments = _unitOfWork.Departments.GetAll().ToList()
            };
            return View(viewModel);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employees.Create(employee);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeViewModel()
            {
                Employee = new Employee(),
                Departments = _unitOfWork.Departments.GetAll().ToList()
            };
            return View(viewModel);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EmployeeViewModel()
            {
                Employee = employee,
                Departments = _unitOfWork.Departments.GetAll().ToList()
            };
            return View(viewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,DepId,Salary,HireDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employees.Update(employee);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewModel = new EmployeeViewModel()
            {
                Employee = employee,
                Departments = _unitOfWork.Departments.GetAll().ToList()
            };

            return View(viewModel);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _unitOfWork.Employees.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Employee employee = _unitOfWork.Employees.GetById(id);

            if (employee == null)
                return HttpNotFound();

            _unitOfWork.Employees.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult EmployeesWithPaging(int? page)
        {
            var employees = _unitOfWork.Employees.Get()
                .OrderBy(e => e.ID)
                .ToPagedList(page ?? 1, 3);

            return View(employees);
        }
    }
}
