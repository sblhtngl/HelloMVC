using Microsoft.EntityFrameworkCore;

namespace Bilisim.EfApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var ctx = new OkulDbContext();
            try
            {
                var ogr = new Ogrenci { Ad = "Ali", Soyad = "Veli" };
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu!");
            }
            finally
            {
                ctx.Dispose();
            }
            */

            //*****Insert örneği
            /*
            using (var ctx = new OkulDbContext())
            {
                var ogr = new Ogrenci { Ad = "Ali", Soyad = "Veli" };
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();
            }
            */


            //*****Update örneği
            /*
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(3);
                if (ogr != null)
                {
                    ogr.Soyad = "Demirci";
                    ctx.Entry(ogr).State = EntityState.Modified;
                    int sonuc = ctx.SaveChanges();
                    Console.WriteLine(sonuc > 0 ? "Başarılı" : "Başarısız!");
                }
            }
            */

            //******Select Örneği
            /*
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine($"Ad:{item.Ad} Soyad:{item.Soyad}");
                }
            }
            */


            //****Ad bilgisine göre select
            /*
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Ogrenciler.Where(o => o.Soyad == "Demirci").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine($"Ad:{item.Ad} Soyad:{item.Soyad}");
                }
            }
            */


            
            //*****Delete örneği********
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(2);
                if (ogr != null)
                {
                    ctx.Ogrenciler.Remove(ogr);
                    int sonuc = ctx.SaveChanges();
                    Console.WriteLine(sonuc > 0 ? "Silme işlemi başarılı" : "İşlem Başarısız!");
                }
                else
                {
                    Console.WriteLine("Öğrenci bulunamadı!");
                }
            }
            
        }
    }
}

//Garbage Collector
//using blokları içerisinde üretilen yönetilemeyen kaynaklar, using bloğu dışına çıkıldığı anda Dispose edilir.