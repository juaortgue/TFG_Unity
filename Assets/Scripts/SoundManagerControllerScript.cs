using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerControllerScript : MonoBehaviour
{
   [SerializeField] private AudioClip[] audios;
   private AudioSource controlAudio;

   private void Awake(){
      
        controlAudio = GetComponent<AudioSource>();
   }
   public void selectAudio(int index, float volume){
    controlAudio.PlayOneShot(audios[index], volume);
   }
}
