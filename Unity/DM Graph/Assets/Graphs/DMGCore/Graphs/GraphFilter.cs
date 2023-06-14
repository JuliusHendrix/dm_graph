using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using dm_graph.nodes;
using dm_graph.nodes.components;
using dm_graph.edges;
using dm_graph.graphs;

namespace dm_graph.graphs
{
    public class GraphFilter
    {
        private List<Type> m_NodeComponentFilters = new List<Type>();

        public (List<BaseNode>, List<BaseEdge>) Apply(BaseGraph graph)
        {
            List<BaseNode> filteredNodes = FilterNodesByComponents(graph.GetNodes());
            List<BaseEdge> filteredEdges = FilterEdgesByConnectedNodes(graph.GetEdges(), filteredNodes);

            return (filteredNodes, filteredEdges);
        }

        public static GraphFilter operator +(GraphFilter a, GraphFilter b)
        {
            foreach (Type type in b.m_NodeComponentFilters) {
                if (a.m_NodeComponentFilters.Contains(type)) {
                    continue;
                }
                a.m_NodeComponentFilters.Add(type);
            }
            return a;
        }

        public void AddNodeComponentFilter(Type componentType)
        {
            if (!componentType.IsSubclassOf(typeof(NodeComponentBase))) {
                Debug.Log("not a component type");
                return;
            }
            
            if (m_NodeComponentFilters.Contains(componentType)) {
                Debug.Log("Component type already in filters");
                return;
            }
            m_NodeComponentFilters.Add(componentType);
        }

        private List<BaseNode> FilterNodesByComponent(List<BaseNode> nodes, Type componentType)
        {
            List<BaseNode> filteredNodes = new List<BaseNode>();
            foreach (BaseNode node in nodes) {
                if (node.HasComponent(componentType)) {
                    filteredNodes.Add(node);
                }
            }

            return filteredNodes;
        }
        private List<BaseNode> FilterNodesByComponents(List<BaseNode> nodes)
        {
            List<BaseNode> filteredNodes = nodes;
            foreach (Type componentType in m_NodeComponentFilters) {
                filteredNodes = FilterNodesByComponent(filteredNodes, componentType);
            }
            return filteredNodes;
        }

        private List<BaseEdge> FilterEdgesByConnectedNodes(List<BaseEdge> edges, List<BaseNode> nodes)
        {
            List<BaseEdge> filteredEdges = new List<BaseEdge>();
            foreach (BaseEdge edge in edges) {
                var (sender, receiver) = edge.GetSenderReceiver();
                if (nodes.Contains(sender) && nodes.Contains(receiver)) {
                    filteredEdges.Add(edge);
                }
            }
            return filteredEdges;
        }
    }
} // namespace dm_graph.graphs