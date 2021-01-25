using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class ArmRotation : MonoBehaviour
{
    public CharacterController2D controller;
    public SpriteRenderer spriteRenderer;
    public Sprite primary;
    public Sprite secondary;
    public Sprite knife;

    public bool isKnife;
    public bool isPrimary;
    public bool isSecondary;

    // Update is called once per frame
    private void Start()
    {
        isPrimary = true;
    }
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if (controller.m_FacingRight)
        {
            whenFacingRight();
        } else
        {
            whenFacingLeft();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spriteRenderer.sprite = primary;
            isPrimary = true;
            isKnife = false;
            isSecondary = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteRenderer.sprite = secondary;
            isSecondary = true;
            isKnife = false;
            isPrimary = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spriteRenderer.sprite = knife;
            isKnife = true;
            isPrimary = false;
            isSecondary = false;
        }
        
    }

    void whenFacingRight()
    {
        if (Input.GetButtonDown("counterClockwise"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 45);
        }
        else if (Input.GetButtonDown("clockwise"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -45);
        }
        else if (Input.GetButtonUp("counterClockwise") || Input.GetButtonUp("clockwise"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        }
    }

    void whenFacingLeft()
    {
        if (Input.GetButtonDown("clockwise"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(-180, 0, 135);
        }
        else if (Input.GetButtonDown("counterClockwise"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(180, 0, -135);
        }
        else if (Input.GetButtonUp("counterClockwise") || Input.GetButtonUp("clockwise"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
        }
    }

}
