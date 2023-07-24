    string[] cardArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

    Console.OutputEncoding = System.Text.Encoding.UTF8;

    List<Card> cards = new List<Card>();
    foreach (string pair in cardArgs)
    {
        try
        {
            string[] card = pair.Split(" ");
            cards.Add(new Card(card[0], card[1]));
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    Console.WriteLine(string.Join(" ", cards));

    class Card
    {
        private string face;
        private string suit;
        private List<string> faces = new List<string>()
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };

        private Dictionary<string, string> suits = new Dictionary<string, string>()
        {
            { "S", "\u2660" },
            { "H", "\u2665" },
            { "D", "\u2666" },
            { "C", "\u2663" },
        };

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get => this.face;
            private set
            {
                if (!this.faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            }
        }

        public string Suit
        {
            get => this.suit;
            private set
            {
                if (!this.suits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.suit = suits[value];
            }
        }

        public override string ToString()
            => $"[{this.Face}{this.Suit}]";
    }