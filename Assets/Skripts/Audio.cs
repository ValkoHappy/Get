using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    
    [SerializeField] AudioSource _audioSource;

    private void Start()
    {
        var fadeInJob = StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        var volume = _audioSource.volume;

        for(int i = 0; i < 20; i++)
        {
            volume = 1f - (1f / 20f * i);
            _audioSource.volume = volume;

            yield return new WaitForSeconds(1f);
        }
    }
}
