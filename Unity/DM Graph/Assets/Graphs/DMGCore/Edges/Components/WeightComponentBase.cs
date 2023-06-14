using System.Collections;
using System.Collections.Generic;
using System;

namespace dm_graph.edges.components
{
    public class WeightComponent : EdgeComponentBase
    {
        private float m_Weight      = 0.0f;
        private float m_WeightMin   = -1.0f;
        private float m_WeightMax   = 1.0f;

        public void SetWeight(float weight)
        {
            m_Weight = Math.Clamp(weight, m_WeightMin, m_WeightMax);
        }

        public float GetWeight()
        {
            return m_Weight;
        }
    }
}