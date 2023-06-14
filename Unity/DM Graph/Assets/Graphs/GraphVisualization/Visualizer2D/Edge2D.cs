using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using dm_graph.edges;
using dm_graph.nodes;

namespace dm_graph.visualization
{
    public class Edge2D : MonoBehaviour
    {
        private BaseEdge m_Edge = null;
        private float m_Depth   = 1.0f;

        [SerializeField] private LineRenderer m_LineRenderer;

        public void SetEdge(BaseEdge edge)
        {
            m_Edge = edge;
        }
        
        public BaseEdge GetNode()
        {
            return m_Edge;
        }

        public void SetBeginEnd(Vector2 begin, Vector2 end)
        {
            m_LineRenderer.SetPositions(
                new[] {
                    new Vector3(begin.x, begin.y, m_Depth),
                    new Vector3(end.x, end.y, m_Depth)
                }
            );
        }
    }
}
