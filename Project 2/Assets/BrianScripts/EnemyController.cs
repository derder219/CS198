using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    Transform player;
    public int minDist;
    // PlayerHealth playerHealth;
    // EnemyHealth enemyHealth;
    // UnityEngine.AI.NavMeshAgent nav;
    private Animator animator;
    private float walkStartTime = 0;
    private bool blockState = false;
    public int startingHealth = 2;
    public int currentHealth;
    public GameObject Hitbox;
    public GameObject thisEnemy; //reference to this enemy gameobject
    private bool attack = false;
    private bool isDead = false;

    void Awake ()
    {
        currentHealth = startingHealth;
    }
 
    void Start () {
        animator = this.GetComponent<Animator> ();
    }

	void Update () {
        if (player == null || isDead || blockState) {
            return;
        }
        if (Vector2.Distance(this.transform.position, player.position + new Vector3(0, -0.5f, 0)) >= minDist) {
            animator.ResetTrigger("skill_1");
            animator.ResetTrigger("idle_1");
            Move();
        } else {
            animator.ResetTrigger("run");
            animator.ResetTrigger("walk");
            walkStartTime = 0;
            if (!attack) {
                StartCoroutine("Attack");
            }
        }
	}

	void Move(){
        Vector3 direction = (player.position + new Vector3(0, -0.5f, 0) - this.transform.position).normalized;

		Vector3 localScale = this.transform.localScale;
		Vector3 velocity = Vector3.zero;
		Vector3 newPosition = Vector3.zero;

		if (walkStartTime == 0) {
			walkStartTime = Time.time;
		}
		float speed = 0.05f;
		float dis = 0.1f;
		if (Time.time - walkStartTime > 2.0f) {
			speed = 0.03f;
			animator.SetTrigger("run");
		} else {
			animator.SetTrigger("walk");
		}
		if (direction.x < 0){
			localScale.x = -Math.Abs(localScale.x);
		}else if (direction.x > 0){
			localScale.x = Math.Abs(localScale.x);
		}

        newPosition = this.transform.position + dis * direction;

		this.transform.localScale = localScale;
		this.transform.position = Vector3.SmoothDamp(this.transform.position, newPosition, ref velocity, speed);

		/*if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)|| Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			walkStartTime = 0;
			animator.ResetTrigger ("idle_1");
			animator.ResetTrigger ("walk");
			animator.ResetTrigger ("run");
			animator.SetTrigger("idle_1");
		}*/

		/*if (Input.anyKeyDown){
			foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode))){  
				if (Input.GetKeyDown(keyCode)){  
					if (keyCode == KeyCode.H) {
						animator.SetTrigger("skill_1");
					} else if (keyCode == KeyCode.J) {
						animator.SetTrigger("skill_2");
					} else if (keyCode == KeyCode.K) {
						animator.SetTrigger("skill_3");
					} else if (keyCode == KeyCode.L) {
						animator.SetTrigger("idle_2");
					} else if (keyCode == KeyCode.Space) {
						animator.SetTrigger("evade_1");
						StartCoroutine (Evade ());

					}
				}  
			}  
		}*/

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!isDead && col.gameObject.tag == "PlayerAttackHitbox") {
            --currentHealth;
            if (currentHealth > 0) {
                StartCoroutine("Hit");
            }
            if (currentHealth <= 0) {
                StartCoroutine("Death");
            }
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.transform;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            player = null;
            animator.ResetTrigger("walk");
            animator.ResetTrigger("run");
            animator.SetTrigger("idle_1");
            walkStartTime = 0;
        }
    }

    IEnumerator Attack()
	{
		if (blockState == false) 
		{
			animator.SetTrigger ("skill_1");
            Hitbox.SetActive(true);

			yield return new WaitForSeconds (0.1f);
			attack = true;
			yield return null;
			attack = false;
			yield return new WaitForSeconds (0.4f);
            animator.ResetTrigger("skill_1");
            Hitbox.SetActive(false);
        }
	}

	IEnumerator Hit()
	{
		animator.SetTrigger("hit_1");
		StartCoroutine ("BlockstateTimer", 2.4f);
		yield return null;
	}

	IEnumerator Death()
	{
		animator.SetTrigger ("death");
		blockState = true;
		yield return null;
        yield return new WaitForSeconds(2f);
        Destroy(thisEnemy);
	}

	IEnumerator BlockstateTimer(float timer)
	{
		float bstimer = 0f;
		if (!isDead) 
		{
			for (bstimer = timer; bstimer >= 0f; bstimer -= 0.1f) 
			{
				blockState = true;
				yield return new WaitForSeconds(0.01f);
			}
		}
		if(!isDead)
			blockState = false;
	}
}
