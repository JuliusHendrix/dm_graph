
namespace dm_graph.nodes.components
{
    public enum Alignment
    {
        LAWFUL_GOOD,
        NEUTRAL_GOOD,
        CHAOTIC_GOOD,
        LAWFUL_NEUTRAL,
        TRUE_NEUTRAL,
        CHAOTIC_NEUTRAL,
        LAWFUL_EVIL,
        NEUTRAL_EVIL,
        CHAOTIC_EVIL
    }

    public class AlignmentComponent : NodeComponentBase
    {
        Alignment m_Alignment = Alignment.TRUE_NEUTRAL;

        public void SetAlignment(Alignment alignment)
        {
            m_Alignment = alignment;
        }

        public Alignment GetAlignment()
        {
            return m_Alignment;
        }
    }
} // namespace dm_graph