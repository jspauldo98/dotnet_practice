using System.Collections.Generic;
using System.Threading.Tasks;

namespace payment_register2.Models
{
    public interface IPaymentDetailRepo
    {
        Task<IEnumerable<PaymentDetail>> GetAllPaymentDetails();
        Task<PaymentDetail> GetPaymentDetail(int id);
        Task<bool> PostPaymentDetail(PaymentDetail paymentDetail);
        Task<bool> DeletePaymentDetail(int id);
    }
}