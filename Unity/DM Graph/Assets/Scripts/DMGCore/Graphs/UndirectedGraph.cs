using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using dm_graph.nodes;
using dm_graph.edges;

namespace dm_graph.graphs
{
    public class UndirectedGraph<edgeType> : BaseGraph<edgeType> where edgeType : BaseEdge
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

        public override void RemoveNode(BaseNode node)
        {
            if (!m_Nodes.Contains(node)) {
                Debug.Log("RemoveNode(): node not in graph: " + node.GetName());
                return;
            }
            m_Nodes.Remove(node);

            // TODO: update adjanecy matrix
        }

        public override edgeType AddEdge(BaseNode sender, BaseNode receiver)
        {
            if (!m_Nodes.Contains(sender)) {
                Debug.Log("RemoveNode(): sender not in graph: " + sender.GetName());
                return null;
            }

            if (!m_Nodes.Contains(receiver)) {
                Debug.Log("RemoveNode(): receiver not in graph: " + receiver.GetName());
                return null;
            }

            // check if already in adjacency matrix
            edgeType newEdge = (edgeType)Activator.CreateInstance(typeof(edgeType), sender, receiver);

            m_Edges.Add(newEdge);

            // TODO: update adjacency matrix

            return newEdge;
        }

        public override void RemoveEdge(BaseEdge edge)
        {
            if (!m_Edges.Contains(edge)) {
                Debug.Log("RemoveNode(): edge not in graph");
                return;
            }
            m_Edges.Remove(edge);

            // TODO: update adjacency matrix
        }

        public override void RemoveEdge(BaseNode sender, BaseNode receiver)
        {
            throw new NotImplementedException();
        }
    }
} // namespace dm_graph.graphs
