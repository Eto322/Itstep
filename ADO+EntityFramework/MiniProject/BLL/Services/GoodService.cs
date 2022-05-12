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
    public class GoodService
    {
        private GoodRepository _goodRepository;
        private IMapper map;
        public GoodService(GoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Good, GoodDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(good => good.GoodId))
                .ForMember(x => x.Name, x => x.MapFrom(good => good.GoodName))
                .ForMember(x => x.Price, x => x.MapFrom(good => good.Price))
                .ForMember(x => x.Count, x => x.MapFrom(good => good.GoodCount))
            );
            map = config.CreateMapper();


        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return map.Map<IEnumerable<GoodDTO>>(_goodRepository.GetAll());
        }

        public bool CheckCategory(int categoryId)
        {
            return _goodRepository.GetAll().Any(x=> x.CategoryId == categoryId);
        }

        public bool CheckManufacturer(int manufacturerId)
        {
            return _goodRepository.GetAll().Any(x => x.ManufacturerId == manufacturerId);
        }
        public GoodDTO GetById(int id)
        {
            var good = _goodRepository.GetById(id);

            return map.Map<GoodDTO>(good);

        }

        public void Update(GoodDTO good)
        {
            var Edit = _goodRepository.GetById(good.Id);
            Edit.GoodName = good.Name;
            Edit.Price = good.Price;
            Edit.GoodCount = good.Count;
            _goodRepository.CreateOrUpdate(Edit);
            _goodRepository.Save();
        }
        public GoodDTO Create(GoodDTO good)
        {
            var newGood = new Good { GoodName = good.Name, Price = good.Price, GoodCount = good.Count };
            _goodRepository.CreateOrUpdate(newGood);
            _goodRepository.Save();
            good.Id = newGood.GoodId;
            return good;

        }

        public void DeleteById(int Id)
        {
            _goodRepository.Delete(_goodRepository.GetById(Id));
        }
        public void Delete(GoodDTO good)
        {

            _goodRepository.Delete(_goodRepository.GetById(good.Id));
        }

        public void Save()
        {
            _goodRepository.Save();
        }
    }
}
