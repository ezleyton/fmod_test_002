using FMODUnity;
using UnityEngine;

namespace Audio
{
    public class DeepForestAudioSectorController : MonoBehaviour
    {
        [SerializeField] private StudioEventEmitter windEmitter;

    private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }

            windEmitter.SetParameter("Cover", .75f);
            windEmitter.SetParameter("Birds", 1f);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }
            windEmitter.SetParameter("Cover", .35f);
            windEmitter.SetParameter("Birds", 0f);
        }
    }
}
