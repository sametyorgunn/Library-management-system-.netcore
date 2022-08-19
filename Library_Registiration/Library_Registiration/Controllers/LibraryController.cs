using Library_Registiration.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Registiration.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IWebHostEnvironment _webHost;

        public LibraryController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List_Book()
        {
           /*
            * model klasörğndeki veritabanında bulunan bilgileri dataları tutan context snıfımızdan c nesnesi olusturuyoruz.
            * books adında bir degisken olusturup c nesnesi ile books yanş kitaplar tablosuna erişip bulunan tüm kitapları 
            * bu değişkene atıyoruz ve return view içi books değişkenini atıp sayfada bu kitaplarınn görünmesini yani listelenmesini
            * sağlıyoruz.
            */
            Context c = new Context(); 
            var books = c.books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add_Book()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Book(Book p)
        {
            /*
             * model klasörğndeki veritabanında bulunan bilgileri dataları tutan context snıfımızdan c nesnesi olusturuyoruz.
             *kitap bilgilerimi tutan kısım book clasıı olduğu için bu class tan bir p adında nesne olusturuypruz.
             *c nesnesi ile kitaplar tablosuna erişip add komutu ile p nesnesini yani girilen degerleri tablomuza ekliyoruz 
             *bu bilgiler kitp hakkındaki bilgiler adı - yazar adı gibi.
             *savechanges ilede bu girilen bilgilerin veritabanına kayıt olmasını saglıyoruz.
             *resim eklenebilmesi içinde resmin hem yolunu yani path ini hemde kendinisi tutmamız gerekiyor.
             *resmim kendisini resimler klasöründe,yolunu ise veritabanında tutuyoruz.
             */

            string wwwRootPath = _webHost.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(p.Book_resim.FileName);
            string extension = Path.GetExtension(p.Book_resim.FileName);
            p.Book_resim_yol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Resimler/", filename);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await p.Book_resim.CopyToAsync(filestream);
            }

            Context c = new Context();
            c.books.Add(p);
            if (ModelState.IsValid)
            {
                var result = c.SaveChanges();
                return RedirectToAction("List_Book", "Library");

            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Edit_Book(int id)
        {
            /*
             * res adında bir degişken olusturup parametre olarak gönderdiğimiz id degerini yani düzenleye tıklanınca 
             * id sini gönderdiğimiz kitabı find metodu ile buluyoruz yani o id ye sahip kitabı bulmamızı sağlıyor.
             * bu kitap hakkındaki bilgileri res degiskeninde saklıyoruz.
             * ve return view ile bu kitabı sayfada görüntülüyoruz.
            */
            Context c = new Context();
            var res = c.books.Find(id);
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit_Book(Book p)
        {
            /**/

            Context c = new Context();
            c.books.Update(p);
            if(ModelState.IsValid)
            {
                c.SaveChanges();
                return RedirectToAction("List_Book", "Library");
                
            }
            else
            {
                return View();
            }
           
        }
        public IActionResult Delete_Book(int id)
        {
            /*sil değişkeni olusturup güncellede yaptıgımız gibi silinecek id ye ait kitabu bulup degiskene atıyoruz.
             buldugumuz kitabı remove metodu ile siliyoruz.
            ardından savechanges ile kayıt edip
            yönlendirmemizi yapıyorız.*/

            Context c = new Context();
            var sil = c.books.Find(id);
            c.books.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("List_Book", "Library");
        }

        [HttpGet]
        public IActionResult Author_add()
        {
         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Author_add(Author p)
        {
            string wwwRootPath = _webHost.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(p.Author_resim.FileName);
            string extension = Path.GetExtension(p.Author_resim.FileName);
            p.Author_resim_yol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Resimler/", filename);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await p.Author_resim.CopyToAsync(filestream);
            }

            Context c = new Context();
            c.authors.Add(p);
            if (ModelState.IsValid)
            {
               
                var result = c.SaveChanges();
                return RedirectToAction("List_author", "Library");
            }
            else
            {
                return View();
            }
           
           
        }


        public IActionResult List_author()
        {
            Context c = new Context();
            var author =  c.authors.ToList();
            return View(author);
        }

        public IActionResult Delete_Author(int id)
        {
            Context c = new Context();
            var sl = c.authors.Find(id);
            c.authors.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("List_author", "Library");
        }

        public IActionResult Edit_Author(int id)
        {
            Context c = new Context();
            var bl = c.authors.Find(id);
            return View(bl);
        }

        [HttpPost]
        public IActionResult Edit_Author(Author p)
        {
            Context c = new Context();
            c.authors.Update(p);
            if(ModelState.IsValid)
            {
                var result = c.SaveChanges();
                return RedirectToAction("List_author", "Library");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult Add_Publisher()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Publisher(Publisher p)
        {
            string wwwRootPath = _webHost.WebRootPath;
            string filename = Path.GetFileNameWithoutExtension(p.publisher_Resim.FileName);
            string extension = Path.GetExtension(p.publisher_Resim.FileName);
            p.Publisher_resim_yol = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Resimler/", filename);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await p.publisher_Resim.CopyToAsync(filestream);
            }
            Context c = new Context();
            c.publishers.Add(p);
            if (ModelState.IsValid)
            {

                var result = c.SaveChanges();
                return RedirectToAction("List_publisher", "Library");
            }
            else
            {
                return View();
            }


        }


        public IActionResult List_publisher()
        {
            Context c = new Context();
            var publisher = c.publishers.ToList();
            return View(publisher);
        }

        public IActionResult Delete_Publisher(int id)
        {
            Context c = new Context();
            var sl = c.publishers.Find(id);
            c.publishers.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("List_publisher", "Library");
        }

        public IActionResult Edit_Publisher(int id)
        {
            Context c = new Context();
            var bl = c.publishers.Find(id);
            return View(bl);
        }

        [HttpPost]
        public IActionResult Edit_Publisher(Publisher p)
        {
            Context c = new Context();
            c.publishers.Update(p);
            if (ModelState.IsValid)
            {
                var result = c.SaveChanges();
                return RedirectToAction("List_publisher", "Library");
            }
            else
            {
                return View();
            }
        }

        /*detay sayfalarımızı olusturduk ve listeleme yaptıgımız sayyada kitabın yazarın yada yayın evinin detaylarını görmek için 
         tıkladıgımızda açılan sayfada bilgileri detaylıca görülmesini sağladım bunun için parametre olarak verilen id yi find metodu
        ile buşup ekranda görüntülmesini sağladım */
        public IActionResult YayineviDetay(int id)  
        {
            Context c = new Context();
            var detay = c.publishers.Find(id);
            return View(detay);
        }

        public IActionResult KitapDetay(int id)
        {
            Context c = new Context();
            var detay = c.books.Find(id);
            return View(detay);
        }
        public IActionResult YazarDetay(int id)
        {
            Context c = new Context();
            var detay = c.authors.Find(id);
            return View(detay);
        }


    }
}
