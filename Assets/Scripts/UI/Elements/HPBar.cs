using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Elements
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Image _hpImage;

        public void SetValue(float currentHealth, float maxHealth) => 
            _hpImage.fillAmount = currentHealth / maxHealth;
    }
}
