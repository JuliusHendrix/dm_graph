using System.Collections;
using System.Collections.Generic;
using System;
using dm_graph.nodes.components;

namespace dm_graph.nodes
{
    public class BaseNode
    {
        private string m_Name;
        private string m_Notes = "";
        protected List<NodeComponentBase> m_Components = new List<NodeComponentBase>();

        public BaseNode(string name)
        {
            m_Name = name;
        }

        public void SetName(string name)
        {
            m_Name = name;
        }

        public string GetName()
        {
            return m_Name;
        }

        public void SetNotes(string notes)
        {
            m_Notes = notes;
        }

        public string GetNotes()
        {
            return m_Notes;
        }

        public T GetComponent<T>() where T : NodeComponentBase
        {
            foreach (NodeComponentBase component in m_Components) {
                if (component is T) {
                    return (T)component;
                }
            }
            return null;
        }
    }
} // namespace dm_graph

