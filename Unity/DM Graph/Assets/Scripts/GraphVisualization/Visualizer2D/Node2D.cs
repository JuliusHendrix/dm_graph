using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using dm_graph.nodes;

namespace dm_graph.visualization
{
    public class Node2D : MonoBehaviour
    {
        private BaseNode m_Node = null;

        [SerializeField] private TMPro.TMP_Text m_NameLabel;
        [SerializeField] private SpriteRenderer m_SpriteRenderer;

        public void SetNode(BaseNode node)
        {
            m_Node = node;
            SetName(node.GetName());
            SetColor();
        }
        
        public BaseNode GetNode()
        {
            return m_Node;
        }

        private void SetName(string name)
        {
            m_NameLabel.text = name;
        }

        private void SetColor()
        {
            if (m_Node is LocationNode) {
                m_SpriteRenderer.color = Color.green;
            }
            else if (m_Node is ActorNode) {
                m_SpriteRenderer.color = Color.red;
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
