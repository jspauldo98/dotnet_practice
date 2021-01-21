using System.Collections.Generic;
using System.Threading.Tasks;

namespace payment_register2.Models
{
    public interface IPaymentDetailRepo
    {
        Task<IEnumerable<PaymentDetail>> GetAllPaymentDetails();
        Task<PaymentDetail> GetPaymentDetail(int id);
        Task<bool> UpdatePaymentDetail(int id, PaymentDetail paymentDetail);
        Task<bool> InsertPaymentDetail(PaymentDetail paymentDetail);
        Task<bool> DeletePaymentDetail(int id);
        bool PaymentDetailExists(int id);
    }
}