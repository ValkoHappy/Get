using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _reached.Invoke();
            var fadeInJob = StartCoroutine(FadeIn());
        }
        else
        {
            _audioSource.Stop();
            if (_audioSource.volume <= 0f)
            {
                _audioSource.Stop();
            }
        }
    }
    private IEnumerator FadeIn()
    {
        var volume = _audioSource.volume;
        var waitForOneSeconds = new WaitForSeconds(1f);

        for (int i = 0; i < 10; i++)
        {
            volume = 1f - (1f / 10f * i);
            _audioSource.volume = Mathf.MoveTowards(volume, i, speed * Time.deltaTime);
            yield return waitForOneSeconds;
        }
    }
}
