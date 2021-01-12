using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectNyodaToolkit
{
    [CreateAssetMenu(fileName = "WeaponType", menuName = "EscapeNyoda/Weapons", order = 1)]
    public class WeaponTypes : ScriptableObject
    {
        public GameObject projectile;
        public float projectileSpeed;
        public int amountToPool;
        public float lifeTime;
    }
}

