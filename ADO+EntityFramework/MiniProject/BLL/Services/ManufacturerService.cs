using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Context;
using DAL.Repository;

namespace BLL.Services
{
    public class ManufacturerService
    {
        private ManufacturerRepository _manufacturerRepository;
        private IMapper map;
        public ManufacturerService(ManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Manufacturer, ManufacturerDTO>()
                    .ForMember(x => x.Id, x => x.MapFrom(y => y.ManufacturerId))
                    .ForMember(x => x.Name, x => x.MapFrom(y => y.ManufacturerName)));
            map = new Mapper(config);
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return map.Map<IEnumerable<ManufacturerDTO>>(_manufacturerRepository.GetAll());
        }

        public ManufacturerDTO GetById(int id)
        {
            var Manufacturer = _manufacturerRepository.GetById(id);

            return map.Map<ManufacturerDTO>(Manufacturer);

        }

        public void Update(ManufacturerDTO manufacturerDTO)
        {
            var Edit = _manufacturerRepository.GetById(manufacturerDTO.Id);
            Edit.ManufacturerName = manufacturerDTO.Name;
            _manufacturerRepository.CreateOrUpdate(Edit);
            _manufacturerRepository.Save();
        }

        public ManufacturerDTO Create(ManufacturerDTO manufacturer)
        {
            var newManufacturer = new Manufacturer { ManufacturerName = manufacturer.Name };
            _manufacturerRepository.CreateOrUpdate(newManufacturer);
            _manufacturerRepository.Save();
            manufacturer.Id = newManufacturer.ManufacturerId;
            return manufacturer;

        }

        public void DeleteById(int Id)
        {
            _manufacturerRepository.Delete(_manufacturerRepository.GetById(Id));
        }
       

        public void Save()
        {
            _manufacturerRepository.Save();
        }
    }
}
