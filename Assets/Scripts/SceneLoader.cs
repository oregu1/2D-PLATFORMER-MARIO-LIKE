using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SceneLoader : MonoBehaviour
{
    public AssetReference Scene;
    public string SceneName;

    private void Start()
    {
        Addressables.LoadSceneAsync(Scene, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed += SceneLoadComplete;
    }

    private void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
    {
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log(obj.Result.Scene.name + "successfully loaded");
        }
    }
}
