namespace Cards
{
    class PlayingCard
    {
        private readonly Suit _suit;
        private readonly Value _value;

        public PlayingCard(Suit s, Value v)
        {
            _suit = s;
            _value = v;
        }

        public override string ToString()
        {
            string result = $"{_value} of {_suit}";
            return result;
        }

        public Suit CardSuit => _suit;

        public Value CardValue => _value;
    }
}