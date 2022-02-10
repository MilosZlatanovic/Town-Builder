using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FloatingTextComposition : MonoBehaviour
{
    float textDestroySeconds = 1.1f;
    private Vector3 offSet;


    public void ShowDamage(string text, GameObject floatingTextPrefab)
    {
        offSet = new Vector3(0f, 2f, 0);
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position , Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            Destroy(prefab, textDestroySeconds);
        }
    }

}
