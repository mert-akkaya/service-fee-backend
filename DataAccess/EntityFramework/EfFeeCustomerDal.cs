using Core.DataAccess.EntityFramework;
using DbOperation;
using service_fee_backend;

namespace DataAccess.EntityFramework
{
    public class EfFeeCustomerDal :EfEntityRepositoryBase<FeeCustomer,ServiceFeeDbContext> ,IFeeCustomerDal
    {
      
    }
}