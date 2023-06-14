using System.Collections;
using System.Collections.Generic;
using System;
using dm_graph.nodes;
using dm_graph.edges.components;

namespace dm_graph.edges
{
    public class BaseEdge
    {
        private string m_Notes = "";
        private BaseNode m_Sender;
        private BaseNode m_Receiver;
        protected List<EdgeComponentBase> m_Components = new List<EdgeComponentBase>();

        public BaseEdge(BaseNode sender, BaseNode receiver)
        {
            m_Sender    = sender;
            m_Receiver  = receiver;
        }

        public bool HasComponent(Type type)
        {
            foreach (EdgeComponentBase component in m_Components) {
                if (component.GetType() == type.GetType()) {
                    return true;
                }
            }
            return false;
        }

        public T GetComponent<T>() where T : EdgeComponentBase
        {
            foreach (EdgeComponentBase component in m_Components) {
                if (component.GetType() == typeof(T)) {
                    return (T)component;
                }
            }
            return null;
        }

        public void SetNotes(string notes)
        {
            m_Notes = notes;
        }

        public string GetNotes()
        {
            return m_Notes;
        }

        public (BaseNode, BaseNode) GetSenderReceiver()
        {
            return (m_Sender, m_Receiver);
        }
    }
}