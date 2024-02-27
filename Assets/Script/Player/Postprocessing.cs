using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Postprocessing : MonoBehaviour
{
    private Volume volume;
    private Vignette vignette;

    private void Awake()
    {
        volume = GetComponent<Volume>();
       
    }

    private void Start()
    {
        vignette.active = false;
        volume.profile.TryGet(out vignette); //encontrar y enchufar la vi�eta
        //modificar la vi�eta
        vignette.intensity.value = 0.5f;
        vignette.color.value = Color.red;

        StartCoroutine(Desactive()); //LLAMAR CORRUTINA
    }

    private IEnumerator Desactive() //corrutina para cambiar color y desactivar vi�eta
    {
        yield return new WaitForSeconds(3);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;

        yield return new WaitForSeconds(2);
        vignette.active = false;
    }
}
