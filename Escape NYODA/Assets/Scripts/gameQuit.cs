using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameQuit : MonoBehaviour
{
   public void quit() {
       Debug.Log("has quit game");
		Application.Quit();
	}
}
