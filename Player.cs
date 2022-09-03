namespace Gobblets
{
    public class Player
    {
        public Player(string name, bool piece, bool firstMove)
        {
            this.Name = name;
            this.Piece = piece;
            this.FirstMove = firstMove;
        }
        public string Name { get; }
        public bool Piece { get; }
        public bool FirstMove { get; } = false;
        public bool MadeAMove { get; set; }
        public int CurrentPieceSize { get; set; }

        public List<int> smallField = new List<int>();
        public List<int> SmallField { get { return smallField; } set { smallField = value; } }
        public List<int> mediumField = new List<int>();
        public List<int> MediumField { get { return mediumField; } set { mediumField = value; } }
        public List<int> bigField = new List<int>();
        public List<int> BigField { get { return bigField; } set { bigField = value; } }

        public List<int> Fields { get; set; } = new List<int>();
        public static List<int> SmallFieldGlobal { get; set; } = new List<int>();
        public static List<int> MediumFieldGlobal { get; set; } = new List<int>();
        public static List<int> BigFieldGlobal { get; set; } = new List<int>();

        public int smallPieces = 2;
        public int SmallPieces { get { return smallPieces; } set { smallPieces = value; } }
        public int mediumPieces = 2;
        public int MediumPieces { get { return mediumPieces; } set { mediumPieces = value; } }
        public int bigPieces = 2;
        public int BigPieces { get { return bigPieces; } set { bigPieces = value; } }

        public bool Won { get; set; } = false;

        public static int PrevMove { get; set; } = 0;
    }
}