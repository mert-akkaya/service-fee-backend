using System.Collections.Generic;
using service_fee_backend;

namespace Business{

    public interface IWritedCustomerService {

        List<WritedCustomer> GetAll();
        void Add(WritedCustomer customer);
        void Delete(WritedCustomer customer);
        
    }
}