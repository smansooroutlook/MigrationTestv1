using BusinessObjects;
using DataObjects;
using Microsoft.Framework.ConfigurationModel;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace ActionService
{
    // implementation of IService interface. It can handle different data providers.

    // ** Facade pattern.
    // ** Repository pattern (Service could be split up in individual Repositories: Product, Category, etc).

    public class Service : IService
    {

        static ProviderContext providerContext ;
        static IDaoFactory factory;
        static ICategoryDao categoryDao;
        static IProductDao productDao;
        static IMemberDao memberDao;
        static IOrderDao orderDao;
        static IOrderDetailDao orderDetailDao;

        public Service() { }
        public Service(IOptions<ConfigCS> config)
        {
            if (factory == null)
            {
                providerContext = new ProviderContext();
                providerContext.ProviderName = config.Value.Provider.ToString();
                providerContext.ProviderConnectionString = config.Value.DBServer;
                factory = DaoFactories.GetFactory(providerContext);
                BuildDAOFactory();
            }
        }

        private static void BuildDAOFactory()
        {
            categoryDao = factory.CategoryDao;
            productDao = factory.ProductDao;
            memberDao = factory.MemberDao;
            orderDao = factory.OrderDao;
            orderDetailDao = factory.OrderDetailDao;
        }

        // Category Services

        public List<Category> GetCategories() 
        {
            return categoryDao.GetCategories(); 
        }

        public Category GetCategoryByProduct(int productId)
        {
            return categoryDao.GetCategoryByProduct(productId);
        }

        // Product Services

        public Product GetProduct(int productId)
        {
            var product =  productDao.GetProduct(productId);
            if (product.Category == null) 
                product.Category = categoryDao.GetCategoryByProduct(productId);

            return product;
        }

        public List<Product> GetProductsByCategory(int categoryId, string sortExpression) 
        {
            return productDao.GetProductsByCategory(categoryId, sortExpression);
        }

        public List<Product> SearchProducts(string productName, double priceFrom, double priceThru, string sortExpression)
        {
            return productDao.SearchProducts(productName, priceFrom, priceThru, sortExpression);
        }

        // Member Services

        public Member GetMember(int memberId)
        {
            return memberDao.GetMember(memberId);
        }

        public Member GetMemberByEmail(string email)
        {
            return memberDao.GetMemberByEmail(email);
        }

        public List<Member> GetMembers(string sortExpression)
        {
            var members = memberDao.GetMembers(sortExpression);
            members.RemoveAll(m => m.MemberId == 1);  // exclude admin (for demo purposes)
            return members;
        }

        public Member GetMemberByOrder(int orderId)
        {
            return memberDao.GetMemberByOrder(orderId);
        }

        public List<Member> GetMembersWithOrderStatistics(string sortExpression)
        {
            return memberDao.GetMembersWithOrderStatistics(sortExpression);
        }

        public void InsertMember(Member member)
        {
            memberDao.InsertMember(member);
        }

        public void UpdateMember(Member member)
        {
            memberDao.UpdateMember(member);
        }

        public void DeleteMember(Member member)
        {
            memberDao.DeleteMember(member);
        }

        // Order Services

        public Order GetOrder(int orderId)
        {
            return orderDao.GetOrder(orderId);
        }

        public List<Order> GetOrdersByMember(int memberId)
        {
            return orderDao.GetOrdersByMember(memberId);
        }

        public List<Order> GetOrdersByDate(DateTime dateFrom, DateTime dateThru)
        {
            return orderDao.GetOrdersByDate(dateFrom, dateThru);
        }

        // OrderDetail Services

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return orderDetailDao.GetOrderDetails(orderId);
        }

        // Authentication and Authorization Services

        public bool Login(string email, string password)
        {
            // websecurity does not accept null or empty

            if (string.IsNullOrEmpty(email)) return false;
            if (string.IsNullOrEmpty(password)) return false;

            return false;
            // return WebSecurity.Login(email, password);
        }

        public void Logout()
        {
            // WebSecurity.Logout();
        }
    }
}
