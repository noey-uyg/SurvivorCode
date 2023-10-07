using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector2 inputVec;
    public Scanner scanner;

    public float hitdamage = 0;
    public VariableJoystick joy;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;


    private void Awake()
    {
        scanner = GetComponent<Scanner>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    private void FixedUpdate() 
    {
        if (!GameManager.instance.isLive)
            return;

        float x = joy.Horizontal;
        float y = joy.Vertical;
        //이동 정규화
        //Vector2 nextVec = inputVec.normalized * (speed + (speed*GameManager.instance.playerData.ChaMoveSpeed)) * Time.fixedDeltaTime;
        inputVec = new Vector3(x, y, 0).normalized * (speed + (speed * GameManager.instance.playerData.ChaMoveSpeed)) * Time.fixedDeltaTime;
        //이동
        rigid.MovePosition(rigid.position + inputVec);

    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }    
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
            return;

        if (collision.gameObject.GetComponent<Enemy>())
        {
            hitdamage = collision.gameObject.GetComponent<Enemy>().damage - GameManager.instance.playerData.Armor;

            if (hitdamage > 0)
                GameManager.instance.playerData.health -= hitdamage;
        }
        else if (collision.gameObject.GetComponent<Boss>())
        {
            hitdamage = collision.gameObject.GetComponent<Boss>().damage - GameManager.instance.playerData.Armor;

            if (hitdamage > 0)
                GameManager.instance.playerData.health -= hitdamage;
        }



        if (GameManager.instance.playerData.health < 0)
        {
            for(int index = 2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }

            anim.SetTrigger("Dead");

            GameManager.instance.GameOver();
        }
    }

}
