using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAI : MonoBehaviour
{

    public enemy enCon;
    public int stopForSec;

    void Start()
    {
        enCon = gameObject.GetComponent <enemy> ();
    }

}
