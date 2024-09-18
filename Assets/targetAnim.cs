using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetAnim : MonoBehaviour
{
    public int hilthtarget;
  
    public Animation ann;
    public AnimationClip[] annc;
    public bool down,up;
    // Start is called before the first frame update
    void Start()
    {
        hilthtarget = 150;
        down = false;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hilthtarget <= 0&& !down)
        {
            ann.Play(annc[0].name);
            down = true;
        }
        else if (down&&up)
        {
            StartCoroutine(upp());
            up = false;
        }
       
    }

    IEnumerator upp()
    {
        yield return new WaitForSeconds(3f);
        ann.Play(annc[1].name);
        down = false;
        up = true;
        hilthtarget = 150;

    }
}
