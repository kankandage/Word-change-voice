using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

namespace IFLYSpeech
{

    [RequireComponent(typeof(AudioSource))]
    public class TextAudioBehaiver : MonoBehaviour
    {


        public static TextAudioBehaiver TextAudioInstance;

        private UnityAction<string> onComplete;
        private Txt2AudioCtrl t2a { get { return Txt2AudioCtrl.Instance; } }
        private AudioSource audioSource;
        public bool IsOn { get; set; }
        public bool IsMan { get; set; }
        private AudioTimer audioTimer = new AudioTimer();
        void Awake()
        {
            IsOn = true;
            audioSource = gameObject.AddComponent<AudioSource>();

            TextAudioInstance = this;
        }

        private void Update()
        {
            if (!IsOn) return;
            audioTimer.Update();
        }
        /// <summary>
        /// 播放语音的函数
        /// </summary>
        /// <param name="text"></param>语音的内容
        public void PlayAudio(string text)
        {

            if (!IsOn) return;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                audioTimer.Stop();
            }

            StartCoroutine(t2a.GetAudioClip(text, (x) =>
            {
                if (x != null)
                {
                    audioSource.clip = x;
                    audioSource.Play();
                    audioTimer.Init(text, x.length, OnComplete);
                }
            }));
        }

        /// <summary>
        /// 暂停语音播放
        /// </summary>
        /// <param name="on"></param>
        public void Pause(bool on)
        {
            if (!IsOn) return;
            if (audioTimer == null) return;

            if (!on)
            {
                audioSource.Pause();
                audioTimer.Pause();
            }
            else
            {
                audioSource.UnPause();
                audioTimer.UnPause();
            }
        }

        /// <summary>
        /// 停止语音播放
        /// </summary>
        /// <param name="data"></param>
        public void Stop(string data)
        {
            if (!IsOn) return;
            audioSource.Stop();
            audioTimer.Stop();
        }

        public void RegistCallBack(UnityAction<string> onComplete)
        {
            if (!IsOn) return;
            this.onComplete = onComplete;
        }

        private void OnComplete(string text)
        {
            if (onComplete != null) onComplete(text);
        }
    }

}
