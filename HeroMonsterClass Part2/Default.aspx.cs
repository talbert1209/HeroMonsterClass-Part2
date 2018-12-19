using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClasses_Part2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dice die = new Dice(){Sides = 2};

            Character hero = new Character(){AttackBonus = false, DamageMaximum = 15, Health = 100, Name = "Tim"};
            Character monster = new Character() {AttackBonus = false, DamageMaximum = 14, Health = 100, Name = "Phoebe"};

            // Decide which character has the attack bonus and attack
            if (die.Roll() == 0)
            {
                hero.AttackBonus = true;
                monster.Defend(hero.Attack(die));
            }
            else
            {
                monster.AttackBonus = true;
                hero.Defend(monster.Attack(die));
            }

            // Battle loop
            bool winner = false;
            while (!winner)
            {
                monster.Defend(hero.Attack(die));
                hero.Defend(monster.Attack(die));

                DisplayResults(hero, monster);

                if (hero.Health <= 0 || monster.Health <= 0)
                {
                    winner = true;
                    if (hero.Health > monster.Health)
                        Label1.Text += $"{hero.Name} is the winner!";
                    else
                        Label1.Text += $"{monster.Name} is the winner!";
                }
            }
        }

        public void DisplayResults(Character opponent1, Character opponent2)
        {
            DisplayStats(opponent1);
            DisplayStats(opponent2);
        }
        public void UseBonusAttack(Character character, Dice die)
        {
            if (character.AttackBonus)
            {
                character.Attack(die);
            }
        }

        public void DisplayStats(Character character)
        {
            Label1.Text += $"<p>Name: {character.Name}, " +
                           $"Attack Bonus: {character.AttackBonus}, " +
                           $"DamageMaximum: {character.DamageMaximum}, " +
                           $"Health: {character.Health}<p/>";
        }
        public class Character
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public bool AttackBonus { get; set; }

            public int Attack(Dice die)
            {
                die.Sides = DamageMaximum;
                return die.Roll();
            }

            public void Defend(int damage)
            {
                Health -= damage;
            }
        }

        public class Dice
        {
            public int Sides { get; set; }
            readonly Random random = new Random();

            public int Roll()
            {
                return random.Next(Sides);
            }
        }
    }
}