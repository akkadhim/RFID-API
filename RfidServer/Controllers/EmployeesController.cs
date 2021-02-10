using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RfidServer.Models;

namespace RfidServer.Controllers
{
    public class EmployeesController : ApiController
    {
        private RfidModel db = new RfidModel();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            var emp = db.Employees.FirstOrDefault();
            emp.RequestNo++;
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            return db.Employees;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(string id)
        {
            var emp = db.Employees.FirstOrDefault();
            emp.RequestNo++;
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            Employee employee = db.Employees.Where(x => x.Rfid == id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        //// GET: api/Employees/5
        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult GetEmployee(long id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employee);
        //}

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(long id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(long id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(long id)
        {
            return db.Employees.Count(e => e.EmployeeId == id) > 0;
        }
    }
}