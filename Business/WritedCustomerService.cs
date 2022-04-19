using DataAccess;
using DbOperation;
using service_fee_backend;
using System.Collections.Generic;
using System.Linq;

namespace Business{

    public class WritedCustomerService:IWritedCustomerService {

        IWritedCustomerDal _writedCustomerDal;

        public WritedCustomerService(IWritedCustomerDal writedCustomerDal){
            _writedCustomerDal = writedCustomerDal;
        }

        public void Add(WritedCustomer customer)
        {
            _writedCustomerDal.Add(customer);
        }

        public void Delete(WritedCustomer customer)
        {
            _writedCustomerDal.Delete(customer);
        }

        public List<WritedCustomer> GetAll()
        {
           return _writedCustomerDal.GetAll();
        }
    }
}