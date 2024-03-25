using AdvantureGame.Models;

namespace AdvantureGame
{
    public class GameService
    {
        Obstacle obs1_L1 = new Obstacle(
            new PositionType()
            {
                Level = 1,
                Status = Position.Left
            },
            damage: 20);

        Obstacle obs2_L1 = new Obstacle(
            new PositionType()
            {
                Level = 1,
                Status = Position.Middle
            },
            damage: 40);

        Obstacle obs3_L1 = new Obstacle(
            new PositionType()
            {
                Level = 1,
                Status = Position.Right
            },
            damage: 20);

        Obstacle obs1_L2 = new Obstacle(
            new PositionType()
            {
                Level = 2,
                Status = Position.Left
            },
            damage: 20);

        Enemy enemy1_L2 = new Enemy(
            new PositionType()
            {
                Level = 2,
                Status = Position.Middle
            },
            health: 100,
            attackPower: 60);

        Obstacle obs2_L2 = new Obstacle(
            new PositionType()
            {
                Level = 2,
                Status = Position.Right
            },
            damage: 40);

        Enemy enemy1_L3 = new Enemy(
            new PositionType()
            {
                Level = 3,
                Status = Position.Left
            },
            health: 30,
            attackPower: 40);

        Obstacle obs1_L3 = new Obstacle(
            new PositionType()
            {
                Level = 3,
                Status = Position.Middle
            },
            damage: 20);

        Obstacle obs2_L3 = new Obstacle(
            new PositionType()
            {
                Level = 3,
                Status = Position.Right
            },
            damage: 40);

        public void StartGame()
        {
            Console.Write("What is your name: ");
            string playerName = Console.ReadLine();

            Player player = new Player(playerName);

            while (true)
            {
                for (int level = 1; level <= 3; level++)
                {
                    Console.Write($"Which way do you choose in {level}-level:" +
                        "\n1. Left" +
                        "\n2. Middle" +
                        "\n3. Right" +
                        "\nEnter: ");

                    int option = int.Parse(Console.ReadLine());

                    Position position;

                    if (option == 1) position = Position.Left;
                    else if (option == 2) position = Position.Middle;
                    else position = Position.Right;

                    switch (position)
                    {
                        case Position.Left:
                            {
                                player.Position =
                                    new PositionType() { Level = level, Status = Position.Left };
                            
                                if (level is 1) player.Health -= obs1_L1.Damage;
                                else if (level is 2) player.Health -= obs1_L2.Damage;
                                else
                                {
                                    if (player.Health > enemy1_L3.Health)
                                    {
                                        player.Health -= enemy1_L3.AttackPower;

                                        if (player.Health > 0)
                                        {
                                            player.Succeeded(); return;
                                        }
                                    }
                                    else
                                    {
                                        player.Failed(); return;
                                    }
                                }

                                Console.WriteLine($"Player's health: {player.Health}" +
                                    $"{Environment.NewLine}");
                                break;
                            }
                        case Position.Middle:
                            {
                                player.Position =
                                    new PositionType() { Level = level, Status = Position.Middle };

                                if (level is 1) player.Health -= obs2_L1.Damage;
                                else if (level is 2)
                                {
                                    player.Health -= enemy1_L2.AttackPower;
                                    if (player.Health <= 0)
                                    {
                                        player.Failed(); return;
                                    }
                                }
                                else
                                {
                                    player.Health -= obs1_L3.Damage;
                                    if (player.Health <= 0)
                                    {
                                        player.Failed(); return;
                                    }
                                    else
                                    {
                                        player.Succeeded(); return;
                                    }
                                }

                                Console.WriteLine($"Player's health: {player.Health}" +
                                    $"{Environment.NewLine}");
                                break;
                            }
                        case Position.Right:
                            {
                                player.Position =
                                    new PositionType() { Level = level, Status = Position.Middle };

                                if (level is 1) player.Health -= obs3_L1.Damage;
                                else if (level is 2) player.Health -= obs2_L2.Damage;
                                else
                                {
                                    player.Health -= obs2_L3.Damage;
                                    if (player.Health <= 0)
                                    {
                                        player.Failed(); return;
                                    }
                                    player.Succeeded(); return;
                                }

                                Console.WriteLine($"Player's health: {player.Health}" +
                                    $"{Environment.NewLine}");
                                break;
                            }
                    }
                }
            }
        }
    }
}
