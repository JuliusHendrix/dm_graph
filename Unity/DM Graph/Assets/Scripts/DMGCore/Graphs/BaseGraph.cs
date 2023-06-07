using System.Collections;
using System.Collections.Generic;
using System;
using dm_graph.nodes;
using dm_graph.edges;

namespace dm_graph.graphs
{
    public abstract class BaseGraph<edgeType> where edgeType : BaseEdge
    {
        private string m_Name;
        private Type m_EdgeType;

        protected List<BaseNode> m_Nodes = new List<BaseNode>();
        protected List<BaseEdge> m_Edges = new List<BaseEdge>();

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
        public abstract void RemoveNode(BaseNode node);
        public abstract edgeType AddEdge(BaseNode sender, BaseNode receiver);
        public abstract void RemoveEdge(BaseEdge edge);
        public abstract void RemoveEdge(BaseNode sender, BaseNode receiver);
    }

} // namespace dm_graph.graphs
