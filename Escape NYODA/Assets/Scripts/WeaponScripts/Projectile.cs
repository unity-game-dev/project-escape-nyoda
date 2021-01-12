using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectNyodaToolkit
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected WeaponTypes weapon;

        public bool fired;
        public bool left;
        public float projectileLifetime;

        private bool flipped;

        protected virtual void OnEnable()
        {
            projectileLifetime = weapon.lifeTime;
        }
        protected virtual void FixedUpdate()
        {
            Movement();
        }

        protected virtual void Movement()
        {
            if (fired)
            {
                projectileLifetime -= Time.deltaTime;
                if (projectileLifetime > 0)
                {
                    if (!left)
                    {
                        if (flipped)
                        {
                            flipped = false;
                            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                        }
                        transform.Translate(Vector2.right * weapon.projectileSpeed * Time.deltaTime);
                    } else
                    {
                        if (!flipped)
                        {
                            flipped = true;
                            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
                        }
                        transform.Translate(Vector2.left * weapon.projectileSpeed * Time.deltaTime);
                    }
                } else
                {
                    DestroyProjectile();
                }
            }
        }
        protected virtual void DestroyProjectile()
        {
            projectileLifetime = weapon.lifeTime;
            gameObject.SetActive(false);
        }
        
    }
}

