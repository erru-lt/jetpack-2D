using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StaticData.Projectile
{
    [CreateAssetMenu(fileName = "ProjectileListData", menuName = "Static Data/ProjectileList")]
    public class ProjectileListStaticData : ScriptableObject
    {
        public List<ProjectileStaticData> Projectiles;
    }
}
