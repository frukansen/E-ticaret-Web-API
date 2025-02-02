using FiyatBilgiApi.Entity;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using FiyatBilgiApi.DbConnection;

namespace FiyatBilgiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _configuration;

        public ValuesController(IDbConnection dbConnection, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _configuration = configuration;
        }

        // 1- Tüm kayıtları getiren mevcut endpoint
        [HttpPost("GetKayitlar")]
        public IActionResult GetCustomers()
        {
            var kayitlar = new List<Kayitlar>();
            using (IDbConnection db = new SqlConnection(new GetConnectionString().GetConnection))
            {
                kayitlar = db.Query<Kayitlar>("SELECT * FROM Randevular").ToList();
            }
            return Ok(kayitlar);
        }

        // 2- Müşteri adına göre arama yapan endpoint
        [HttpGet("SearchByMusteriAdi")]
        public IActionResult SearchByMusteriAdi(string musteriAdi)
        {
            var kayitlar = new List<Kayitlar>();
            using (IDbConnection db = new SqlConnection(new GetConnectionString().GetConnection))
            {
                kayitlar = db.Query<Kayitlar>(
                    "SELECT * FROM Randevular WHERE musteri_adi LIKE @MusteriAdi",
                    new { MusteriAdi = $"%{musteriAdi}%" }
                ).ToList();
            }

            if (!kayitlar.Any())
                return NotFound("Bu isimle eşleşen bir müşteri bulunamadı.");

            return Ok(kayitlar);
        }

        // 3- Tarihe göre arama yapan endpoint
        [HttpGet("SearchByDateRange")]
        public IActionResult SearchByDateRange(DateTime startDate, DateTime endDate)
        {
            var kayitlar = new List<Kayitlar>();
            using (IDbConnection db = new SqlConnection(new GetConnectionString().GetConnection))
            {
                kayitlar = db.Query<Kayitlar>(
                    "SELECT * FROM Randevular WHERE tarih BETWEEN @StartDate AND @EndDate",
                    new { StartDate = startDate, EndDate = endDate }
                ).ToList();
            }

            if (!kayitlar.Any())
                return NotFound("Belirtilen tarih aralığında kayıt bulunamadı.");

            return Ok(kayitlar);
        }
    }
}
