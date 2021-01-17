using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveRed : MonoBehaviour
{
    public Animator animator;
    public int offset2p = 14;
    public int mazeRows;
    public int mazeColumns;
    int now_position = 0; // right 는 1 left 는 -1 멈춤은 0
    
    // Start is called before the first frame update
    void Start()
    {
         transform.position = new Vector2(0,0);
    }
    
    public float moveSpeed = 1.0f;
    // Update is called once per frame
    void FixedUpdate()
    {
        //왼쪽 위
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            SetAnimator(-1.0f , 0.0f);
            SetVector2(Vector2.left , Vector2.up);
        }
        //왼쪽 아래
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
            SetAnimator(-1.0f , 0.0f);
            SetVector2(Vector2.left , Vector2.down);
        }
        //오른쪽 위
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            SetAnimator( 1.0f , 0.0f);
            SetVector2(Vector2.right , Vector2.up);
        }
        //오른쪽 아래
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            SetAnimator( 1.0f , 0.0f);
            SetVector2(Vector2.right , Vector2.down);
        }
        //왼쪽
        else if(Input.GetKey(KeyCode.A))
        {   
            SetAnimator(-1.0f , 0.0f);
            SetVector2(Vector2.left , Vector2.zero);
        }
        //오른쪽
        else if(Input.GetKey(KeyCode.D))
        {
            SetAnimator( 1.0f , 0.0f);
            SetVector2(Vector2.right , Vector2.zero);
        }
        //위
        else if(Input.GetKey(KeyCode.W))
        {
            SetAnimator( 0.0f , 1.0f);
            SetVector2(Vector2.zero , Vector2.up);
        }
        //아래
        else if(Input.GetKey(KeyCode.S))
        {
            SetAnimator( 0.0f , -1.0f);
            SetVector2(Vector2.zero , Vector2.down);
        }
        
        //input이 없을때.
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) &&!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)){
            SetAnimator( 0.0f , 0.0f);
        }
        
    }

    //animation 조정.
    //보여주고 싶은 animation 방향대로 값을 1,0,-1로 입력해주면 됨.
    //ex, 오른쪽으로 간다 -> set_x는 1, set_y 는 0
    //ex, animator를 멈추고 싶다 -> set_x는 0 || set_y는 0
    public void SetAnimator(float set_x , float set_y){
        animator.SetFloat("HorizontalRed", set_x);
        animator.SetFloat("VerticalRed", set_y);
    }

    //캐릭터의 위치를 옮기는 것.
    //x는 좌또는 우로 움직이는 것.
    //y는 상또는 하로 움직이는것.
    //ex, 오른쪽으로 가면 -> vector_x에는 vector2.right를, vector_y에는 vector2.zero를.
    public void SetVector2(Vector2 vector_x , Vector2 vector_y){
        transform.Translate(vector_x * moveSpeed * Time.deltaTime);
        transform.Translate(vector_y * moveSpeed * Time.deltaTime);
    }
}