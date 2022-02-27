using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VizsgaremekAPI.BurgerAdatbazisEFCore;
using System.Linq;

namespace VizsgaremekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DesszertekController : ControllerBase
    {
        burgeretteremContext _context = new();

        // GET: /<Desszertek>
        [HttpGet]
        public List<Desszert> Get()
        {
            return new(_context.Desszerts);
        }
        // GET: /<Desszertek>/Aktiv
        [HttpGet("Aktiv")]
        public List<Desszert> GetAktiv()
        {
            // == true szükséges mert az EF adatszerkezete nullable bool  
            return new(_context.Desszerts.Where(x => x.Aktiv == true));
        }

        // POST /<Desszertek>
        [HttpPost]
        public StatusCodeResult Post([FromHeader]string Auth, Desszert d)
        {
            if(Auth == AktivTokenek.AdminToken)
            {
                _context.Desszerts.Add(d);
                if (_context.SaveChanges() > 0)
                    return StatusCode(201);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
        // PUT /<Desszertek>
        [HttpPut]
        public IActionResult Put([FromHeader]string Auth, Desszert d)
        {
           if(Auth == AktivTokenek.AdminToken)
            {
                Desszert aktd = _context.Desszerts.Find(d.Dazon);
                _context.Entry(aktd).CurrentValues.SetValues(d);
                if (_context.SaveChanges() > 0)
                    return StatusCode(200);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
    }
}
