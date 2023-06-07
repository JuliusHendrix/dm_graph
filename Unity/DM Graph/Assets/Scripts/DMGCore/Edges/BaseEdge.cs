using System.Collections;
using System.Collections.Generic;
using System;
using dm_graph.nodes;

namespace dm_graph.edges
{
    public class BaseEdge
    {
        private string m_Notes = "";
        private BaseNode m_Sender;
        private BaseNode m_Receiver;

        public BaseEdge(BaseNode sender, BaseNode receiver)
        {
            m_Sender    = sender;
            m_Receiver  = receiver;
        }

        public void SetNotes(string notes)
        {
            m_Notes = notes;
        }

        public string GetNotes()
        {
            return m_Notes;
        }

        public Tuple<BaseNode, BaseNode> GetSenderReceiver()
        {
            return Tuple.Create(m_Sender, m_Receiver);
        }
    }
}