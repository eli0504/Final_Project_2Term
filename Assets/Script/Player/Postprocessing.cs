using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Postprocessing : MonoBehaviour
{
  

    //acceso a la componente volume, vignette
    public Volume volume;
    private Vignette vignette;


    //cuando se cargue el game object se cargan todas las componentes
    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    private void Start()
    {
        volume.profile.TryGet(out vignette); //encontrar y enchufar la vi�eta
    
        vignette.intensity.value = 0.5f;
        vignette.color.value = Color.red;

       
            StartCoroutine(Desactive()); //LLAMAR CORRUTINA
        
     
    }


    public IEnumerator Desactive() //corrutina para cambiar color y desactivar vi�eta
    {
        yield return new WaitForSeconds(2);
        vignette.intensity.value = 1f;
        vignette.color.value = Color.red;

        yield return new WaitForSeconds(2);
        vignette.active = false;
    }
}
