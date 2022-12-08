using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private Animator animate;
    private SpriteRenderer renderer;
    public GameObject gun;

    public float extra = 0.2f;
    private float extraX = 0.2f;
    private float extraY = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        transfor = GetComponent<Transform>();
    }

    public int maxHealth = 5;
    private int currentHealth;
    private Transform transfor;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal < 0)
        {
            extraX = -extra;
            renderer.flipX = false;
            animate.Play("walk-horizontal");
        }
        else if (horizontal > 0)
        {
            extraX = extra;
            renderer.flipX = true;
            animate.Play("walk-horizontal");
        }
        else if (vertical < 0)
        {
            extraY = -extra;
            animate.Play("walk-down");
        }
        else if (vertical > 0)
        {
            extraY = extra;
            animate.Play("walk-up");
        }
        else
        {
            extraY = 0f;
            extraX = extra;
            animate.Play("idle_down");
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + 4.0f * horizontal * Time.deltaTime;
        position.y = position.y + 4.0f * vertical * Time.deltaTime;
        rb.MovePosition(position);
    }

    void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
