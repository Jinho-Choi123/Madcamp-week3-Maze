using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveRed : MonoBehaviour
{
    public Animator animator;
    public int offset2p = 14;
    public float moveSpeed = 2.0f;
    public int mazeRows;
    public int mazeColumns;
    int now_position = 0; // right 는 1 left 는 -1 멈춤은 0
    
    // Start is called before the first frame update
    void Start()
    {   
        transform.position = new Vector2(0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        Move();
    }
    
    public void Move(){
        
        

        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);   
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            SetAnimatorInDiagonal();
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {   
            SetAnimatorInStraight();
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            
            SetAnimatorInStraight();
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            
            SetAnimatorInStraight();
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);    
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            
            SetAnimatorInStraight();
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){
            ResetAnimator();
        }
       
    }

    public void SetAnimatorInDiagonal(){
        animator.SetFloat("HorizontalRed", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("VerticalRed", 0);
    }

    public void SetAnimatorInStraight(){
        animator.SetFloat("HorizontalRed", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("VerticalRed", Input.GetAxisRaw("Vertical"));   
    }

    public void ResetAnimator(){
        animator.SetFloat("HorizontalRed", 0);
        animator.SetFloat("VerticalRed", 0);
    }
    
}
