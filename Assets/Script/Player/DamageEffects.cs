using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;


public class DamageEffects : MonoBehaviour
{
    public float intensity = 0f;
    PostProcessVolume volume;
    Vignette vignette;

    private void Update()
    {
        StartCoroutine(TakeDamageEffect());
    }

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings<Vignette>(out vignette);

        if (!vignette)
        {
            print("error, vignette empty");
        }
        else
        {
            vignette.enabled.Override(false);
        }
    }

    public IEnumerator TakeDamageEffect()
    {
        intensity = 0.5f;

        vignette.enabled.Override(true);
        vignette.intensity.Override(intensity);

        yield return new WaitForSeconds(intensity);

        while (intensity > 0)
        {
            intensity -= 0.01f; //reduce slowly the intensity
            if (intensity < 0) intensity = 0; //block negative numbers
            vignette.intensity.Override(intensity);
            yield return new WaitForSeconds(0.1f); //smooth
        }

        vignette.enabled.Override(false);
        yield break;
    }

}
