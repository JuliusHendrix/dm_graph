using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using dm_graph.nodes;
using dm_graph.edges;

namespace dm_graph.graphs
{
    public class AdjacencyMatrix
    {
        private List<List<int>> m_AdjacencyMatrix   = new List<List<int>>();

        public void Expand()
        {
            // lengthen all existing lists by one
            foreach (List<int> list in m_AdjacencyMatrix) {
                list.Add(-1);
            }

            // Add additional list for new sender
            List<int> newList = new List<int>();
            for (int i = 0; i < m_AdjacencyMatrix.Count + 1; i++) {
                newList.Add(-1);
            }
            m_AdjacencyMatrix.Add(newList);
        }

        // This function assumes that the node is also removed from the node list
        public bool Contract(int nodeIdx)
        {
            if (nodeIdx >= m_AdjacencyMatrix.Count) {
                Debug.Log("AddConnection(): nodeIdx out of range: " + nodeIdx);
                return false;
            }

            m_AdjacencyMatrix.RemoveAt(nodeIdx);

            foreach (List<int> list in m_AdjacencyMatrix) {
                list.RemoveAt(nodeIdx);
            }

            return true;
        }

        public bool AddConnection(int senderIdx, int receiverIdx, int edgeIdx)
        {
            if (senderIdx >= m_AdjacencyMatrix.Count) {
                Debug.Log("AddConnection(): senderIdx out of range: " + senderIdx);
                return false;
            }

            if (receiverIdx >= m_AdjacencyMatrix.Count) {
                Debug.Log("AddConnection(): receiverIdx out of range: " + senderIdx);
                return false;
            }

            m_AdjacencyMatrix[senderIdx][receiverIdx] = edgeIdx;

            return true;
        }

        // This function assumes the edge is also removed from the edge list
        public void RemoveConnection(int edgeIdx)
        {
            for (int i = 0; i < m_AdjacencyMatrix.Count; i++) {
                for (int j = 0; j < m_AdjacencyMatrix.Count; j++) {
                    if (m_AdjacencyMatrix[i][j] == edgeIdx) {
                        m_AdjacencyMatrix[i][j] = -1;
                    }
                    else if (m_AdjacencyMatrix[i][j] > edgeIdx) {
                        m_AdjacencyMatrix[i][j] -= 1;
                    }
                }
            }
        }

        public int GetConnection(int senderIdx, int receiverIdx)
        {
            if (senderIdx >= m_AdjacencyMatrix.Count) {
                Debug.Log("AddConnection(): senderIdx out of range: " + senderIdx);
                return -1;
            }

            if (receiverIdx >= m_AdjacencyMatrix.Count) {
                Debug.Log("AddConnection(): receiverIdx out of range: " + senderIdx);
                return -1;
            }

            return m_AdjacencyMatrix[senderIdx][receiverIdx];
        }

        public void RemoveConnection(int senderIdx, int receiverIdx) {
            if (senderIdx >= m_AdjacencyMatrix.Count) {
                Debug.Log("RemoveConnection(): senderIdx out of range: " + senderIdx);
                return;
            }

            if (receiverIdx >= m_AdjacencyMatrix.Count) {
                Debug.Log("RemoveConnection(): receiverIdx out of range: " + senderIdx);
                return;
            }

            int edgeIdx = m_AdjacencyMatrix[senderIdx][receiverIdx];
            if (edgeIdx != -1) {
                RemoveConnection(edgeIdx);
            }
        }
    }

    public abstract class BaseGraph
    {
        private string m_Name;

        protected List<BaseNode>    m_Nodes             = new List<BaseNode>();
        protected List<BaseEdge>    m_Edges             = new List<BaseEdge>();
        protected AdjacencyMatrix   m_AdjacencyMatrix   = new AdjacencyMatrix();

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
        public abstract bool AddEdge(BaseEdge edge);
        public abstract void RemoveEdge(BaseEdge edge);
        public abstract void RemoveEdge(BaseNode sender, BaseNode receiver);
        public abstract BaseEdge GetEdge(BaseNode sender, BaseNode receiver);
    }

} // namespace dm_graph.graphs
