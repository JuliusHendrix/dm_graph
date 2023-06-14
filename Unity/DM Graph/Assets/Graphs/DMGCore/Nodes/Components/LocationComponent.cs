using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace dm_graph.nodes.components
{
    public struct Map
    {
        public string       name;
        public float        imageScaleFactor;
        public Texture2D    mapTexture;

        public Map(string _name)
        {
            name                = _name;
            imageScaleFactor    = 1.0f;
            mapTexture          = null;
        }
    }

    public class LocationComponent : NodeComponentBase
    {
        private Dictionary<Map,Vector2> m_Locations = new Dictionary<Map, Vector2>();

        public bool SetPosition(Map map, Vector2 position)
        {
            m_Locations[map] = position;
            return true;
        }

        public (bool, Vector2) GetPosition(Map map)
        {
            if (!m_Locations.ContainsKey(map)) {
                Debug.Log("Unknown map: " + map.name);
                return (false, new Vector2());
            }
            return (true, m_Locations[map]);
        }
    }
} // namespace dm_graph
