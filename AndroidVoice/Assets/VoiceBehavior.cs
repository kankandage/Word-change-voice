using UnityEngine;
using UnityEngine.UI;
public class VoiceBehavior : MonoBehaviour
{
    /*
    本脚本用于andriod版本的在线文字转语音。来源于游戏蛮牛的大神的一篇帖子。
    转载请务必注明作者和原文链接（不需要授权费）作者：MemoryC  链接： http://www.manew.com/forum.php?mod=viewthread&tid=100446&extra=page%3D&page=1 
     
    写给小白：
    1.File菜单下Buile Settings点击选择Android平台后点击下方SwitchPlatform！
    2.在本机上存在问题;运行会报错误 JNI:init'd AndroidJavaObject with null ptr    
    未解决：作者的电脑运行可以。但将游戏发布到模拟器可以运行，但不利于进行在线调试。
    猜想：可能电脑中Java可能有问题，或者说Unity版本的问题
    3.APPID写在了IFlyVoice中
    
     如果要重新做：
     1.如果你使用从官网下载的库，把整个libs导入/Assets/Plugins/Android/下面之后，在发布时遇到库冲突问题，那是 科大讯飞自己的bug。解决方案，删除mips、mips64、x86_64、armeabi-v8a等几个文件夹，sunflower也可以删除。
     2.AndroidMenifest.xml
       
        
      运用方法：
      1.采用静态类调用   
        1.1  
        string text1 = "哆啦A梦，哈哈哈";
          IFlyVoice.startSpeaking(text1);    
          
        1.2 
        string text2 = "哆啦A梦，可爱的蓝胖子";
         text2.speak();

        2.关于选择不同人发音
        对于以上任意一种方法，在函数参数里面加一个人名参数即可，如：
         2.1
         IFlyVoice.startSpeaking("您好，我是小强", "xiaoqiang");
         2.2
         "我是小梅，感谢您阅读MemoryC的系列文章".speak("xiaomei");

        //////具体有哪些发音人，作者附在文章后面////////

        ///////这只是文字转语音的用法，一些其他的用法也可用，但需要找到对应的方法，而且我的API只有在线文字转语音的功能。所以可能还需要在换新的API////
        */

    //按钮
    public Button speakButton;

    // Use this for initialization
    void Start()
    {
        if (speakButton != null)
        {

            speakButton.onClick.AddListener(delegate
            {
                IFlyVoice.startSpeaking("哆啦A梦，可爱的蓝胖子", "xiaoxin");

            });
        }

        //if (synthButton != null)
        //{
        //    synthButton.onClick.AddListener(delegate {
        //        //开始识别 普通话
        //        IFlyVoice.startRecognize();

        //        //关于选择不同识别语种
        //        //对于以上方法，在函数参数里面加一个语种参数即可，如：
        //       // IFlyVoice.startRecognize("cantonese");//粤语
        //                                              //////具体有哪些语种，我附在文章后面////////

        //        /// //////////////////////////以上方法不可同时执行///////////////////////////////
        //        /// //////////////////////////////////请选择一种////////////////////////////////////
        //    });
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
