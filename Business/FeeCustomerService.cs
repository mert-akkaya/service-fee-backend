using DataAccess;
using DbOperation;
using service_fee_backend;
using System.Collections.Generic;

namespace Business{

    public class FeeCustomerService:IFeeCustomerService {

        IFeeCustomerDal _feeCustomerDal;

        public FeeCustomerService(IFeeCustomerDal feeCustomerDal){
            _feeCustomerDal = feeCustomerDal;
        }

        public void Add(FeeCustomer customer)
        {
            _feeCustomerDal.Add(customer);
        }

        public  void Delete(FeeCustomer customer)
        {
            _feeCustomerDal.Delete(customer);
        }

        public List<FeeCustomer> GetAll()
        {
            return _feeCustomerDal.GetAll();
        }
    }
}