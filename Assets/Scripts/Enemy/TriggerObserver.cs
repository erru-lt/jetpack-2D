using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action TriggerEnter;
        public event Action TriggerExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsHero(collision))
            {
                TriggerEnter?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsHero(collision))
            {
                TriggerExit?.Invoke();
            }
        }

        private bool IsHero(Collider2D collider)
        {
            HeroMove hero = collider.gameObject.GetComponent<HeroMove>();

            if (hero != null) return true;

            return false;
        }
    }
}
