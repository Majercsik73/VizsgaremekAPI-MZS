using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VizsgaremekAPI.BurgerAdatbazisEFCore;
using System.Linq;

namespace VizsgaremekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItalokController : ControllerBase
    {
        burgeretteremContext _context = new();

        // GET: /<Italok>
        [HttpGet]
        public List<Ital> Get()
        {
            return new(_context.Itals);
        }
        // GET: /<Italok>/Aktiv
        [HttpGet("Aktiv")]
        public List<Ital> GetAktiv()
        {
            // == true szükséges mert az EF adatszerkezete nullable bool
            return new(_context.Itals.Where(x => x.Aktiv == true));
        }
        // POST /<Italok>
        [HttpPost]
        public StatusCodeResult Post([FromHeader]string Auth, Ital i)
        {
            if(Auth == AktivTokenek.AdminToken)
            {
                _context.Itals.Add(i);
                if (_context.SaveChanges() > 0)
                    return StatusCode(201);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
        // PUT /<Italok>
        [HttpPut]
        public IActionResult Put([FromHeader]string Auth, Ital i)
        {
           if(Auth == AktivTokenek.AdminToken)
            {
                Ital akti = _context.Itals.Find(i.Iazon);
                _context.Entry(akti).CurrentValues.SetValues(i);
                if (_context.SaveChanges() > 0)
                    return StatusCode(200);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
    }
}
