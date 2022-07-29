using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
        private List<Character> party;
        private List<Item> pool;

        public WarController()
        {
            pool = new List<Item>();
            party = new List<Character>();
        }

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];
           
            Character character;

            if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
			else if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            party.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
		{
          string itemName =  args[0];
         
          Item item;

          if (itemName== nameof(FirePotion))
          {
              item = new FirePotion();
          }
          else if (itemName == nameof(HealthPotion))
          {
              item = new HealthPotion();
          }
          else 
          {
              throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
          }
            pool.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
		{
			string charackterName =  args[0];
            Character character = party.FirstOrDefault(x => x.Name == charackterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, charackterName));
            }

            if (!pool.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            //changed here
            Item item = pool.Last();
            pool.Remove(item);
            character.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, charackterName, item.GetType().Name);
        }

		public string UseItem(string[] args)
		{
			string characterName = args[0];
            string itemName = args[1];
            Character character = party.FirstOrDefault(x => x.Name == characterName);
            if (character ==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, character.Name, itemName);
        }

		public string GetStats()
		{
			StringBuilder info =  new StringBuilder();
            foreach (var character in party.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
                string alive = character.IsAlive ? "Alive" : "Dead";
                info.AppendLine(
                    $"{ character.Name} - HP: { character.Health}/{ character.BaseHealth}, AP: { character.Armor}/{ character.BaseArmor}, Status: { alive }");
            }
            return info.ToString().TrimEnd();
        }

		public string Attack(string[] args)
		{
            string attackerName = args[0];
            string receiverName = args[1];

            if (!party.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (!party.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (party.First(x => x.Name == attackerName).GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Warrior attacker = (Warrior)party.First(x => x.Name == attackerName);
            Character receiver = party.First(x => x.Name == receiverName);

            attacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

		public string Heal(string[] args)
		{
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!party.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (!party.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (party.First(x => x.Name == healerName).GetType().Name != nameof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest healer = (Priest)party.First(x => x.Name == healerName);
            Character receiver = party.First(x => x.Name == healingReceiverName);

            healer.Heal(receiver);

            return 
                $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
	}
}
