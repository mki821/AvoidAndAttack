using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float playerDamage = 1f;
    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector2 dir;
    private Vector3 pos;

    private void Awake()
    {
        this.rigid = this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<Animator>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update() => this.Move();

    private void Move()
    {
        if(Input.GetMouseButton(1))
        {
            this.pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.pos.z = 0.0f;
            this.dir = new Vector2(this.pos.x - this.transform.position.x, this.pos.y - this.transform.position.y).normalized * this.playerSpeed;
            this.anim.SetBool("onRun", true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                this.rigid.velocity = new Vector2(this.dir.x, this.dir.y) * 0.7f;
                this.anim.SetTrigger("onRoll");
                this.StartCoroutine(this.Dash());
            }
        }
        else
        {
            this.dir = new Vector2(0.0f, 0.0f);
            this.anim.SetBool("onRun", false);
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, (Vector3)new Vector2(Mathf.Clamp(this.pos.x, -8.6f, 8.6f), Mathf.Clamp(this.pos.y, -4.7f, 0.5f)), Time.deltaTime * this.playerSpeed);
        this.transform.position = (Vector3)new Vector2(Mathf.Clamp(this.transform.position.x, -8.4f, 8.4f), Mathf.Clamp(this.transform.position.y, -4.5f, 4.5f));
    }

    private IEnumerator Dash()
    {
        yield return (object)new WaitForSeconds(0.3f);
        this.rigid.velocity = Vector2.zero;
    }

    public void RollEnd() => this.anim.SetTrigger("onRollEnd");

    public void Hit() => this.StartCoroutine(this.HitColor());

    private IEnumerator HitColor()
    {
        this.spriteRenderer.color = Color.red;
        yield return (object)new WaitForSeconds(0.05f);
        this.spriteRenderer.color = Color.white;
    }
}
