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

        public static List<Agent> GetAgents() => _agents.ToList();
        public static List<AgentType> GetAgentTypes() => SaveEyesNewEntities.GetContext().AgentTypes.ToList();


        public static void SaveAgent(Agent agent)
        {
            if (agent.ID == 0)
                _agents.Add(agent);

            SaveEyesNewEntities.GetContext().SaveChanges();
            AddNewItemEvent?.Invoke();
        }

    }
}
