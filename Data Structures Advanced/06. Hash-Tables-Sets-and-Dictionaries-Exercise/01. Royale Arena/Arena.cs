namespace RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Arena : IArena
    {
        private Dictionary<int, BattleCard> battlecards;
        public int Count => this.battlecards.Count;

        public Arena()
        {
            this.battlecards = new Dictionary<int, BattleCard>();
        }

        public void Add(BattleCard card)
        {
            if (!this.Contains(card))
            {
                this.battlecards.Add(card.Id, card);
            }
        }

        public void ChangeCardType(int id, CardType type)
        {
            BattleCard card = this.GetById(id);

            if (card == null)
            {
                throw new InvalidOperationException();
            }

            this.battlecards[id].Type = type;
        }

        public bool Contains(BattleCard card) => this.battlecards.ContainsKey(card.Id);

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (this.battlecards.Count < n)
            {
                throw new InvalidOperationException();
            }

            List<BattleCard> cards = new List<BattleCard>(this.battlecards
                .Select(bc => bc.Value)
                .OrderBy(c => c.Swag)
                .Take(n));

            double[] cardsSwags = cards.Select(c => c.Swag).ToArray();

            if (cardsSwags.Length != cardsSwags.Distinct().Count())
            {
                cards = cards
                    .OrderBy(c => c.Id)
                    .ToList();
            }

            return cards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            HashSet<BattleCard> cards = new HashSet<BattleCard>(this.battlecards
                .Select(bc => bc.Value)
                .Where(c => c.Swag >= lo && c.Swag <= hi)
                .OrderBy(c => c.Swag));

            return cards;
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            HashSet<BattleCard> cards = new HashSet<BattleCard>(this.battlecards
                .Where(bc => bc.Value.Type == type)
                .Select(bc => bc.Value));

            if (cards.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(bc => bc.Damage)
                .ThenBy(bc => bc.Id);
        }


        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            HashSet<BattleCard> cards = new HashSet<BattleCard>(this.GetByCardType(type));

            if (cards.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .Where(c => c.Damage <= damage)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);
        }

        public BattleCard GetById(int id)
        {
            BattleCard card = this.battlecards.First(bc => bc.Key == id).Value;

            if (card == null)
            {
                throw new InvalidOperationException();
            }

            return card;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            HashSet<BattleCard> cards = new HashSet<BattleCard>(this.GetByNameOrderedBySwagDescending(name));

            cards = new HashSet<BattleCard>(cards
                .Where(c => c.Swag >= lo && c.Swag <= hi));

            if (cards.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            HashSet<BattleCard> cards = new HashSet<BattleCard>(this.battlecards
                .Select(bc => bc.Value)
                .Where(bc => bc.Name == name));

            if (cards.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            HashSet<BattleCard> cards = new HashSet<BattleCard>(this.GetByCardType(type));

            if (cards.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .Where(c => c.Damage >= lo && c.Damage <= hi)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var kvp in this.battlecards)
            {
                yield return kvp.Value;
            }
        }

        public void RemoveById(int id)
        {
            BattleCard card = this.GetById(id);

            if (card == null)
            {
                throw new InvalidOperationException();
            }

            this.battlecards.Remove(card.Id);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}