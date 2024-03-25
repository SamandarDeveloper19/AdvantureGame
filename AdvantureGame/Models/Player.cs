namespace AdvantureGame.Models
{
    public struct Player
    {
        public string Name { get; set; }
        public PositionType Position { get; set; }
        public int Health { get; set; } = 100;

        public Player(string name) =>
            Name = name;

        public void Failed() =>
            Console.WriteLine($"Player named ({Name}) died at " +
                $"{Position.Status} side of level {Position.Level}!");

        public void Succeeded() =>
            Console.WriteLine($"Player named ({Name}) with {Health} health won award!");
    }
}
