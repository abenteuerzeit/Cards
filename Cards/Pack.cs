using System;
using System.Collections.Generic;

namespace Cards
{
    class Pack
    {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private Dictionary<Suit, List<PlayingCard>> _cardPack;
        private readonly Random _randomCardSelector = new();

        public Pack()
        {
            _cardPack = new Dictionary<Suit, List<PlayingCard>>(NumSuits);
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                List<PlayingCard> cardsInSuit = new(CardsPerSuit);
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    cardsInSuit.Add(new PlayingCard(suit, value));
                }
                _cardPack.Add(suit, cardsInSuit);
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

            List<PlayingCard> cardsInSuit = _cardPack[suit];
            PlayingCard card = cardsInSuit.Find(c => c.CardValue == value);
            cardsInSuit.Remove(card);
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

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            List<PlayingCard> cardsInSuit = _cardPack[suit];
            return !cardsInSuit.Exists(c => c.CardSuit == suit && c.CardValue == value);
        }
    }
}