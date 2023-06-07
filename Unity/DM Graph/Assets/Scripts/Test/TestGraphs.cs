using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using dm_graph.nodes;
using dm_graph.nodes.components;
using dm_graph.graphs;
using dm_graph.edges;

public class TestGraphs
{
    [Test]
    public void TestUndirectedGraph()
    {
        UndirectedGraph<WeightedEdge> undirectedGraph = new UndirectedGraph<WeightedEdge>("Test Undirected Graph");

        BaseNode sender     = new BaseNode("sender");
        BaseNode receiver   = new BaseNode("receiver");

        undirectedGraph.AddNode(sender);
        undirectedGraph.AddNode(receiver);

        WeightedEdge newEdge = undirectedGraph.AddEdge(sender, receiver);
        Assert.AreEqual(newEdge.GetWeight(), 0.0f);
    }
}