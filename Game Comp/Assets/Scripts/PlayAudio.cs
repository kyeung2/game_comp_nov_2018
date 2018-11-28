using UnityEngine;

[RequireComponent(typeof(AudioSource)), RequireComponent(typeof(PlayerControl))]
public class PlayAudio : MonoBehaviour{

    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip landing;
    public AudioClip footStep;

    AudioSource audioSource;
    PlayerControl playerControl;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        playerControl = GetComponent<PlayerControl>();
    }

    public void Idle(){
    }

    public void FoodStep(){
        if (playerControl.grounded)
        {
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
        audioSource.PlayOneShot(clip);
    }
}