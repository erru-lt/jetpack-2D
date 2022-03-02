using Assets.Scripts.Hero;

namespace Assets.Scripts.GameLogic.Powerup
{
    public class SpeedPowerup : Powerup
    {
        public override void DoPowerup(HeroPowerup hero) => 
            hero.SpeedPowerup();
    }
}
