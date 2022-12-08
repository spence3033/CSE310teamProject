using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float moveSpeed = 10f;

    public float bulletTime = 10f;
    private float currentTime = 0.0f;
	//private Transform _trans;
    private SpriteRenderer _renderer;
	public Sprite muzzleFlash;

	private Rigidbody2D rb;
	private float horizontal;
	private float vertical;
    private bool collided = false;
	private bool right = false;
	private bool left = false;
	private bool up = false;
	private bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(MuzzleFlash());
        //_trans = GetComponent<Transform>();
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		if (horizontal > 0){
            right = true;
		}
		else if (horizontal < 0){
			left = true;
		}
		else if (vertical > 0){
			up = true;
		}
		else if (vertical < 0){
			down = true;
		}
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if (currentTime <= bulletTime)
        {
			if (right){
                position.x = position.x + moveSpeed * Time.deltaTime;
			}
			else if (left){
				position.x = position.x - moveSpeed * Time.deltaTime;
			}
			else if (up){
				position.y = position.y + moveSpeed * Time.deltaTime;
			}
			else if (down){
				position.y = position.y - moveSpeed * Time.deltaTime;
			}
			else{
				position.x = position.x + moveSpeed * Time.deltaTime;
			}
        }
        else
        {
            _renderer.enabled = false;
            Destroy(gameObject);
        }
        transform.position = position;
        currentTime += Time.deltaTime;
    }

	IEnumerator MuzzleFlash()
    {
        var originalSprite = _renderer.sprite;
        _renderer.sprite = muzzleFlash;

		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		if (horizontal > 0){
            _renderer.flipX = true;
		}
		else if (horizontal < 0){
			_renderer.flipX = false;
		}
		else if (vertical > 0){
			RotateUp();
		}
		else if (vertical < 0){
			RotateDown();
		}

        var framesFlashed = 0;
        while (framesFlashed < 20)
        {
            framesFlashed += 1;
            yield return null;
        }

        _renderer.sprite = originalSprite;
    }

	void RotateUp()
	{
		transform.Rotate (Vector3.forward * -90);
	}
	
	void RotateDown()
	{
		transform.Rotate (Vector3.forward * 90);
	}
	
	/*
	void OnCollisionEnter2D()
	{
		Destroy(gameObject);
	}

	
    void OnTriggerEnter2D(Collider2D other)
    {
        _renderer.enabled = false;
		Destroy(gameObject);
    }
	*/
}
