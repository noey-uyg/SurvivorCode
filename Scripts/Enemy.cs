using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public float knockbackPower;
    public float damage;
    public float spawnTime;

    float hitDamage = 0;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    bool isLive;

    Rigidbody2D rigid;
    Collider2D coll;
    SpriteRenderer spriter;
    Animator anim;
    WaitForFixedUpdate wait;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
        coll = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            return;

        //플레이어 추적
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnEnable()
    {
        //스크립트 활성화 시
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder += 1;
        anim.SetBool("Dead", false);
        health = maxHealth;
    }

    //초기화
    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health + GameManager.instance.playerData.Wave;
        health = data.health + GameManager.instance.playerData.Wave;
        damage = GameManager.instance.playerData.Wave;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //피격처리
        if (!collision.CompareTag("Bullet") || !isLive)
            return;

        hitDamage = (collision.GetComponent<Bullet>().damage + GameManager.instance.playerData.baseDamage) + ((collision.GetComponent<Bullet>().damage + GameManager.instance.playerData.baseDamage) * GameManager.instance.playerData.ChaMonsterDamage);

        health -= hitDamage;

        GameManager.instance.Drain(hitDamage);


        StartCoroutine("KnockBack");

        if (health > 0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            spriter.sortingOrder -= 1;
            anim.SetBool("Dead", true);
            GameManager.instance.GetExp();
            GameManager.instance.GetGold();

            SoundManager.instance.PlaySfx(SoundManager.Sfx.EnemyKill);
        }
    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * knockbackPower, ForceMode2D.Impulse);
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
