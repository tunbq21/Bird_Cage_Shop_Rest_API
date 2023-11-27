

using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Voucher;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IVoucherService {
        public VoucherViewModel CreateVoucher(CreateVoucherRequestModel voucherCreate);
        public VoucherViewModel UpdateVoucher(UpdateVoucherRequestModel voucherUpdate);
        public bool DeleteVoucher(string idTmp);
        public List<VoucherViewModel> GetAll();
        public VoucherViewModel GetById(string idTmp);
        public List<VoucherViewModel> GetByUserId(string userId);
        public List<VoucherViewModel> GetByProductId(string productId);
    }

    public class VoucherService : IVoucherService {

        private readonly IVoucherRepository _voucherRepository;
       
        private readonly IMapper _mapper;
        public VoucherService(IVoucherRepository voucherRepository, IMapper mapper)
        {
            _voucherRepository = voucherRepository;
            _mapper = mapper;   
        }

        public VoucherViewModel CreateVoucher(CreateVoucherRequestModel voucherCreate)
        {
            var existingCoupon = _voucherRepository.Get().SingleOrDefault(x => x.CouponCode.Equals(voucherCreate.CouponCode));
            if (existingCoupon != null) return null;

            var voucher = _mapper.Map<Voucher>(voucherCreate);
            voucher.VoucherId = Guid.NewGuid().ToString();
            voucher.Status = (int?)VoucherStatusEnum.Active;

            _voucherRepository.Create(voucher);
            _voucherRepository.Save();

            return _mapper.Map<VoucherViewModel>(voucher);
        }

        public VoucherViewModel UpdateVoucher(UpdateVoucherRequestModel voucherUpdate) 
        {
            var voucher = _voucherRepository.Get().SingleOrDefault(x => x.VoucherId.Equals(voucherUpdate.VoucherId));
            if (voucher == null) return null;

            voucher.Point = voucherUpdate.Point;
            voucher.Discount = voucherUpdate.Discount;
            voucher.CouponCode = voucherUpdate.CouponCode;
            voucher.ExpirationDate = voucherUpdate.ExpirationDate;
            voucher.Status = voucherUpdate.Status;

            _voucherRepository.Update(voucher);
            _voucherRepository.Save();

            return _mapper.Map<VoucherViewModel>(voucher);
        }

        public bool DeleteVoucher(string idTmp)
        {
            var voucher = _voucherRepository.Get().SingleOrDefault(x => x.VoucherId.Equals(idTmp));
            if (voucher == null) return false;

            voucher.Status = (int?)VoucherStatusEnum.Expried;

            return true;
        }

        public List<VoucherViewModel> GetAll() 
        {
            var voucher = _voucherRepository.Get().ToList();
            if (voucher == null) return null;

            return _mapper.Map<List<VoucherViewModel>>(voucher);
        }

        public VoucherViewModel GetById(string idTmp) 
        {
            var voucher = _voucherRepository.Get().SingleOrDefault(x => x.VoucherId.Equals(idTmp));

            return _mapper.Map<VoucherViewModel>(voucher);
        }

        public List<VoucherViewModel> GetByUserId(string userId)
        {
            var voucher = _voucherRepository.Get().Where(voucher => voucher.Users.Any(user => user.UserId.Equals(userId))).ToList();
            if (voucher == null) return null;

            return _mapper.Map<List<VoucherViewModel>>(voucher);
        }

        public List<VoucherViewModel> GetByProductId(string productId)
        {
            var voucher = _voucherRepository.Get().Where(voucher => voucher.Products.Any(product => product.ProductId.Equals(productId))).ToList();
            if (voucher == null) return null;

            return _mapper.Map<List<VoucherViewModel>>(voucher);
        }
    }

}
