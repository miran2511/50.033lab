using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float originalX;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    public Vector3 startPosition = new Vector3(0.0f, 0.0f, 0.0f);
    [System.NonSerialized]
    public bool alive = true;
    public AudioSource goombaDeath;
    public Animator goombaAnimator;
    public GameConstants gameConstants;
    float maxOffset;
    float enemyPatroltime;

    void Start()
    {
        // set constant
        maxOffset = gameConstants.goombaMaxOffset;
        enemyPatroltime = gameConstants.goombaPatrolTime;
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    void ComputeVelocity()
    {
        velocity = new Vector2(moveRight * maxOffset / enemyPatroltime, 0);
    }
    void Movegoomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {// move goomba
            Movegoomba();
        }
        else
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            Movegoomba();
        }
    }
    public Sprite originalSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.DotTest(transform, Vector2.down))
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<EnemyMovement>().enabled = false;
                // play death animation
                goombaAnimator.Play("goomba-die");
                // play dying sound haha
                goombaDeath.PlayOneShot(goombaDeath.clip);
                alive = false;
            }
        }
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }

    public void GameRestart()
    {
        if (!alive)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<EnemyMovement>().enabled = true;
            gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = originalSprite;
            alive = true;
        }
        transform.localPosition = startPosition;
        originalX = transform.position.x;
        moveRight = -1;
        ComputeVelocity();
    }

}
