using System;
using System.Collections.Generic;

namespace Cards
{
    class Hand
    {
        public const int HandSize = 13;
        private readonly List<PlayingCard> _cards = new(HandSize);

        public void AddCardToHand(PlayingCard cardDealt)
        {
            if (_cards.Count >= HandSize)
            {
                throw new ArgumentException("Too many cards");
            }
            _cards.Add(cardDealt);
        }

        public override string ToString()
        {
            string result = "";
            foreach (PlayingCard card in _cards)
            {
                result += $"{card}{Environment.NewLine}";
            }

            return result;
        }
    }
}