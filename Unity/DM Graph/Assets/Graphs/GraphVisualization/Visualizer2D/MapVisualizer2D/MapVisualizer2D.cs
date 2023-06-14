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
        [SerializeField] private GameObject m_Edge2DPrefab;
        [SerializeField] private Transform  m_NodesContainer;
        [SerializeField] private Transform  m_EdgesContainer;
        private BaseGraph                   m_Graph;
        private Map                         m_Map;

        private void VisualizeNode(BaseNode node)
        {
            LocationComponent location = node.GetComponent<LocationComponent>();
            if (location is null) { // the graph filter should make this check redudant
                Debug.Log("Node doesn't have a location: " + node.GetName());
                return;
            }
            var (isInMap, position) = location.GetPosition(m_Map);
            if (!isInMap) {
                Debug.Log("Node " + node.GetName() + " is not in map: " + m_Map.name);
                return;
            }

            GameObject  newNode2DObject     = Instantiate(m_Node2DPrefab);
            Node2D      newNode2d           = newNode2DObject.GetComponent<Node2D>();
            
            newNode2DObject.transform.SetParent(m_NodesContainer);
            newNode2DObject.transform.position = new Vector3(position.x, position.y, (float)0.0);

            newNode2d.SetNode(node);
        }

        public void VisualizeEdge(BaseEdge edge)
        {
            var (sender, receiver) = edge.GetSenderReceiver();
            LocationComponent senderLocation    = sender.GetComponent<LocationComponent>();
            LocationComponent receiverLocation  = receiver.GetComponent<LocationComponent>();
            var (senderIsInMap, senderPosition)     = senderLocation.GetPosition(m_Map);
            var (receiverIsInMap, receiverPosition) = receiverLocation.GetPosition(m_Map);

            if (!senderIsInMap || !receiverIsInMap) {
                Debug.Log("Sender or receiver is not in map: " + m_Map.name);
                return;
            }

            GameObject  newEdge2DObject     = Instantiate(m_Edge2DPrefab);
            Edge2D      newEdge2d           = newEdge2DObject.GetComponent<Edge2D>();
            
            newEdge2DObject.transform.SetParent(m_NodesContainer);
            newEdge2d.SetBeginEnd(
                senderPosition,
                receiverPosition
            );
        }

        public void VisualizeGraph(BaseGraph graph, Map map)
        {
            m_Map = map;
            GraphFilter graphFilter = new GraphFilter();
            graphFilter.AddNodeComponentFilter(typeof(LocationComponent));
            var (nodes, edges) = graphFilter.Apply(graph);

            foreach (BaseNode node in nodes) {
                VisualizeNode(node);
            }

            foreach (BaseEdge edge in edges) {
                VisualizeEdge(edge);
            }
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
