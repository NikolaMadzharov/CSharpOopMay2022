using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag:IBag
    {
        private int capacity=100;
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }
        public int Capacity { get=>capacity;
            set
            {
               
               capacity=value;
            }
        }
        public int Load =>Items.Select(x=>x.Weight).Sum();
        public IReadOnlyCollection<Item> Items => items;
        public void AddItem(Item item)
        {
            if (Load+item.Weight>capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            

            var findItem = items.FirstOrDefault(x => x.GetType().Name == name);
            if (findItem is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));

            }

            items.Remove(findItem);
            return findItem;
        }
}
    }
