using System.Collections;
using System.Collections.Generic;

namespace dm_graph.nodes.components
{
    public class LocationComponent : NodeComponentBase
    {
        private double xPosition = 0.0;
        private double yPosition = 0.0;

        public void SetPosition(double x, double y)
        {
            // check map bounds?
            xPosition = x;
            yPosition = y;
        }

        public (double, double) GetPosition()
        {
            return (xPosition, yPosition);
        }
    }
} // namespace dm_graph
