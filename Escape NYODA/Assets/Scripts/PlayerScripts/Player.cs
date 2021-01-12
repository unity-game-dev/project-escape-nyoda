using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace projectNyodaToolkit
{
    public class Player : MonoBehaviour
    {
        [HideInInspector]
        public bool isFacingLeft;
        [HideInInspector]
        public bool isGrounded;
        [HideInInspector]
        public bool isCrouching;
        protected Collider2D coll;
        protected Rigidbody2D rb;
        private Vector2 facingLeft;

        protected InputManager input;
        protected ObjectPooler objectPooler;

        //animator
        protected Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            Initialization();
        }

        protected virtual void Initialization()
        {
            coll = GetComponent<Collider2D>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            //Store localscale values when sprite facing left
            facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
            input = GetComponent<InputManager>();
            objectPooler = ObjectPooler.Instance;
        }

        //method to flip sprites
        protected virtual void Flip()
        {
            if (isFacingLeft)
            {
                transform.localScale = facingLeft;
            } else
            {
                //flips the sprite if not facing left
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }

        protected virtual bool CollisionCheck(Vector2 direction, float distance, LayerMask collision)
        {
            //detecting platforms through raycasting
            RaycastHit2D[] hits = new RaycastHit2D[10];
            int numHits = coll.Cast(direction, hits, distance);
            for(int i = 0; i<numHits; i++)
            {
                if((1 << hits[i].collider.gameObject.layer & collision) != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

