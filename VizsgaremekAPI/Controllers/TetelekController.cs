using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VizsgaremekAPI.BurgerAdatbazisEFCore;
using System.Linq;

namespace VizsgaremekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TetelekController : ControllerBase
    {
        burgeretteremContext _context = new();

        // GET: /<Tetelek>
        [HttpGet]
        public IActionResult Get([FromHeader] string Auth)
        {
            if (Auth == AktivTokenek.AdminToken || Auth == AktivTokenek.UserToken)
                return StatusCode(200, _context.Tetels);

            return StatusCode(403);
        }

        [HttpGet("Pultos")]
        public IActionResult GetPultos([FromHeader] string Auth)
        {
            if (Auth == AktivTokenek.AdminToken || Auth == AktivTokenek.UserToken)
            {
                List<Tetel> pultosTetelek = _context.Tetels.Where(x => x.Iazon > 1 && x.Italstatus < 2 && x.Etelstatus < 3).ToList();
                pultosTetelek.ForEach(x =>
                {
                    x.IazonNavigation = _context.Itals.First(i => x.Iazon == i.Iazon);
                });
                return StatusCode(200, pultosTetelek);
            }
            return StatusCode(403);
        }
        [HttpGet("Szakacs")]
        public IActionResult GetSzakacs([FromHeader] string Auth)
        {
            if (Auth == AktivTokenek.AdminToken || Auth == AktivTokenek.UserToken)
            {
                List<Tetel> szakacsTetelek = _context.Tetels.Where(x => (x.Bazon > 1 || x.Dazon > 1 || x.Iazon > 1) && x.Italstatus < 3 && x.Etelstatus < 2).ToList();
                szakacsTetelek.ForEach(x =>
                {
                    x.BazonNavigation = _context.Burgers.First(b => b.Bazon == x.Bazon);
                    x.DazonNavigation = _context.Desszerts.First(d => d.Dazon == x.Dazon);
                    x.KazonNavigation = _context.Korets.First(k => k.Kazon == x.Kazon);
                });
                return StatusCode(200, szakacsTetelek);
            }
            return StatusCode(403);
        }

        // POST /<Tetelek>
        [HttpPost]
        public StatusCodeResult Post([FromHeader] string Auth, Tetel t)
        {
            if (Auth == AktivTokenek.AdminToken || Auth == AktivTokenek.UserToken)
            {
                _context.Tetels.Add(t);
                if (_context.SaveChanges() > 0)
                    return StatusCode(201);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
        // PUT /<Tetelek>
        [HttpPut]
        public IActionResult Put([FromHeader] string Auth, Tetel t)
        {
            if (Auth == AktivTokenek.AdminToken || Auth == AktivTokenek.UserToken)
            {
                Tetel aktt = _context.Tetels.Find(t.Tazon);
                _context.Entry(aktt).CurrentValues.SetValues(t);
                if (_context.SaveChanges() > 0)
                    return StatusCode(200);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }

        // DELETE /<Tetelek>/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader] string Auth, int id)
        {
            if (Auth == AktivTokenek.AdminToken || Auth == AktivTokenek.UserToken)
            {
                Tetel t = _context.Tetels.Find(id);
                _context.Tetels.Remove(t);
                if (_context.SaveChanges() > 0)
                    return StatusCode(200);
                else
                    return StatusCode(500);
            }

            return StatusCode(403);
        }
    }
}
