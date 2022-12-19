namespace SnakeTheGame
{
    public struct RecordsTableNode
    {
        public string Nickname { get; }
        public int Points { get; }

        public RecordsTableNode(string nick, int points)
        {
            Nickname = nick;
            Points = points;
        }
        
        public RecordsTableNode(RecordsTableNode node)
        {
            Nickname = node.Nickname;
            Points = node.Points;
        }
    }
}