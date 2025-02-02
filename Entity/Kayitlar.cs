using System;

namespace FiyatBilgiApi.Entity
{
    public class Kayitlar
    {
        public int randevu_id { get; set; }
        public string musteri_adi { get; set; } = string.Empty;
        public string hizmet_turu { get; set; } = string.Empty;
        public decimal ucret { get; set; }
        public DateTime tarih { get; set; }

    }
}