using Library_Registiration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library_Registiration.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Login(Admin p)
        {
            /*Models klasörümüzde bulunan veritabanı tablolarımızı tutan context sınıfından c adında bir nesne olusturuyoruz.çünkü
             giriş bilgilerimizi tutan kısım burası ve girilen bilgiler ile veritabanında bulunan bilgileri kıyaslayabilmemiz yani
            giriş yapabilmemiz için tabloya erişememizi sağlar.
            login adında bir değişken olusturuyoruz ve olusturdugumuz c nesnesi ile admin tablosuna erişiyoruz girilen bilgiler
            ile tabloda bulunan degerleri kıyaslayıp dogru olan ilk sütunu çekiyoruz.
            if koşulu ile deger dogru ise redirectoaction ile ındex sayfamıza yönlendiriyoruz.*/

            Context c = new Context();
            var login = c.admins.FirstOrDefault(x => x.Admin_username == p.Admin_username && x.Admin_password == p.Admin_password);

            if (login != null)
            {
               return RedirectToAction("Index", "Library");
;           }
            else
            {
                return View();
            }

            
            
             
            
         
           
        }
    }
}
