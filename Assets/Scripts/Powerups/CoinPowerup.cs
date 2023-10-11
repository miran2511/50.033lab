using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : MonoBehaviour
{
    public AudioSource coinAudio;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animate());
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    private IEnumerator Animate()
    {
        Vector3 restingPos = transform.localPosition;
        Vector3 animatingPos = restingPos + Vector3.up * 2f;

        yield return Move(restingPos, animatingPos);
        yield return Move(animatingPos, restingPos);

        gameObject.SetActive(false);
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.25f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
        coinAudio.PlayOneShot(coinAudio.clip);
    }

    public void GameRestart()
    {
        gameObject.SetActive(true);
    }
}
