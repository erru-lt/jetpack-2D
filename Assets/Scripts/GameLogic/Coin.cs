using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private FX _pickupFx;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<HeroPickup>(out HeroPickup heroPickup))
            {
                heroPickup.Pickup();
                SpawnFx();
                Destroy(gameObject);
            }
        }

        private void SpawnFx() =>
           _pickupFx.SpawnFx(transform.position);
    }
}