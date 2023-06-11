using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using dm_graph.nodes;
using dm_graph.nodes.components;
using dm_graph.edges.components;
using dm_graph.graphs;
using dm_graph.edges;

public class TestGraphs
{
    [Test]
    public void TestUndirectedGraph()
    {
        UndirectedGraph undirectedGraph = new UndirectedGraph("Test Undirected Graph");

        BaseNode sender     = new BaseNode("sender");
        BaseNode receiver   = new BaseNode("receiver");

        undirectedGraph.AddNode(sender);
        undirectedGraph.AddNode(receiver);

        WeightedEdge edge = new WeightedEdge(sender, receiver);

        Assert.IsTrue(undirectedGraph.AddEdge(edge));

        BaseEdge retreivedEdge = undirectedGraph.GetEdge(sender, receiver);
        Assert.NotNull(retreivedEdge);

        var (retreivedEdgeSender, retreivedEdgeReceiver) = retreivedEdge.GetSenderReceiver();
        Assert.AreEqual(retreivedEdgeSender, sender);
        Assert.AreEqual(retreivedEdgeReceiver, receiver);

        WeightComponent edgeWeight = retreivedEdge.GetComponent<WeightComponent>();
        Assert.NotNull(edgeWeight);

        undirectedGraph.RemoveEdge(edge);
        BaseEdge removedEdge = undirectedGraph.GetEdge(sender, receiver);
        Assert.IsNull(removedEdge);
    }
}