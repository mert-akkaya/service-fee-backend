using service_fee_backend;
using System.Collections.Generic;
using System.Linq;

namespace Business{

    public interface IFeeCustomerService {

        List<FeeCustomer> GetAll();
        void Add(FeeCustomer customer);
        void Delete(FeeCustomer customer);
        
    }
}