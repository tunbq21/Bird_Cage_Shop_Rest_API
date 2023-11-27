
using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Payment;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IPaymentService {
        public PaymentViewModel CreatePayment(CreatePaymentRequestModel paymentCreate);
        public PaymentViewModel UpdatePayment(UpdatePaymentRequestModel paymentUpdate);
        public bool DeletePayment(string idTmp);
        public List<PaymentViewModel> GetAll();
        public PaymentViewModel GetById(string idTmp);
    }

    public class PaymentService : IPaymentService {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public PaymentViewModel CreatePayment(CreatePaymentRequestModel paymentCreate)
        {
            var payment = _mapper.Map<Payment>(paymentCreate);
            payment.PaymentId = Guid.NewGuid().ToString();
            payment.PaymentMethod = paymentCreate.PaymentMethod;
            payment.CardNumber = paymentCreate.CardNumber;  
            payment.Cvv = paymentCreate.Cvv;
            payment.ExpirationDate = paymentCreate.ExpirationDate;

            _paymentRepository.Create(payment);
            _paymentRepository.Save();

            return _mapper.Map<PaymentViewModel>(payment);  
            
        }

        public PaymentViewModel UpdatePayment(UpdatePaymentRequestModel paymentUpdate) 
        {
            var payment = _paymentRepository.Get().SingleOrDefault(x => x.PaymentId.Equals(paymentUpdate.PaymentId));
            if (payment == null) return null;
            payment.PaymentMethod = paymentUpdate.PaymentMethod;
            payment.CardNumber = paymentUpdate.CardNumber;
            payment.ExpirationDate = paymentUpdate.ExpirationDate;
            payment.Cvv = paymentUpdate.Cvv;

            _paymentRepository.Update(payment);
            _paymentRepository.Save();

            return _mapper.Map<PaymentViewModel>(payment);
        }

        public bool DeletePayment(string idTmp)
        {
            var payment = _paymentRepository.Get().SingleOrDefault(x => x.PaymentId.Equals(idTmp));
            if (payment == null) return false;
            _paymentRepository.Delete(payment);
            _paymentRepository.Save();
            return true;
        }

        public List<PaymentViewModel> GetAll() 
        {
            var payments = _paymentRepository.Get().ToList();
            if (payments == null) return null;
            return _mapper.Map<List<PaymentViewModel>>(payments);
        }

        public PaymentViewModel GetById(string idTmp) 
        {
            var payment = _paymentRepository.Get().SingleOrDefault(x => x.PaymentId.Equals(idTmp));
            if (payment == null) return null;
            return _mapper.Map<PaymentViewModel>(payment);
        }

    }

}
