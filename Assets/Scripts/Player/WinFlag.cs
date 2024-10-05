using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("WinFlag")){
            Debug.Log("YOU WON");

            //SceneLoad ....
        }
    }
}
