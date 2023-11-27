

using AutoMapper;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Role;
using Ecommerce.BusinessLogic.ViewModels;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IRoleService {
        public RoleViewModel CreateRole(CreateRoleRequestModel roleCreate);
        public RoleViewModel UpdateRole(UpdateRoleRequestModel roleUpdate);
        public bool DeleteRole(int idTmp);
        public List<RoleViewModel> GetAll();
        public RoleViewModel GetById(int idTmp);
    }

    public class RoleService : IRoleService {

        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository , IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public RoleViewModel CreateRole(CreateRoleRequestModel roleCreate)
        {
            var role = _mapper.Map<Role>(roleCreate);
            role.Name = roleCreate.Name;

            _roleRepository.Create(role);
            _roleRepository.Save();

            return _mapper.Map<RoleViewModel>(role);
                            
        }

        public RoleViewModel UpdateRole(UpdateRoleRequestModel roleUpdate) 
        {
            var role = _roleRepository.Get().SingleOrDefault(x => x.RoleId.Equals(roleUpdate.RoleId));
            if (role == null) return null;
            role.Name = roleUpdate.Name;
            _roleRepository.Update(role);
            _roleRepository.Save();

            return _mapper.Map<RoleViewModel>(role);
        }

        public bool DeleteRole(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<RoleViewModel> GetAll() 
        {
            var roles = _roleRepository.Get().ToList();
            return _mapper.Map<List<RoleViewModel>>(roles);
        }

        public RoleViewModel GetById(int idTmp) 
        {
            var role = _roleRepository.Get().SingleOrDefault(x => x.RoleId.Equals(idTmp));
            return _mapper.Map<RoleViewModel>(role);
        }

    }

}
