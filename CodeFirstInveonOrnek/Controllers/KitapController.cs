using CodeFirstInveonOrnek.Data;
using CodeFirstInveonOrnek.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CodeFirstInveonOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        ApplicationDbContext _context;

        public KitapController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kitap>>> KitaplariGetir()
        {
            //SQL Connection conn SqlCommand cmdText "Select * from Kitaplar"
            return await _context.Kitaplar.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Kitap>>> KitapEkle(Kitap kitap)
        {
            try
            {
                _context.Kitaplar.Add(kitap); //insert into kitaplar(Kitap adi) values (kitap.kitapadi)
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return Ok(kitap); //islemin basarili oldugunu dondurur
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Kitap>> KitapDetayGetir(int id)
        {
            //select * from Kitaplar where id=id
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(kitap);
            }
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<Kitap>>> KitapGuncelle(Kitap kitap)
        {
            _context.Entry(kitap).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kitap>> KitapSil(int id)
        {
            Kitap silinecekKitap = await _context.Kitaplar.FindAsync(id);
            _context.Kitaplar.Remove(silinecekKitap); //delete from kitaplar where id = id
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
