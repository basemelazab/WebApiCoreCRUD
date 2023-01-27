using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreCRUD.Model;
using WebApiCoreCRUD.Model.Data;

namespace WebApiCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext dbContext;
        public EmployeeController(EmployeeContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tblEmployee>>> GetAllEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<tblEmployee>> GetEmployeeByID(int id)
        {
           var emplyee=await dbContext.Employees.FindAsync(id);
            if (emplyee == null)
            {
                return NotFound();
            }
            return emplyee;
        }
        [HttpPost]
        public async Task<ActionResult<tblEmployee>> PostEmployee(tblEmployee employee)
        {
            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction("GetEmployeeByID", new {id=employee.Id},employee);
        }
        [HttpPut]
        public async Task<ActionResult<tblEmployee>> PutEmployee(int id,tblEmployee employee)
        {
           var emp=await dbContext.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound (id);
            }
            emp.Age = employee.Age;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Email = employee.Email;
            emp.Designation = employee.Designation;
            emp.DOJ = employee.DOJ;
            emp.Gender = employee.Gender;
            emp.IsMarried = employee.IsMarried;
            emp.IsActive = employee.IsActive;
            
            await dbContext.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpDelete]
        public async Task<ActionResult<tblEmployee>> DeleteEmployee(int id)
        {
            var emp = await dbContext.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound(id);
            }
            dbContext.Employees.Remove(emp);
            await dbContext.SaveChangesAsync();
            return Ok(emp);
        }

    }
}
