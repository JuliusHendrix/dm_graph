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
        BaseNode other      = new BaseNode("other");

        undirectedGraph.AddNode(sender);
        undirectedGraph.AddNode(receiver);
        undirectedGraph.AddNode(other);

        WeightedEdge edge1  = new WeightedEdge(sender, receiver);
        WeightedEdge edge2  = new WeightedEdge(other, sender);

        Assert.IsTrue(undirectedGraph.AddEdge(edge1));
        Assert.IsTrue(undirectedGraph.AddEdge(edge2));

        BaseEdge retreivedEdge1 = undirectedGraph.GetEdge(sender, receiver);
        BaseEdge retreivedEdge2 = undirectedGraph.GetEdge(other, sender);
        Assert.NotNull(retreivedEdge1);
        Assert.NotNull(retreivedEdge2);

        var (retreivedEdge1Sender, retreivedEdge1Receiver) = retreivedEdge1.GetSenderReceiver();
        Assert.AreEqual(retreivedEdge1Sender, sender);
        Assert.AreEqual(retreivedEdge1Receiver, receiver);

        var (retreivedEdge2Sender, retreivedEdge2Receiver) = retreivedEdge2.GetSenderReceiver();
        Assert.AreEqual(retreivedEdge2Sender, other);
        Assert.AreEqual(retreivedEdge2Receiver, sender);

        WeightComponent edgeWeight = retreivedEdge1.GetComponent<WeightComponent>();
        Assert.NotNull(edgeWeight);

        undirectedGraph.RemoveEdge(edge1);
        BaseEdge removedEdge    = undirectedGraph.GetEdge(sender, receiver);
        BaseEdge remainingEdge  = undirectedGraph.GetEdge(other, sender);
        Assert.IsNull(removedEdge);
        Assert.NotNull(remainingEdge);
    }

    public void TestGraphFilter()
    {
        UndirectedGraph undirectedGraph = new UndirectedGraph("Test Undirected Graph");

        BaseNode node1 = new BaseNode("Node 1");
        BaseNode node2 = new ActorNode("Node 2");
        BaseNode node3 = new LocationNode("Node 3");

        undirectedGraph.AddNode(node1);
        undirectedGraph.AddNode(node2);
        undirectedGraph.AddNode(node3);

        WeightedEdge edge1  = new WeightedEdge(node1, node2);
        WeightedEdge edge2  = new WeightedEdge(node3, node1);

        // GraphFilter graphFilter = new GraphFilter(undirectedGraph);
        // graphFilter.AddNodeComponentFilter(typeof(BaseEdge));
    }
}