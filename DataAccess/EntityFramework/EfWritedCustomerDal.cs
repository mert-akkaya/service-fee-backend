using Core.DataAccess.EntityFramework;
using DbOperation;
using service_fee_backend;

namespace DataAccess.EntityFramework
{
    public class EfWritedCustomerDal :EfEntityRepositoryBase<WritedCustomer,ServiceFeeDbContext> ,IWritedCustomerDal
    {
      
    }
}