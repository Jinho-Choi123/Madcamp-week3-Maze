using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveRed : MonoBehaviour
{
    public Animator animator;
    public int offset2p = 14;
    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        void Start()
    {   
        transform.position = new Vector2(0, 0 );

    }
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
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", 0);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);   
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)){
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", 0);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", 0);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", 0);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {   
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", Input.GetAxis("Vertical"));
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", Input.GetAxis("Vertical"));
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", Input.GetAxis("Vertical"));
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);    
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("HorizontalRed", Input.GetAxis("Horizontal"));
            animator.SetFloat("VerticalRed", Input.GetAxis("Vertical"));   
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){
            animator.SetFloat("HorizontalRed", 0);
            animator.SetFloat("VerticalRed", 0);
        }
       
    }
}
