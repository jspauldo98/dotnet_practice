using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace payment_register2.Models
{
    public class PaymentDetailRepo : IPaymentDetailRepo
    {
        private readonly IConfiguration _config;
        public PaymentDetailRepo(IConfiguration config)
        {
            _config = config;
        }

        public MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("DevConnection"));
            }
        }
        public async Task<IEnumerable<PaymentDetail>> GetAllPaymentDetails()
        {
            using (MySqlConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM PaymentDetails";
                conn.Open();
                var result = await conn.QueryAsync<PaymentDetail>(sQuery);
                return result.ToList();
            }
        }

        public async Task<PaymentDetail> GetPaymentDetail(int PMId)
        {
            using (MySqlConnection conn = Connection)
            {
                string sQuery = "SELECT PMId, CardOwnerName, CardNumber, ExpirationDate, CVV FROM PaymentDetails WHERE PMId = @id";
                var @params = new {id = PMId };
                conn.Open();
                var result = await conn.QueryAsync<PaymentDetail>(sQuery, @params);
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> PostPaymentDetail(PaymentDetail paymentDetail)
        {   
            int result = -1;
            using (MySqlConnection conn = Connection)
            {                
                var sQuery = @"INSERT INTO PaymentDetails (CardOwnerName, CardNumber, ExpirationDate, CVV)";              
                conn.Open();
                result = await conn.ExecuteAsync(sQuery, paymentDetail);
            }
            return result > 0;
        }

        public async Task<bool> DeletePaymentDetail(int id)
        {
            int result = -1;
            using (MySqlConnection conn = Connection)
            {                
                var sQuery = @"DELETE FROM PaymentDetails WHERE PMId = @id)";     
                var @params = new { id = id };         
                conn.Open();
                result = await conn.ExecuteAsync(sQuery, @params);
            }
            return result > 0;
        }
    }
}