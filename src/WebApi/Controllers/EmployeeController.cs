using AutoMapper;
using Database.Repositories;
using Domain;
using System;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            if(employeeRepository == null) throw new ArgumentNullException("employeeRepository");
            this.employeeRepository = employeeRepository;
        }
        
  
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(this.employeeRepository.GetEmployees());
        }

     
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(this.employeeRepository.GetEmployeeDetail(id));
        }


        [HttpPost]
        [Route("addEmployee")]
        public void Post(EmployeeModel employeeModel)
        {
            var employee = Mapper.Map<Employee>(employeeModel);
            this.employeeRepository.AddEmployee(employee);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}