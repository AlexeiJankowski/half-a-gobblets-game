namespace Gobblets
{
    public static class FieldBuilder
    {

        public static void printField(Player player, string[] sequence)
        {
            char horizontal = '-';
            System.Console.WriteLine();

            //It's not the most readable code, but it's writing the game field line after line
            string fieldString = "";
            for (int i = 0; i < 9; i = i + 3)
            {
                fieldString += buildLine() + "\n";
                for (int j = 0; j < 3; j++)
                {
                    fieldString += buildWithPiece(sequence[i + j]);
                    if (j < 2)
                    {
                        fieldString += "|";
                    }
                    else 
                    {
                        fieldString += "\n";
                    }
                }
                fieldString += buildLine() + "\n";
                if(i < 6)
                {
                    fieldString += buildHorizontal(horizontal) + "\n";
                }
            }

            System.Console.WriteLine(fieldString);

            System.Console.WriteLine();
        }



        public static string buildHorizontal(char horizontal)
        {
            return new string(horizontal, 7) + '+' +
                new string(horizontal, 7) + '+' +
                new string(horizontal, 7);
        }

        private static string buildLine()
        {
            return new string(' ', 7) + "|" + new string(' ', 7) + "|" + new string(' ', 7);
        }

        private static string buildWithPiece(string piece)
        {
            return new string(' ', 2) + piece + new string(' ', 2);
        }
    }
}