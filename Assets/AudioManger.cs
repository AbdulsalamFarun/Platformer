using UnityEngine;



    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioSource SFXSource;

        public AudioClip death;
        public AudioClip checkPoint;
        public AudioClip footSteps;
        public AudioClip JumpingUp;
        public void PlaySFX(AudioClip clip)
        {
            SFXSource.PlayOneShot(clip);
        }

    }

