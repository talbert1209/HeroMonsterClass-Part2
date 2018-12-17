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
            Character hero = new Character(){AttackBonus = true, DamageMaximum = 15, Health = 100, Name = "Tim"};
            Character monster = new Character() {AttackBonus = false, DamageMaximum = 17, Health = 100, Name = "Phoebe"};

            monster.Defend(hero.Attack());
            hero.Defend(monster.Attack());

            DisplayStats(hero);
            DisplayStats(monster);
        }

        public void DisplayStats(Character character)
        {
            Label1.Text += $"<br/>Name: {character.Name}, " +
                           $"Attack Bonus: {character.AttackBonus}, " +
                           $"DamageMaximum: {character.DamageMaximum}, " +
                           $"Health: {character.Health}";
        }
        public class Character
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public bool AttackBonus { get; set; }

            public int Attack()
            {
                Random random = new Random();
                return random.Next(0,DamageMaximum + 1);
            }

            public void Defend(int damage)
            {
                Health -= damage;
            }
        }
    }
}