using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MagicMushroomPowerup : BasePowerup
{
    public AudioSource mushroomAudio;
    // setup this object's type
    // instantiate variables
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.MagicMushroom;
        StartCoroutine(Animate());
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    private IEnumerator Animate()
    {
        Vector3 restingPos = transform.localPosition;
        Vector3 animatingPos = restingPos + Vector3.up * 1.0f;

        yield return Move(restingPos, animatingPos);

        SpawnPowerup();
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.3f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
        mushroomAudio.PlayOneShot(mushroomAudio.clip);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && spawned)
        {
            // invoke PowerupCollectedEvent 
            // PowerupManager.instance.powerupCollected.Invoke(this);

            // then destroy powerup (optional)
            Destroy(gameObject);

        }
        else if (col.gameObject.CompareTag("Pipe")) // else if hitting Pipe, flip travel direction
        {
            if (spawned)
            {
                goRight = !goRight;
                rigidBody.AddForce(Vector2.right * 3 * (goRight ? 1 : -1), ForceMode2D.Impulse);

            }
        }
    }

    // interface implementation
    public override void SpawnPowerup()
    {
        spawned = true;
        rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse); // move to the right
    }


    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        PlayerMovement mario;
        bool result = i.TryGetComponent<PlayerMovement>(out mario);

        // if (result) {
        //     mario.MakeSuperMario();
        // }

    }

    public void GameRestart()
    {
        if (spawned == true)
        {
            spawned = false;
            Destroy(gameObject);
        }
        // gameObject.SetActive(true);
    }
}
