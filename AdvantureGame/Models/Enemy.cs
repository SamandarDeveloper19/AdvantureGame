namespace AdvantureGame.Models
{
    public struct Enemy
    {
        private CharacterType Character = CharacterType.Enemy;
        public PositionType Position { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        
        public Enemy(PositionType position, int health, int attackPower)
        {
            Position = position;
            Health = health;
            AttackPower = attackPower;
        }
    }
}
