using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public static class Loader
{
    // Variable que guarda una funci�n sin inputs ni output
    private static Action loaderCallbackAction;

    // Lista de nuestras escenas
    public enum Scene
    {
        Level1,
        Loader,
        MainMenu
    }

    private static Scene sceneAux;

    public static void Load(Scene scene)
    {
        // Asignas en loaderCallbackAction una funci�n que no recibe par�metros
        loaderCallbackAction = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };


        // Llamamos a la escena de carga
        SceneManager.LoadScene(Scene.Loader.ToString());
    }

    public static void LoaderCallback()
    {
        if (loaderCallbackAction != null)
        {
            loaderCallbackAction();
            loaderCallbackAction = null;
        }
    }
}
