using Data;
using Infrastructure.Services;

namespace Collection
{
    public class AttackDeck : Deck
    {
        public int Power
        {
            get
            {
                int amountPower = 0;

                foreach (var card in _cardsInDeck)
                    amountPower += card.Power;

                return amountPower;
            }
        }

        protected override void InitCards(DataSaveLoadService data)
        {
            if (data.PlayerData.AttackDecks == null)
                return;
            
            for (int i = 0; i < data.PlayerData.AttackDecks.Length && i < _cardsInDeck.Count; i++)
                if (data.PlayerData.AttackDecks[i] != null && _cardsInDeck[i] != null)
                    _cardsInDeck[i].Render(data.PlayerData.AttackDecksData[i]);
        }

        protected override void SaveDecks()
        {
            var cards = new CardData[5];

            for (int i = 0; i < 5; i++) 
                cards[i] = _cardsInDeck[i].CardData;

            _data.SetAttackDecks(cards);
        }
    }
}

