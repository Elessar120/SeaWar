using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace AMVCC.Controllers.Sound
{
    public class VolumeController : MonoBehaviour
    {
        public AudioMixer mixer;

        [SerializeField] Slider slider;

        private void Awake()
        {
            SetLevel(slider.value);
        }

        public void SetLevel(float sliderValue)
        {
            mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20f);     
        }
    }
}

