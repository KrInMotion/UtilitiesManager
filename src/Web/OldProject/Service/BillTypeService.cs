using Data.Infrastructure;
using Data.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBillTypeService
    {
        IEnumerable<BillType> GetBillTypes();
        IEnumerable<BillType> GetBillTypesByName(string billTypeName);
        BillType GetBillType(int id);
        void CreateBillType(BillType entity);
        void DeleteBillType(BillType entity);
        void SaveBillType();
    }

    public class BillTypeService : IBillTypeService
    {
        private readonly IEntityBaseRepository<BillType> _billTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BillTypeService(IEntityBaseRepository<BillType> billTypeRepository, IUnitOfWork unitOfWork)
        {
            _billTypeRepository = billTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateBillType(BillType entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Bill type");
            _billTypeRepository.Add(entity);
        }

        public void DeleteBillType(BillType entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Bill type");
            _billTypeRepository.Delete(entity);
        }

        public BillType GetBillType(int id)
        {
            return _billTypeRepository.GetSingle(id);
        }

        public IEnumerable<BillType> GetBillTypes()
        {
            return _billTypeRepository.GetAll();
        }

        public IEnumerable<BillType> GetBillTypesByName(string billTypeName)
        {
            return _billTypeRepository.GetMany(x=>x.TypeName.ToUpper()==billTypeName.ToUpper());
        }

        public void SaveBillType()
        {
            _unitOfWork.Commit();
        }
    }
}
