namespace Gobblets
{
    public static class Menu
    {
        public static List<Player> playerBuilder()
        {
            List<Player> players = new List<Player>();           

            Player player1 = new Player(playerName("player 1"), piecePicker(), firstMove());
            Player player2 = new Player(playerName("player 2"), !player1.Piece, !player1.FirstMove);

            players.Add(player1);
            players.Add(player2);

            return players;
        }

        private static string playerName(string player)
        {
            string name = "";
            while(string.IsNullOrEmpty(name))
            {
                showMenu($"Type your name {player}");
                name = Console.ReadLine();
                Console.Clear();
            }
            return name;
        }

        private static bool firstMove() {
            string? answer = "";
            while(((answer.ToLower() != "y") && (answer.ToLower() != "n")))
            {
                showMenu("Do you want to make first move?(y/n)");
                answer = Console.ReadLine();
                Console.Clear();
            }  
            if(answer == "y")
            {
                return true;
            }
            return false;
        }

        private static bool piecePicker() {
            int piece = 0;
            while(!(1 <= piece && piece <= 2)) {
                showMenu("Choose your piece\n1.X\n2.O");
                Int32.TryParse(Console.ReadLine(), out piece);
                Console.Clear();                
            }
            return piece == 1 ? true : false;
        }

        private static void showMenu(string question) {
            Console.WriteLine("Welcome to the Gobblets Game!");
            Console.WriteLine(new string('*', 30));        
            Console.WriteLine("Menu");
            System.Console.WriteLine(question);
        }   
    }
}