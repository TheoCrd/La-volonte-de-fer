using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject _obj;
    // Update is called once per frame
    public void Disable()
    {
        _obj.SetActive(false);
    }
}
