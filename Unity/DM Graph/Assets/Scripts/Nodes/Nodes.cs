using System.Collections;
using System.Collections.Generic;
using dm_graph.nodes.components;

namespace dm_graph.nodes
{
    public class LocationNode : BaseNode
    {
        public LocationNode(string name) : base(name)
        {
            m_Components.Add(new LocationComponent());
        }
    }
    
    public class ActorNode : BaseNode
    {
        public ActorNode(string name) : base(name)
        {
            m_Components.Add(new LocationComponent());
            m_Components.Add(new AlignmentComponent());
        }
    }

} // namespace dm_graph
