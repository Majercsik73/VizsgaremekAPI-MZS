using VizsgaremekAPI.BurgerAdatbazisEFCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VizsgaremekAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FelhasznalokController : ControllerBase
    {
        burgeretteremContext _context = new();

        // GET: api/<FelhasznalokController>
        [HttpGet]
        public IActionResult Get([FromHeader]string Auth = null)
        {
            
            if (Auth == AktivTokenek.AdminToken)
                return StatusCode(200, _context.Felhasznalos);

            return StatusCode(403,"Nincs jogod hozzá!");

        }
        // GET: /Felhasználó ellenőrzése regisztrációnál
        [HttpPost("Web")]
        public IActionResult PostWeb(Felhasznalo felh)
        {
            Felhasznalo felhReg = _context.Felhasznalos.FirstOrDefault(x => x.Email == felh.Email);
            if (felhReg is not null)
            {
                return StatusCode(200, felhReg);
            }
            return StatusCode(404, "Hibás felhasználónév vagy jelszó!");
        }

        // POST api/<FelhasznalokController>  Bejelentkezés
        [HttpPost]
        public IActionResult Post(Felhasznalo bejelFelh)
        {
            Felhasznalo f = _context.Felhasznalos.FirstOrDefault(x => x.Email == bejelFelh.Email && x.Pw == bejelFelh.Pw);
            if (f is not null)
            {
                Response.Headers.Add("Auth", f.Jog switch { < 4 => AktivTokenek.UserToken, 4 => AktivTokenek.AdminToken, _ => null });
                return StatusCode(200, f);
            }
            
            else { return StatusCode(404, "Hibás felhasználónév vagy jelszó!"); }
        }

        // PUT api/<FelhasznalokController>  Regisztráció
        [HttpPut]
        public IActionResult Put(Felhasznalo f)
        {
            Felhasznalo letezike = _context.Felhasznalos.FirstOrDefault(x => x.Email == f.Email);
            if(letezike is null)
            {
                _context.Felhasznalos.Add(f);
                if (_context.SaveChanges() > 0)
                {
                    return StatusCode(201);
                }
            }
            else
            {
                return StatusCode(409, "A felhasználó már létezik!");
            }

            return StatusCode(500);
        }
    }
}
