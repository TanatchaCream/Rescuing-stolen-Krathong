using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    private Animator doorAnimator;
    private bool closeStatus = false;
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void control2()
    {
        closeStatus = !closeStatus;
        doorAnimator.SetBool("isClosed", closeStatus);
    }

}
