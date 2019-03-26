using UnityEngine;
using System.Collections;
using IFLYSpeech;

/// <summary>
/// 对文字转语音应用的介绍
/// </summary>
public class Test : MonoBehaviour
{
    /*
    在线语音播放功能
    前期由张凯峰师兄完成。
     1.‘注册，添加应用（带ID号）
     2.下载Windows版本，C语言，没有C#
     3.网上用于Unity的例子都是用Android版本开发的
     4.找了一个例子，C#调用C的dll
     5.替换应用ID和dll文件

    现在将文件夹OnLineAudio、Plugin、StreamingAssets放入Unity的Assents中

    其中
    OnLineAudio文件夹中放入控制语音播放的基本属性。
    Params脚本中的voice_name为说话人的语音可以更改为多种形式，具体可看Speakers脚本的介绍。
    Params中还包含一些其他的语音属性。

    Plugins文件夹中放入C#调用的C的dll。
    StreamingAssets的Audio存放在线已经转好的语音。
     
   使用：1，将TextAudioBehavier脚本放在需要收听语音的物体上

   （介绍文字转语音的用法，此脚本只是提供简单的例子，仅供参考）
        2.在需要播放语音的脚本上添加域名IFLYSpeech
        
        
        
     */


    //定义一个字符串数组
    string[] kankan;
    //控制语音播放的时间
    bool voiceStart;
    bool voiceStop;
    void Start()
    {
        //
        kankan = new string[] { "可以是哒是哒是哒", "香蕉", "橘子" };

        voiceStart = true;
    }

    //
    IEnumerator WaitVoice(float i)
    {
        yield return new WaitForSeconds(i);
        voiceStop = true;
    }

    void PlayVoice(string str, float time)
    {
        if (voiceStart)
        {
            TextAudioBehaiver.TextAudioInstance.PlayAudio(str);
            voiceStart = false;
        }
        StartCoroutine("WaitVoice", time);
        //
        if (voiceStop)
        {
            voiceStart = true;
            StopCoroutine("WaitVoice");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayVoice(kankan[0], 3);
    }
}
