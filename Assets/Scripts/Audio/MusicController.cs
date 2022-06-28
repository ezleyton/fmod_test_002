using FMODUnity;
using UnityEngine;

namespace Audio
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private StudioEventEmitter musicEmitter;
        [SerializeField, Range(0f, 1f)] private float initialVolume = .3f; 
        
        // Start is called before the first frame update
        void Start()
        {
            musicEmitter.Play();
            musicEmitter.EventInstance.setVolume(initialVolume);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
