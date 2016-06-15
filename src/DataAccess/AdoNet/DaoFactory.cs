using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.AdoNet
{
    // Data access object factory
    // ** Factory Pattern

    public class DaoFactory : IDaoFactory
    {
        public string ConnectionString
        {
            get; set;
        }

        public IMemberDao MemberDao { get { return new MemberDao(); } }
        public IOrderDao OrderDao { get { return new OrderDao(); } }
        public IOrderDetailDao OrderDetailDao { get { return new OrderDetailDao(); } }
        public IProductDao ProductDao {
            get {
                ProductDao productDao = new ProductDao();
                productDao.db = new Db(this.ConnectionString);
                return productDao;
            }
        }
        public ICategoryDao CategoryDao {
            get {
                CategoryDao categoryDao = new CategoryDao();
                categoryDao.db = new Db(this.ConnectionString);
                return categoryDao;
            }
        }
    }
}
