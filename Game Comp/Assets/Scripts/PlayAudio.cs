using UnityEngine;

// functions to allow animations to play correct sound
public class PlayAudio : MonoBehaviour{

    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip landing;
    public AudioClip footStep;

   

    public void Idle(){
    }

    public void FoodStep(){
        if (!Input.GetButtonDown("Jump")){
            playClip(footStep, transform.position);
        }
    }

    public void Jump(){
        playClip(jump, transform.position);
    }

    public void Landing(){
        playClip(landing, transform.position);
    }

    public void Hurt(){
        playClip(hurt, transform.position);
    }

    public void Death() {
        playClip(death, transform.position);
    }

    void playClip(AudioClip clip, Vector3 point){
        AudioSource.PlayClipAtPoint(clip, point);
    }
}