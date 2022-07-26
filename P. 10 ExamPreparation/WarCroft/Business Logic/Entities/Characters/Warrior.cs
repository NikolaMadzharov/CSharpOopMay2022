using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Warrior : Character, IAttacker

    {


        public Warrior(string name) : base(name, 100, 50, 40, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            EnsureAlive();

            if (this == character)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);

        }
    }
}