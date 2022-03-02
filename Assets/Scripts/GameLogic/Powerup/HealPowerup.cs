using Assets.Scripts.Hero;

namespace Assets.Scripts.GameLogic.Powerup
{
    public class HealPowerup : Powerup
    {
        public override void DoPowerup(HeroPowerup hero) => 
            hero.AddHealth();
    }
}
