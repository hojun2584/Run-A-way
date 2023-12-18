using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yeseul
{ 
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        public List<AudioClip> audioClips;
        // Start is called before the first frame update
        void Start()
        {
            audioClips = new List<AudioClip> ();
            GetResource();
        }

        public void GetResource() //�ϴ� �ȴ� �Ҹ��� ����������. 
        {
            audioClips.Add(Resources.Load("MoveAudio/Walking 1") as AudioClip);
            audioClips.Add(Resources.Load("MoveAudio/Walking 2") as AudioClip);
            audioClips.Add(Resources.Load("MoveAudio/Walking 3") as AudioClip);
        }
    
        public AudioClip SetAudioSource(GameObject soundObj) //soundObj�� audioclip �������� �־���. 
        {
            AudioSource audioSource = soundObj.GetComponent<AudioSource>();
            int index = Random.Range(0, audioClips.Count);
            return audioClips[index];
        }


    }

}
