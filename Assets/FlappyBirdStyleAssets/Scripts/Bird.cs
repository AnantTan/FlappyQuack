using UnityEngine;

public class Bird : MonoBehaviour
{

	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rbd;
    private Animator anim;

	// Use this for initialization
	void Start ()
	{
		rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		rbd.isKinematic = false;

	}

	// Update is called once per frame
	void Update ()
	{
		if (isDead == false) {
			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Space)) {
				rbd.velocity = Vector2.zero;
				rbd.AddForce (new Vector2 (0, upForce));
                anim.SetTrigger("Flap");
			}
		}

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.transform.CompareTag("Column")) 
		{
			rbd.velocity = Vector2.zero;
			isDead = true;
			anim.SetTrigger("Die");
			GameControl.instance.BirdDied(); 
			print ("garbar");
		}
		if (collision.transform.CompareTag("Nest"))
		{
			rbd.velocity = Vector2.zero;
			isDead = true;
			//anim.SetTrigger("Win");
			GameControl.instance.GameWin();
			rbd.isKinematic = true;
			print ("garbar1");
		}
    }

}

