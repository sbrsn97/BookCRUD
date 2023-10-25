using KitapMVCInveonOrnek.Models;
using KitapMVCInveonOrnek.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;

namespace KitapMVCInveonOrnek.Controllers
{
    public class KitapController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Kitap> kitapListesi = new List<Kitap>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7156/api/Kitap"))
                {
                    string gelenStringData = await response.Content.ReadAsStringAsync();
                    kitapListesi = JsonConvert.DeserializeObject<List<Kitap>>(gelenStringData);
                }
            }
                return View(kitapListesi);
        }
        public async Task<IActionResult> KitapDetay(int id)
        {
            Kitap kitapDetay;
            using (var httpClient = new HttpClient())
            {
                using (var yanit = await httpClient.GetAsync("https://localhost:7156/api/Kitap/"+id))
                {
                    string gelenString = await yanit.Content.ReadAsStringAsync();
                    kitapDetay = JsonConvert.DeserializeObject<Kitap>(gelenString);
                }
            }
            return View(kitapDetay);
        }
        public async Task<IActionResult> KitapEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KitapEkle(KitapVM  model)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7156/api/Kitap/");
                var post = httpClient.PostAsJsonAsync<KitapVM>("", model);
                post.Wait();

                var postResult = post.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty,"Sunucu bağlantısı sırasında bir hata oluştu.");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> KitapDuzenle(int id)
        {
            Kitap kitapDetay;
            using (var httpClient = new HttpClient())
            {
                using (var yanit = await httpClient.GetAsync("https://localhost:7156/api/Kitap/" + id))
                {
                    string gelenString = await yanit.Content.ReadAsStringAsync();
                    kitapDetay = JsonConvert.DeserializeObject<Kitap>(gelenString);
                }
            }
            return View(kitapDetay);
        }
        [HttpPut]
        public async Task<IActionResult> KitapDuzenle(Kitap model)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7156/api/Kitap/");
                var post = httpClient.PutAsJsonAsync<Kitap>("", model);
                post.Wait();

                var postResult = post.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Sunucu bağlantısı sırasında bir hata oluştu.");
            return View(model);
        }
        public IActionResult KitapSil(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync($"https://localhost:7156/api/Kitap/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Sunucu bağlantısı sırasında bir hata oluştu.");
            return View();
        }
    }
}
