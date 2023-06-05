using System.Collections;
using System.Collections.Generic;
using System;
using dm_graph.nodes;

namespace dm_graph.graphs
{
    public abstract class BaseGraph
    {
        private string m_Name;
        protected List<BaseNode> m_Nodes = new List<BaseNode>();

        public BaseGraph(string name)
        {
            m_Name = name;
        }

        public void SetName(string name)
        {
            m_Name = name;
        }

        public string GetName()
        {
            return m_Name;
        }

        public abstract bool AddNode(BaseNode node);
        public abstract bool RemoveNode(BaseNode node);
    }

} // namespace dm_graph.graphs
