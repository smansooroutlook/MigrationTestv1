using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    
    // Factory of factories. This class is a factory class that creates
    // data-base specific factories which in turn create data acces objects.
    // ** GoF Design Patterns: Factory.

    public class DaoFactories
    {
        // gets a provider specific (i.e. database specific) factory 
        
        // ** GoF Design Pattern: Factory

        public static IDaoFactory GetFactory(ProviderContext dataProvider)
        {
            // return the requested DaoFactory

            if (dataProvider.ProviderName == null)
                dataProvider.ProviderName = string.Empty;

            switch (dataProvider.ProviderName.ToLower())
            {
                case "ado.net":
                    {
                        AdoNet.DaoFactory daoFactory = new AdoNet.DaoFactory();
                        daoFactory.ConnectionString = dataProvider.ProviderConnectionString;
                        return daoFactory;
                    }
                //case "linq2sql": return new Linq2Sql.DaoFactory();
                //case "entityframework": return new EntityFramework.DaoFactory();

                default: return new AdoNet.DaoFactory();
            }
        }
    }
}
