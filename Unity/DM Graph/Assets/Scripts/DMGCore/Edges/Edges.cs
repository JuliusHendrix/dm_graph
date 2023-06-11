using System;
using System.Collections;
using System.Collections.Generic;
using dm_graph.nodes;
using dm_graph.edges.components;

namespace dm_graph.edges
{
    public class WeightedEdge : BaseEdge
    {
        public WeightedEdge(BaseNode sender, BaseNode receiver) : base(sender, receiver)
        {
            m_Components.Add(new WeightComponent());
        }
    }
}