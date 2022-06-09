using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldirController2 : MonoBehaviour
{
    
    public CharacterController characterController;
    public Animator animator;

    void Start()
    {
        this.characterController.GetComponent<CharacterController>();
        this.animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Animations()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        this.animator.SetFloat("Vertical", vertical);
        this.animator.SetFloat("Horizontal", horizontal);
    }


    
}
