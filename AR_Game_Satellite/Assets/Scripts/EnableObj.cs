using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisableObj()
    {
        gameObject.SetActive(false);
    }
}
