using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConroller : MonoBehaviour
{
 


    public GameObject leftLeg;
    public GameObject rightLeg;
    Rigidbody2D leftLegRB;
    Rigidbody2D rightLegRB;
    public Rigidbody2D rb;
    public Animator anim;
    
    [SerializeField] float speed = 1.5f;
    [SerializeField] float stepWait = .5f;
    [SerializeField] float jumpForce = 10;

    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerPos;

    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {




        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("walk");
                StartCoroutine(MoveRight(stepWait));
            }
            else
            {
                anim.Play("WalkBack");
                StartCoroutine(MoveLeft(stepWait));
            }

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

            anim.Play("Idle");
        }


        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {


            rb.AddForce(Vector2.up * jumpForce);
        }


        IEnumerator MoveRight(float seconds)
        {
            leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
            yield return new WaitForSeconds(seconds);
            rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        }

        IEnumerator MoveLeft(float seconds)
        {
            rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
            yield return new WaitForSeconds(seconds);
            leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        }






    }


}
