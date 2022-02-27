using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VizsgaremekAPI.BurgerAdatbazisEFCore;
using System.Linq;

namespace VizsgaremekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KoretekController : ControllerBase
    {
        burgeretteremContext _context = new();

        // GET: /<Koretek>
        [HttpGet]
        public List<Koret> Get()
        {
            return new(_context.Korets);
        }

        // GET: /<Koretek>/Aktiv
        [HttpGet("Aktiv")]
        public List<Koret> GetAktiv()
        {
            // == true szükséges mert az EF adatszerkezete nullable bool
            return new(_context.Korets.Where(x=>x.Aktiv == true));
        }

        // POST /<Koretek>
        [HttpPost]
        public StatusCodeResult Post([FromHeader]string Auth, Koret k)
        {
            if(Auth == AktivTokenek.AdminToken)
            {
                _context.Korets.Add(k);
                if (_context.SaveChanges() > 0)
                    return StatusCode(201);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
        // PUT /<Koretek>
        [HttpPut]
        public IActionResult Put([FromHeader]string Auth, Koret k)
        {
           if(Auth == AktivTokenek.AdminToken)
            {
                Koret aktk = _context.Korets.Find(k.Kazon);
                _context.Entry(aktk).CurrentValues.SetValues(k);
                if (_context.SaveChanges() > 0)
                    return StatusCode(200);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
    }
}
