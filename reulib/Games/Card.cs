using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Games
{
    public class Card
    {
        public enum Suits
        {
            Spades, Clubs, Hearts, Diamonds
        }
        public enum Numbers
        {
            A, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, J, Q, K
        }
        public enum Direction
        {
            Up, Down
        }
        Suits s;
        Numbers n;
        public Direction direction = Direction.Down;
        public Suits Suit
        {
            get { return s; }
        }
        public Numbers Number
        {
            get { return n; }
        }
        public Card(Suits _s, Numbers _n)
        {
            s = _s;
            n = _n;
        }
    }
    public class Deck
    {
        List<Card> _deck = new List<Card>();
        bool _crypto = false;
        public List<Card> deck
        {
            get { return _deck; }
        }
        public Deck()
        {
            ResetDeck();
        }
        public void ResetDeck()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Card.Suits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetNames(typeof(Card.Numbers)).Length; j++)
                {
                    _deck.Add(new Card((Card.Suits)i, (Card.Numbers)j));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shuffled">Whether to start deck shuffled.</param>
        /// <param name="crypto">Whether to use cryptographic RNG</param>
        public Deck(bool shuffled, bool crypto)
        {
            _crypto = crypto;
            ResetDeck();
            if (shuffled)
            {
                Shuffle();
            }
        }
        public void Shuffle()
        {
            if (_crypto)
            {
                _deck.CryptoShuffle();
            }
            else
            {
                _deck.Shuffle();
            }
        }

        public Card Takecard(int card)
        {
            if (card < _deck.Count)
            {
                Card ret = _deck[card];
                _deck.RemoveAt(card);
                return ret;
            }
            return null;
        }

        /// <summary>
        /// Removes the first matching card from the deck.
        /// </summary>
        /// <param name="suit">Suit to match.</param>
        /// <param name="number">Value to match.</param>
        /// <returns></returns>
        public Card Takecard(Card.Suits suit, Card.Numbers number)
        {
            return Takecard(Findcard(suit, number));
        }

        /// <summary>
        /// Finds the location of the first matching card in the deck.
        /// </summary>
        /// <param name="suit">Suit to match.</param>
        /// <param name="number">Value to match.</param>
        /// <returns></returns>
        public int Findcard(Card.Suits suit, Card.Numbers number)
        {
            int card = 0;
            for (int i = 0; i < _deck.Count; i++)
            {
                if (_deck[i].Suit == suit && _deck[i].Number == number)
                {
                    card = i;
                    break;
                }
            }
            return card;
        }

        /// <summary>
        /// Returns card at location in deck.
        /// </summary>
        /// <param name="card">Location to take card from.</param>
        /// <returns></returns>
        public Card Seecard(int card)
        {
            return _deck[card];
        }
    }
}
