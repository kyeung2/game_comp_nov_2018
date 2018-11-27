using UnityEngine;

// functions to allow animations to play correct sound
public class PlayAudio : MonoBehaviour{

    public AudioClip jump;
    public AudioSource run;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip landing;

    public void RunLoop(){
        if (!run.isPlaying){
            run.loop = true;
            run.Play();
        }
    }

    public void RunLoopStop(){
        if (run.isPlaying) { 
            run.Stop();
        }
    }

    public void Idle(){
        RunLoopStop();
    }

    public void Jump(){
        RunLoopStop();// probably a better way to detect not running anymore.
        playClip(jump, transform.position);
    }

    public void Landing(){
        RunLoopStop();
        playClip(landing, transform.position);
    }

    public void Hurt(){
        RunLoopStop();
        playClip(hurt, transform.position);
    }

    public void Death() {
        RunLoopStop();
        playClip(death, transform.position);
    }

    void playClip(AudioClip clip, Vector3 point){
        AudioSource.PlayClipAtPoint(clip, point);
    }
}