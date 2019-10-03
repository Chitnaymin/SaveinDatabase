using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour {
    void Start() {
        Debug.Log(FunDateTimeAccess.GetCurrentTime(0));
        Debug.Log(FunDateTimeAccess.GetCurrentTime());
        Debug.Log(FunDateTimeAccess.GetCurrentTime(1,3));
        Debug.Log(FunDateTimeAccess.GetCurrentTime(1,1));
    }
}
