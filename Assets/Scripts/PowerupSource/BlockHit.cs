using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    //infinite hits if negative
    public int maxHits;
    public Sprite emptyBlock;
    public Sprite originalQuestion;
    public GameObject item;
    private bool animating;
    public Animator blockAnimator;
    public bool question;
    public int itemNo = 1;

    void Start()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (maxHits == 1)
        {
            StartCoroutine(Animate());
        }
        maxHits--;

        //spawn item
        if (item != null && itemNo == 1)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            itemNo--;
            GameManager.instance.IncreaseScore(1);
        }

        if (maxHits == 0)
        {
            spriteRenderer.sprite = emptyBlock;
            blockAnimator.gameObject.GetComponent<Animator>().enabled = false;
        }
        else if (question != true && maxHits < 0)
        {
            StartCoroutine(Animate());
        }
    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPos = transform.localPosition;
        Vector3 animatingPos = restingPos + Vector3.up * 0.5f;

        yield return Move(restingPos, animatingPos);
        yield return Move(animatingPos, restingPos);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }

    public void GameRestart()
    {
        if (item != null)
        {
            itemNo = 1;
        }
        if (blockAnimator != null)
        {
            blockAnimator.gameObject.GetComponent<Animator>().enabled = true;
            blockAnimator.Play("Question-Blinking");
        }
        if (question == true)
        {
            maxHits = 1;
        }
    }
}
