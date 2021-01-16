using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(30, 30 );
    }
    
    public float moveSpeed = 2.0f;
    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", 0);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);   
        }
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", 0);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", 0);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", 0);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A))
        {   
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);    
        }
        else if(Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));   
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) &&!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)){
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }

    }
}
