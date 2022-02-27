using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VizsgaremekAPI.BurgerAdatbazisEFCore;
using System.Linq;

namespace VizsgaremekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Produces("application/json")] //LS -től átvéve

    public class BurgerekController : ControllerBase
    {
        burgeretteremContext _context = new();

        // GET: /<Burgers>
        [HttpGet]
        public List<Burger> Get()
        {
            return new(_context.Burgers);
        }
        // GET: /<Burgers>/Aktiv
        [HttpGet("Aktiv")]
        public List<Burger> GetAktiv()
        {
            // == true szükséges mert az EF adatszerkezete nullable bool  
            return new(_context.Burgers.Where(x=>x.Aktiv == true));
        }

        // PUT /<Burgers>
        [HttpPost]
        public StatusCodeResult Post([FromHeader]string Auth, Burger b)
        {
            if(Auth == AktivTokenek.AdminToken)
            {
                _context.Burgers.Add(b);
                if (_context.SaveChanges() > 0)
                    return StatusCode(201);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
        // PUT /<Burgers>
        [HttpPut]
        public IActionResult Put([FromHeader]string Auth, Burger b)
        {
           if(Auth == AktivTokenek.AdminToken)
            {
                Burger aktb = _context.Burgers.Find(b.Bazon);
                _context.Entry(aktb).CurrentValues.SetValues(b);
                if (_context.SaveChanges() > 0)
                    return StatusCode(200);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
    }
}
