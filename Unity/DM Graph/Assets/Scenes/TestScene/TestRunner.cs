using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using dm_graph.nodes;
using dm_graph.nodes.components;
using dm_graph.graphs;
using dm_graph.edges;
using dm_graph.visualization;

public class TestRunner : MonoBehaviour
{
    [SerializeField] private MapVisualizer2D m_MapVisualizer2D;

    // Start is called before the first frame update
    void Start()
    {
        Test();
    }

    private void Test()
    {
        Debug.Log("Test");

        BaseGraph testGraph = CreateTestGraph();
        m_MapVisualizer2D.VisualizeGraph(testGraph);
    }

    private BaseGraph CreateTestGraph()
    {
        BaseGraph graph = new UndirectedGraph("Test Undirected Graph");

        BaseNode adamNode = new ActorNode("Adam");
        adamNode.GetComponent<LocationComponent>().SetPosition(-3.0, -3.0);
        graph.AddNode(adamNode);

        BaseNode eveNode = new ActorNode("Eve");
        eveNode.GetComponent<LocationComponent>().SetPosition(3.0, -3.0);
        graph.AddNode(eveNode);

        BaseNode paradiseNode = new LocationNode("Paradise");
        paradiseNode.GetComponent<LocationComponent>().SetPosition(0.0, 0.0);
        graph.AddNode(paradiseNode);

        BaseNode godNode = new BaseNode("God");
        graph.AddNode(godNode);

        return graph;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
