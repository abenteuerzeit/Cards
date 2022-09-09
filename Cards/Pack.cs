using System;

namespace Cards
{
    class Pack
    {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private readonly PlayingCard[,] _cardPack;
        private readonly Random _randomCardSelector = new();

        public Pack()
        {
            _cardPack = new PlayingCard[NumSuits, CardsPerSuit];
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    _cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }
        }

        public PlayingCard DealCardFromPack()
        {
            Suit suit = (Suit)_randomCardSelector.Next(NumSuits);
            while (IsSuitEmpty(suit))
            {
                suit = (Suit)_randomCardSelector.Next(NumSuits);
            }

            Value value = (Value)_randomCardSelector.Next(CardsPerSuit);
            while (IsCardAlreadyDealt(suit, value))
            {
                value = (Value)_randomCardSelector.Next(CardsPerSuit);
            }

            PlayingCard card = _cardPack[(int)suit, (int)value];
            _cardPack[(int)suit, (int)value] = null;
            return card;
        }

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;
            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value) => (_cardPack[(int)suit, (int)value] == null);
    }
}