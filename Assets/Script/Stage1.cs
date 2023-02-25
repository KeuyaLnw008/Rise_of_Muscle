using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{ 
    void Start()
    {
        SoundManager.instance.Play(SoundManager.SoundName.BGM);
    }
    
}
