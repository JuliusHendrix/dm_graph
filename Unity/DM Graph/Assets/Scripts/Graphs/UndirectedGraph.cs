using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using dm_graph.nodes;

namespace dm_graph.graphs
{
    public class UndirectedGraph : BaseGraph
    {
        public UndirectedGraph(string name) : base(name) {}

        public override bool AddNode(BaseNode node)
        {
            if (m_Nodes.Contains(node)) {
                Debug.Log("AddNode(): node already in graph: " + node.GetName());
                return false;
            }

            m_Nodes.Add(node);

            // TODO: update adjanecy matrix

            return true;
        }

        public override bool RemoveNode(BaseNode node)
        {
            if (!m_Nodes.Contains(node)) {
                Debug.Log("RemoveNode(): node not in graph: " + node.GetName());
                return false;
            }
            m_Nodes.Remove(node);

            // TODO: update adjanecy matrix
            
            return true;
        }
    }
} // namespace dm_graph.graphs
