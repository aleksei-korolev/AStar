using System.Collections.Generic;
using Roy_T.AStar.Primitives;

namespace Roy_T.AStar.Graphs
{
    public sealed class Node : INode
    {
        public Node(Position position)
        {
            Incoming = new List<IEdge>(0);
            Outgoing = new List<IEdge>(0);

            Position = position;
        }

        public IList<IEdge> Incoming { get; }
        public IList<IEdge> Outgoing { get; }

        public Position Position { get; }

        public void Connect(INode node, Velocity traversalVelocity)
        {
            Edge edge = new Edge(this, node, traversalVelocity);
            Outgoing.Add(edge);
            node.Incoming.Add(edge);
        }

        public void Disconnect(INode node)
        {
            for (int i = Outgoing.Count - 1; i >= 0; i--)
            {
                IEdge edge = Outgoing[i];
                if (edge.End == node)
                {
                    Outgoing.Remove(edge);
                    node.Incoming.Remove(edge);
                }
            }
        }

        public override string ToString() => Position.ToString();
    }
}
