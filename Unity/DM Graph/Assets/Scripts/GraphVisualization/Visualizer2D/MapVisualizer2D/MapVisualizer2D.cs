using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using dm_graph.nodes;
using dm_graph.nodes.components;
using dm_graph.edges;
using dm_graph.graphs;

namespace dm_graph.visualization
{
    public class MapVisualizer2D : MonoBehaviour
    {
        [SerializeField] private GameObject m_Node2DPrefab;
        [SerializeField] private Transform  m_NodesContainer;
        [SerializeField] private Transform  m_EdgesContainer;
        // private List<Transform>             m_Nodes = new List<Transform>();
        // private List<Transform>             m_Edges = new List<Transform>();
        private BaseGraph                   m_Graph;

        private void VisualizeNode(BaseNode node)
        {
            LocationComponent location = node.GetComponent<LocationComponent>();
            if (location is null) {
                Debug.Log("Node doesn't have a location: " + node.GetName());
                return;
            }

            GameObject  newNode2DObject     = Instantiate(m_Node2DPrefab);
            Node2D      newNode2d           = newNode2DObject.GetComponent<Node2D>();
            
            newNode2DObject.transform.SetParent(m_NodesContainer);
            
            var (x, y) = location.GetPosition();
            newNode2DObject.transform.position = new Vector3((float)x, (float)y, (float)0.0);

            // m_Nodes.Add(newNode2DObject.transform);

            newNode2d.SetNode(node);
        }

        public void VisualizeGraph(BaseGraph graph)
        {
            List<BaseNode> nodes = graph.GetNodes();
            foreach (BaseNode node in nodes) {
                VisualizeNode(node);
            }

            // vizualize edges?
        }

        // Start is called before the first frame update
        // void Start()
        // {
            
        // }

        // Update is called once per frame
        // void Update()
        // {
            
        // }
    }
}
