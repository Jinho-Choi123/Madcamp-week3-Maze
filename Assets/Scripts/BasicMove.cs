using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
         transform.position = new Vector2(0.43F/2,0.43F/2);
    }
    
    public float moveSpeed = 2.0f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);   
        }
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A))
        {   
            SetAnimatorInStraight();
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            SetAnimatorInStraight();
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            SetAnimatorInStraight();
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);    
        }
        else if(Input.GetKey(KeyCode.S))
        {
            SetAnimatorInStraight();
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) &&!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)){
            ResetAnimator();
        }

    }

      public void SetAnimatorInDiagonal(){
        animator.SetFloat("HorizontalBlue", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("VerticalBlue", 0);
    }

    public void SetAnimatorInStraight(){
        animator.SetFloat("HorizontalBlue", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("VerticalBlue", Input.GetAxisRaw("Vertical"));   
    }

    public void ResetAnimator(){
        animator.SetFloat("HorizontalBlue", 0);
        animator.SetFloat("VerticalBlue", 0);
    }
}