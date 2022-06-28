using System;
using UnityEngine;

namespace Audio
{
    public class GrassAudioSectorController : MonoBehaviour
    {

        private float lastRegistered;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }

            lastRegistered = other.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().Params[0].Value;
            
            //FIXME: SetParameter no funciona porque estos son parametros iniciales (https://qa.fmod.com/t/set-parameter-to-specific-value-not-working/13629)
            
            other.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().Params[0].Value = 1f;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().Params[0].Value = lastRegistered;
            }
        }
    }
}
