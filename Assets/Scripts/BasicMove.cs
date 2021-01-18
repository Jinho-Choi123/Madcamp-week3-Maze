using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMove : MonoBehaviour
{

    public static string winner = "";
    public Animator animator;
    public float moveSpeed = 1.0f;
    public float maxSpeed = 2.0f;
    public float minSpeed = 0.5f;
    public float tmpMoveSpeed;
    public int isReverse = 0;
    public bool isStopped = true;
    public bool isDead = false;
    [SerializeField]
    private GameObject basicMoveRed;

    // Start is called before the first frame update
    public void Start()
    {
        if (Setting.inSameMap) {
            transform.position = new Vector2(0.43F / 2, 0.43F / 2);
        }
        else {
            transform.position = new Vector2(30, 30);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isDead){
            //왼쪽 위
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                SetAnimator(-1.0f, 0.0f);
                SetVector2(Vector2.left, Vector2.up);
            }
            //왼쪽 아래
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
                SetAnimator(-1.0f, 0.0f);
                SetVector2(Vector2.left, Vector2.down);
            }
            //오른쪽 위
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                SetAnimator(1.0f, 0.0f);
                SetVector2(Vector2.right, Vector2.up);
            }
            //오른쪽 아래
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                SetAnimator(1.0f, 0.0f);
                SetVector2(Vector2.right, Vector2.down);
            }
            //왼쪽
            else if (Input.GetKey(KeyCode.A))
            {
                SetAnimator(-1.0f, 0.0f);
                SetVector2(Vector2.left, Vector2.zero);
            }
            //오른쪽
            else if (Input.GetKey(KeyCode.D))
            {
                SetAnimator(1.0f, 0.0f);
                SetVector2(Vector2.right, Vector2.zero);
            }
            //위
            else if (Input.GetKey(KeyCode.W))
            {
                SetAnimator(0.0f, 1.0f);
                SetVector2(Vector2.zero, Vector2.up);
            }
            //아래
            else if (Input.GetKey(KeyCode.S))
            {
                SetAnimator(0.0f, -1.0f);
                SetVector2(Vector2.zero, Vector2.down);
            }

            //input이 없을때.
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
                SetAnimator(0.0f, 0.0f);
            }
        }
        

        //Reverse
        if (isReverse == 1)
        {
            isReverse = 0;
            Debug.Log("Blue Reversed");
            moveSpeed = -1 * moveSpeed;
            StartCoroutine(CountReverseDelay());
        }

        //freeze
        if (!isStopped)
        {
            isStopped = true;
            tmpMoveSpeed = moveSpeed;
            StartCoroutine(CountStoppedDelay());
        }

    }

    //animation 조정.
    //보여주고 싶은 animation 방향대로 값을 1,0,-1로 입력해주면 됨.
    //ex, 오른쪽으로 간다 -> set_x는 1, set_y 는 0
    //ex, animator를 멈추고 싶다 -> set_x는 0 || set_y는 0
    public void SetAnimator(float set_x, float set_y) {
        animator.SetFloat("HorizontalBlue", set_x);
        animator.SetFloat("VerticalBlue", set_y);
    }

    //캐릭터의 위치를 옮기는 것.
    //x는 좌또는 우로 움직이는 것.
    //y는 상또는 하로 움직이는것.
    //ex, 오른쪽으로 가면 -> vector_x에는 vector2.right를, vector_y에는 vector2.zero를.
    public void SetVector2(Vector2 vector_x, Vector2 vector_y) {
        transform.Translate(vector_x * moveSpeed * Time.deltaTime);
        transform.Translate(vector_y * moveSpeed * Time.deltaTime);
    }

    public void ShowDeadAnimation(){
        animator.SetFloat("HorizontalBlue", 0);
        animator.SetFloat("VerticalBlue", 0);
        animator.SetFloat("BlueDie", 1);
    }
    public void OffDeadAnimation(){
        animator.SetFloat("BlueDie", 0);
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.GetComponent<SpriteRenderer>().color == Color.green) {
            winner = "Blue Mong Win!!";
            BasicMoveRed.winner = "";
            SceneManager.LoadScene("Success");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //max 2.0f까지만 하도록 조절
        if (collision.gameObject.CompareTag("speed"))
        {
            Debug.Log("item_fast 활성화");
            Destroy(collision.gameObject);
            if (1.1f * moveSpeed <= maxSpeed)
            {
                moveSpeed += moveSpeed * 0.2f;
            }
            Debug.Log("Blue moveSpeed : " + moveSpeed.ToString());
        }

        //min 0.5f 까지만 하도록 조절
        if (collision.gameObject.CompareTag("debufspeed"))
        {
            Debug.Log("item_slow 활성화");
            Destroy(collision.gameObject);
            if (0.93f * basicMoveRed.GetComponent<BasicMoveRed>().moveSpeed >= minSpeed)
            {
                basicMoveRed.GetComponent<BasicMoveRed>().moveSpeed = basicMoveRed.GetComponent<BasicMoveRed>().moveSpeed * 0.9f;
            }
            Debug.Log("Red moveSpeed : " + basicMoveRed.GetComponent<BasicMoveRed>().moveSpeed.ToString());
        }

        //Reverse
        if (collision.gameObject.CompareTag("reverse"))
        {
            Debug.Log("item_Reverse 활성화");
            Destroy(collision.gameObject);
            basicMoveRed.GetComponent<BasicMoveRed>().isReverse = false;
        }

        //freeze
        if (collision.gameObject.CompareTag("freeze"))
        {
            Debug.Log("freeze 활성화");
            Destroy(collision.gameObject);
            basicMoveRed.GetComponent<BasicMoveRed>().isStopped = false;
        }

        //reset
        if (collision.gameObject.CompareTag("reset"))
        {
            Debug.Log("item_reset 활성화");
            Destroy(collision.gameObject);
            StartCoroutine(ResetDelay());
            Debug.Log("Red moved to set.");
        }

    }
    IEnumerator CountStoppedDelay()
    {
        moveSpeed = 0;
        yield return new WaitForSeconds(3.0f);
        moveSpeed = tmpMoveSpeed;
    }

    IEnumerator CountReverseDelay()
    {
        yield return new WaitForSeconds(3.0f);
        moveSpeed = -1 * moveSpeed;
    }

    IEnumerator ResetDelay()
    {
        basicMoveRed.GetComponent<BasicMoveRed>().isDead = true;
        basicMoveRed.GetComponent<BasicMoveRed>().ShowDeadAnimation();
        yield return new WaitForSeconds(1.04f);
        basicMoveRed.GetComponent<BasicMoveRed>().OffDeadAnimation();
        basicMoveRed.GetComponent<BasicMoveRed>().transform.position = new Vector2(0, 0);
        basicMoveRed.GetComponent<BasicMoveRed>().isDead = false;
    }


}