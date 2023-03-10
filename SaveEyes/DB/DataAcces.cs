using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEyes.DB
{
    public class DataAccess
    {
        public delegate void AddNewItem();
        public static event AddNewItem AddNewItemEvent;

        private static DbSet<Agent> _agents => SaveEyesNewEntities.GetContext().Agents;
        private static DbSet<ProductSale> _productSales => SaveEyesNewEntities.GetContext().ProductSales;

        public static List<Agent> GetAgents() => _agents.ToList();
        public static List<AgentType> GetAgentTypes() => SaveEyesNewEntities.GetContext().AgentTypes.ToList();
        public static List<Product> GetProducts() => SaveEyesNewEntities.GetContext().Products.ToList();


        public static void SaveAgent(Agent agent)
        {
            if (agent.ID == 0)
                _agents.Add(agent);

            SaveEyesNewEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }

        public static void DeleteAgent(Agent agent)
        {
            _agents.Remove(agent);
            SaveEyesNewEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }

        public static bool IsINNnKPPExist(Agent agent) => _agents.Any(x => x.ID != agent.ID && (x.INN == agent.INN || x.KPP == agent.KPP));


        public static void DeleteProductSale(ProductSale productSale)
        {
            _productSales.Remove(productSale);
            SaveEyesNewEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }
    }
}
