using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public GameObject boxx;
    // Start is called before the first frame update
    void Start()
    {
        boxx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            boxx.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            boxx.SetActive(false);
        }
    }
}
