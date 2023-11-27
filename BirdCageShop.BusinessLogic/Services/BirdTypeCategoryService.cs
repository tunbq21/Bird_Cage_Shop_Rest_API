
using AutoMapper;
using Ecommerce.BusinessLogic.ViewModels;
using BirdCageShop.DataAccess.Repositories;

namespace BirdCageShop.BusinessLogic.Services
{

    public interface IBirdTypeCategoryService
    {
     
        public List<BirdTypeCategoryViewModel> GetAll();
       
    }

    public class BirdTypeCategoryService : IBirdTypeCategoryService
    {

        private readonly IBirdTypeCategoryRepository _birdTypeCategoryRepository;
        private readonly IMapper _mapper;
        public BirdTypeCategoryService(IBirdTypeCategoryRepository birdTypeCategoryRepository, IMapper mapper)
        {
            _birdTypeCategoryRepository = birdTypeCategoryRepository;
            _mapper = mapper;

        }
     

        public List<BirdTypeCategoryViewModel> GetAll()
        {
            var birdType = _birdTypeCategoryRepository.Get().ToList();
            return _mapper.Map<List<BirdTypeCategoryViewModel>>(birdType);
        }

      
    }

}
