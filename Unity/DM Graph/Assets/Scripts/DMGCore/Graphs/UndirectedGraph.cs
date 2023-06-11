using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using dm_graph.nodes;
using dm_graph.edges;

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
            m_AdjacencyMatrix.Expand();

            return true;
        }

        public override void RemoveNode(BaseNode node)
        {
            if (!m_Nodes.Contains(node)) {
                Debug.Log("RemoveNode(): node not in graph: " + node.GetName());
                return;
            }
            m_Nodes.Remove(node);
            m_AdjacencyMatrix.Contract(m_Nodes.IndexOf(node));
        }

        public override bool AddEdge(BaseEdge edge)
        {
            var (sender, receiver) = edge.GetSenderReceiver();
            if (!m_Nodes.Contains(sender)) {
                Debug.Log("RemoveNode(): sender not in graph: " + sender.GetName());
                return false;
            }

            if (!m_Nodes.Contains(receiver)) {
                Debug.Log("RemoveNode(): receiver not in graph: " + receiver.GetName());
                return false;
            }

            m_Edges.Add(edge);
            m_AdjacencyMatrix.AddConnection(
                m_Nodes.IndexOf(sender),
                m_Nodes.IndexOf(receiver),
                m_Edges.Count - 1
            );
            m_AdjacencyMatrix.AddConnection( 
                m_Nodes.IndexOf(receiver),
                m_Nodes.IndexOf(sender),
                m_Edges.Count - 1
            );

            return true;
        }

        public override void RemoveEdge(BaseEdge edge)
        {
            if (!m_Edges.Contains(edge)) {
                Debug.Log("RemoveNode(): edge not in graph");
                return;
            }
            m_Edges.Remove(edge);
            m_AdjacencyMatrix.RemoveConnection(m_Edges.IndexOf(edge));
        }

        public override void RemoveEdge(BaseNode sender, BaseNode receiver)
        {
            m_AdjacencyMatrix.RemoveConnection(m_Nodes.IndexOf(sender), m_Nodes.IndexOf(receiver));
            m_AdjacencyMatrix.RemoveConnection(m_Nodes.IndexOf(receiver), m_Nodes.IndexOf(sender));
        }

        public override BaseEdge GetEdge(BaseNode sender, BaseNode receiver)
        {
            int edgeIdx = m_AdjacencyMatrix.GetConnection(m_Nodes.IndexOf(sender), m_Nodes.IndexOf(receiver));

            if (edgeIdx == -1) {
                return null;
            }

            return m_Edges[edgeIdx];
        }
    }
} // namespace dm_graph.graphs
