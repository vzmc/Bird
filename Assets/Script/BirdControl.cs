using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdControl : MonoBehaviour
{
    public static bool isGameOver = false;
    public float JumpPower = 5.0f;
    private bool isDead;
    private bool isJump;
    private Rigidbody2D rgbd2d;
    private Animator animator;

    void Start()
    {
        isGameOver = false;
        isDead = false;
        isJump = false;
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
        {            
            //死亡後の更新処理
            if (transform.position.y < -7)
            {
                isGameOver = true;
                Destroy(gameObject);
                PlayerPrefs.SetInt("Score", Score.scorePoint);
                SceneManager.LoadScene("Ending");
            }
            return;
        }

        //入力を受けます
        if(Input.GetMouseButtonDown(0))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        if (isJump)
        {
            //ジャンプ処理
            rgbd2d.velocity = new Vector2(0, JumpPower);
            isJump = false;
        }

        //画面下に落ちると、死亡する
        if (transform.position.y < -5)
        {
            Damege();
            rgbd2d.velocity = new Vector2(0, 5);
        }

        //アニメションの状態を設置
        animator.SetFloat("VerticalSpeed", rgbd2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
        {
            return;
        }

        if(collision.gameObject.tag == "Wall")
        {
            Damege();
            rgbd2d.velocity = new Vector2(0, 5);
        }
        else if(collision.gameObject.tag == "ScoreArea")
        {
            Score.scorePoint++;
        }
    }

    /// <summary>
    /// ダメージの処理
    /// </summary>
    private void Damege()
    {
        isDead = true;
        animator.SetTrigger("IsDead");
    }
}
