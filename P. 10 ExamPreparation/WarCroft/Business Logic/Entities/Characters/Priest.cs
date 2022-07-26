using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Priest:Character,IHealer
    {
        public Priest(string name) : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (character.IsAlive)
            {
                character.UseItem(new HealthPotion());
                character.UseItem(new HealthPotion());
            }
        }
    }
}