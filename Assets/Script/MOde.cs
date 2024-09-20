using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MOde : MonoBehaviour
{
    // Start is called before the first frame update
       public void AI(){
    SceneManager.LoadScene("AI");
   }

   public void PLayer() {
    SceneManager.LoadScene("Player");
   }

}
