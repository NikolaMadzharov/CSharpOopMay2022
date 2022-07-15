using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, 60)
        {
        }

        public override string AllowedGym => "BoxingGym";

        public override void Exercise()
        {
            if (Stamina+15>100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
            Stamina += 15;
        }
    }
}
