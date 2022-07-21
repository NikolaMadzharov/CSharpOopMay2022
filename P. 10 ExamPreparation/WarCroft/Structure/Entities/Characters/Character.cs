using System;
using System.Data.Common;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private float basehealth;
        private float health;
        private float basearmor;
        private float armor;

        protected Character(string name, float health, float armor, float abilityPoints,Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;

            Health = BaseHealth;
            Armor = BaseArmor;
        }

        public bool IsAlive { get; set; } = true;
		public string Name
        {
            get { return name;}
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name=value;
            }
        }

        public float BaseHealth
        {
            get { return basehealth;}
            private set
            {
                basehealth=value;
            } 
        }

        public float AbilityPoints { get;  set; }

        public float Health
        {
            get { return health;}
             set
            {
                if (value<basehealth&& value>0)
                {
                    health=value;
                }
            }
        }

        
        public float BaseArmor
        {
            get { return basearmor;}
            private set
            {
                basearmor = value;
            }
        }

        public float Armor
        {
            get => armor;
            private set
            {
                if (value>0)
                {
                    armor = value;
                }
            }
        }

        public virtual Bag Bag { get; set; }
        


        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(float hitPoints)
        {
            if (IsAlive!=true)
            {
                return;
            }
            else
            {
                float leftHitPotints = 0;
                if (hitPoints>armor)
                {//   100     120 
                    leftHitPotints = Math.Abs(armor - hitPoints);
                    armor -= hitPoints;
                    
                    health-=leftHitPotints;
                }
            }
        }
        public  void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }



    }
}