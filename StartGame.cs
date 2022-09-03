using static Gobblets.WonSequences;

namespace Gobblets
{
    public class StartGame
    {
        public static void gameRunner(List<Player> players)
        {
            string[] fieldSequence = Enumerable.Repeat("   ", 9).ToArray();
            bool won = false;
            while (!won)
            {
                Player player1 = players.Where(p => p.FirstMove == true).First();
                Player player2 = players.Where(p => p.FirstMove == false).First();

                if (player1.MadeAMove == false)
                {
                    makeAMove(player1, fieldSequence);
                    player1.MadeAMove = !player1.MadeAMove;
                }
                else
                {
                    makeAMove(player2, fieldSequence);
                    player1.MadeAMove = !player1.MadeAMove;
                }
                
                if(player1.Won == true || player2.Won == true) {
                    won = true;
                }
            }
        }

        private static void makeAMove(Player player, string[] fieldSequence)
        {
            int move = 0;
            player.CurrentPieceSize = pieceSizePicker(player);

            //There is a mistake... I know... But, without a mistake, code doesn't work :) I don't know why... 
            while (!(1 <= move && move <= 9))
            {
                Console.WriteLine($"{player.Name}, it's your move (1-9)");
                
                
                FieldBuilder.printField(player, fieldSequence);
                Int32.TryParse(Console.ReadLine(), out move);
                Player.PrevMove = move;

                Console.Clear();
                switch (player.CurrentPieceSize)
                {
                    case 1:
                        someMethod(player, move, fieldSequence, ref player.smallPieces, ref player.smallField, " x ", " o ");
                        break;
                    case 2:
                        someMethod(player, move, fieldSequence, ref player.mediumPieces, ref player.mediumField, " X ", " O ");
                        break;
                    case 3:
                        someMethod(player, move, fieldSequence, ref player.bigPieces, ref player.bigField, "!X!", "!O!");
                        break;
                }
                player.Fields.AddRange(player.SmallField);
                player.Fields.AddRange(player.MediumField);
                player.Fields.AddRange(player.BigField);

                foreach (var sequence in wonSequences)
                {
                    List<int> intersection = player.Fields.Intersect(sequence).ToList();

                    if (intersection.SequenceEqual(sequence))
                    {
                        player.Won = true;
                        System.Console.WriteLine($"Player {player.Name} Wins! WooHoo...");
                    }
                }
            }
            
        }

        public static void someMethod(Player player, int move, string[] fieldSequence, ref int pieceSize, ref List<int> fieldSize, string x, string o)
        {
            if (pieceSize > 0 && isMoveLegal(move, Player.SmallFieldGlobal))
            {
                Player.SmallFieldGlobal.Add(move);
                player.SmallField.Add(move);
                if(player.Piece)
                {
                    fieldSequence[move-1] = x;
                }
                else
                {
                    fieldSequence[move-1] = o;
                }                            
                pieceSize -= 1;
            }
            else
            {
                Console.WriteLine("Wrong move... Try one more time");
                player.CurrentPieceSize = pieceSizePicker(player);
                move = 0;
            }
        }

        private static bool isMoveLegal(int move, List<int> field)
        {
            if (field.Contains(move))
            {
                System.Console.WriteLine("Sorry, but it's not a chess game...\nTry one more time");
                return false;
            }
            return true;
        }

        private static int pieceSizePicker(Player player)
        {
            int pieceSize = 0;
            while (((pieceSize != 1) && (pieceSize != 2) && (pieceSize != 3)))
            {
                Console.WriteLine($"{player.Name}, choose your piece size\n1.Small\n2.Medium\n3.Big");
                Console.WriteLine($"You have: {player.SmallPieces} small pieces | {player.MediumPieces} medium pieces | {player.BigPieces} big pieces");
                Int32.TryParse(Console.ReadLine(), out pieceSize);
                Console.Clear();
            }
            return pieceSize;
        }
    }
}