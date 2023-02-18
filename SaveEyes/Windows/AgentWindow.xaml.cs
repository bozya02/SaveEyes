using SaveEyes.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaveEyes.Windows
{
    /// <summary>
    /// Interaction logic for AgentWindow.xaml
    /// </summary>
    public partial class AgentWindow : Window
    {
        public Agent Agent { get; set; }
        public List<AgentType> AgentTypes { get; set; }

        public AgentWindow(Agent agent)
        {
            InitializeComponent();

            Agent = agent;
            AgentTypes = DataAccess.GetAgentTypes();

            this.DataContext = this;
        }
    }
}
