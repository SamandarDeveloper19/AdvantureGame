namespace AdvantureGame.Models
{
    public struct Obstacle
    {
        private CharacterType Character = CharacterType.Obstacle;
        public PositionType Position { get; set; }
        public int Damage { get; set; }

        public Obstacle(PositionType position, int damage)
        {
            Position = position;
            Damage = damage;
        }
    }
}
