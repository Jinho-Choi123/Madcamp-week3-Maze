using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMoveRed : MonoBehaviour
{
    public static string winner = "";
    public Animator animator;

    public float moveSpeed = 1.0f;
    public float maxSpeed = 2.0f;
    public float minSpeed = 0.5f;
    public float tmpMoveSpeed = 1.0f;
    public int isReverse = 0;
    public int isStopped = 0;
    [SerializeField]
    private GameObject basicMove;

    // Start is called before the first frame update
    void Start()
    {
         transform.position = new Vector2(0,0);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //왼쪽 위
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SetAnimator(-1.0f , 0.0f);
            SetVector2(Vector2.left , Vector2.up);
        }
        //왼쪽 아래
        else if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)){
            SetAnimator(-1.0f , 0.0f);
            SetVector2(Vector2.left , Vector2.down);
        }
        //오른쪽 위
        else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SetAnimator( 1.0f , 0.0f);
            SetVector2(Vector2.right , Vector2.up);
        }
        //오른쪽 아래
        else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            SetAnimator( 1.0f , 0.0f);
            SetVector2(Vector2.right , Vector2.down);
        }
        //왼쪽
        else if(Input.GetKey(KeyCode.LeftArrow))
        {   
            SetAnimator(-1.0f , 0.0f);
            SetVector2(Vector2.left , Vector2.zero);
        }
        //오른쪽
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            SetAnimator( 1.0f , 0.0f);
            SetVector2(Vector2.right , Vector2.zero);
        }
        //위
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            SetAnimator( 0.0f , 1.0f);
            SetVector2(Vector2.zero , Vector2.up);
        }
        //아래
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            SetAnimator( 0.0f , -1.0f);
            SetVector2(Vector2.zero , Vector2.down);
        }
    
        //input이 없을때.
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){
            SetAnimator( 0.0f , 0.0f);
        }

        //Reverse
        if (isReverse >= 1)
        {
            if (moveSpeed > 0)
            {
                moveSpeed = -1 * moveSpeed;
            }
        }
        if (isReverse == 0)
        {
            if (moveSpeed < 0)
            {
                moveSpeed = -1 * moveSpeed;
            }
        }

        //freeze 후 moveSpeed = tmpMoveSpeed 로 넘겨주기 위해
        if (moveSpeed != 0)
        {
            tmpMoveSpeed = moveSpeed;
        }

        //freeze
        if (isStopped >= 1)
        {
            moveSpeed = 0;
        }
        if (isStopped == 0)
        {
            moveSpeed = tmpMoveSpeed;
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
    void OnCollisionEnter2D(Collision2D c) { 
        if(c.gameObject.GetComponent<SpriteRenderer>().color == Color.green) {
            winner = "Red Mong Win!!";
            BasicMove.winner = "";
            SceneManager.LoadScene("Success");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //max 2.0f까지만 하도록 조절
        if (collision.gameObject.CompareTag("speed"))
        {
            Destroy(collision.gameObject);
            if (1.1f * moveSpeed <= maxSpeed)
            {
                moveSpeed += moveSpeed * 0.2f;
            }
        }

        //min 0.5f 까지만 하도록 조절
        if (collision.gameObject.CompareTag("debufspeed"))
        {
            Destroy(collision.gameObject);
            if (0.93f * basicMove.GetComponent<BasicMove>().moveSpeed >= minSpeed)
            {
                basicMove.GetComponent<BasicMove>().moveSpeed = basicMove.GetComponent<BasicMove>().moveSpeed * 0.9f;
            }
        }

        //reverse
        if (collision.gameObject.CompareTag("reverse"))
        {
            Destroy(collision.gameObject);
            basicMove.GetComponent<BasicMove>().isReverse++;
            StartCoroutine(CountReverseDelayOther());
        }

        //freeze
        if (collision.gameObject.CompareTag("freeze"))
        {
            Destroy(collision.gameObject);
            basicMove.GetComponent<BasicMove>().isStopped++;
            StartCoroutine(CountStoppedDelayOther());
        }

        //reset
        if (collision.gameObject.CompareTag("reset"))
        {
            Destroy(collision.gameObject);
            basicMove.GetComponent<BasicMove>().Start();
        }

    }

    IEnumerator CountReverseDelayOther()
    {
        yield return new WaitForSeconds(3.0f);
        basicMove.GetComponent<BasicMove>().isReverse--;
    }
    IEnumerator CountStoppedDelayOther()
    {
        yield return new WaitForSeconds(3.0f);
        basicMove.GetComponent<BasicMove>().isStopped--;
    }

}