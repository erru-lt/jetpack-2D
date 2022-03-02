using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.GameLogic.Powerup
{
    public abstract class Powerup : MonoBehaviour
    {
        public abstract void DoPowerup(HeroPowerup hero);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            HeroPowerup hero = collision.gameObject.GetComponent<HeroPowerup>();
            
            if(hero != null)
            {
                DoPowerup(hero);
                Destroy(gameObject);
            }
        }
    }
}
