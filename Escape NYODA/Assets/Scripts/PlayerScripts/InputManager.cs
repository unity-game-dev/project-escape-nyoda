using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectNyodaToolkit
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] protected KeyCode croucH;
        [SerializeField] protected KeyCode sprintinG;
        [SerializeField] protected KeyCode jumP;
        // Update is called once per frame
        void Update()
        {
            CrouchHeld();
            SprintingHeld();
            JumpPressed();
        }
        public virtual bool CrouchHeld()
        {
            if (Input.GetKey(croucH))
            {
                return true;
            }
            return false;
        }

        public virtual bool SprintingHeld()
        {
            if (Input.GetKey(sprintinG))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool JumpPressed()
        {
            if (Input.GetKeyDown(jumP))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}

