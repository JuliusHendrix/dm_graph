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
    private Map         m_TestMap;
    private BaseGraph   m_TestGraph;

    // Start is called before the first frame update
    void Start()
    {
        CreateTestMap();
        CreateTestGraph();
        Test();
    }

    private void Test()
    {
        Debug.Log("Test");

        m_MapVisualizer2D.VisualizeGraph(m_TestGraph, m_TestMap);
    }

    private void CreateTestMap()
    {
        m_TestMap = new Map("Test Map");
    }

    private void CreateTestGraph()
    {
        m_TestGraph = new UndirectedGraph("Test Undirected Graph");

        BaseNode adamNode = new ActorNode("Adam");
        adamNode.GetComponent<LocationComponent>().SetPosition(
            m_TestMap, new Vector2(-3.0f, -3.0f)
        );
        m_TestGraph.AddNode(adamNode);

        BaseNode eveNode = new ActorNode("Eve");
        eveNode.GetComponent<LocationComponent>().SetPosition(
            m_TestMap, new Vector2(3.0f, -3.0f)
        );
        m_TestGraph.AddNode(eveNode);

        BaseNode paradiseNode = new LocationNode("Paradise");
        paradiseNode.GetComponent<LocationComponent>().SetPosition(
            m_TestMap, new Vector2(0.0f, 0.0f)
        );
        m_TestGraph.AddNode(paradiseNode);

        BaseNode godNode = new BaseNode("God");
        m_TestGraph.AddNode(godNode);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
