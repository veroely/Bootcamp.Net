using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ToDoContext _context;
        public AssignmentsController(ToDoContext context) => _context = context;


        [HttpGet]
        public async Task<IActionResult> getAll()
        {

            List<Assignment> list = new List<Assignment>();
            list = await _context.Assignments.ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            Assignment item = new Assignment();
            item = await _context.Assignments.FindAsync(id);

            if (item == null)
                return NotFound("No se econtro el item");

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Assignment assignment)
        {
            await _context.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Assignment assignment)
        {
            Assignment dbAssignment = await _context.Assignments.FindAsync(assignment.Id);
            if (dbAssignment == default(Assignment)) return NotFound();


            _context.Entry(dbAssignment).CurrentValues.SetValues(assignment);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
