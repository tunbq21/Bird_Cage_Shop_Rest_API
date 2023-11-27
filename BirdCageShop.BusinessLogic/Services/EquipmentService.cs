
using AutoMapper;
using BirdCageShop.BusinessLogic.Enums;
using BirdCageShop.DataAccess.Models;
using BirdCageShop.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Equipment;
using Ecommerce.BusinessLogic.ViewModels;
using System;

namespace BirdCageShop.BusinessLogic.Services 
{

    public interface IEquipmentService {
        public EquipmentViewModel CreateEquipment(CreateEquipmentRequestModel equipmentCreate);
        public EquipmentViewModel UpdateEquipment(UpdateEquipmentRequestModel equipmentUpdate);
        public bool DeleteEquipment(string idTmp);
        public List<EquipmentViewModel> GetAll();
        public EquipmentViewModel GetById(string idTmp);
    }

    public class EquipmentService : IEquipmentService {

      private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public EquipmentViewModel CreateEquipment(CreateEquipmentRequestModel equipmentCreate)
        {
            var equipment = _mapper.Map<Equipment>(equipmentCreate);
            equipment.EquipmentId = Guid.NewGuid().ToString();

            _equipmentRepository.Create(equipment);
            _equipmentRepository.Save();

            return _mapper.Map<EquipmentViewModel>(equipment);
        }

        public EquipmentViewModel UpdateEquipment(UpdateEquipmentRequestModel equipmentUpdate) 
        {
            var equipment = _equipmentRepository.Get().FirstOrDefault(x => x.EquipmentId.Equals(equipmentUpdate.EquipmentId));
            if (equipment == null) return null;
            equipment.Name = equipmentUpdate.Name;
            equipment.Type = equipmentUpdate.Type;
            equipment.Image = equipmentUpdate.Image;
            equipment.Price = equipmentUpdate.Price;
            equipment.Charge = equipmentUpdate.Charge;

            _equipmentRepository.Update(equipment);
            _equipmentRepository.Save();

            return _mapper.Map<EquipmentViewModel>(equipment);
        }

        public bool DeleteEquipment(string idTmp)
        {
            var equipment = _equipmentRepository.Get().SingleOrDefault(x => x.EquipmentId.Equals(idTmp));
            if (equipment == null) return false;
            equipment.Status = (int?)EquipmentStatusEnum.unavailible;

            _equipmentRepository.Update(equipment);
            _equipmentRepository.Save();

            return true;
        }

        public List<EquipmentViewModel> GetAll() 
        {
            var equipments = _equipmentRepository.Get().ToList();
            return _mapper.Map<List<EquipmentViewModel>>(equipments);
        }

        public EquipmentViewModel GetById(string idTmp)
        {
            var equipment = _equipmentRepository.Get().FirstOrDefault(x => x.EquipmentId.Equals(idTmp));
            return _mapper.Map<EquipmentViewModel>(equipment);
        }

    }

}
