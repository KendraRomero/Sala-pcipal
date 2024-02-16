using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ABKaspo.Editor
{
    public class AURW_MeduBarEditor : EditorWindow
    {
        [MenuItem("ABKaspo/Documentation/A.U.R.W.")]
        public static void OpenAURWDocumentation()
        {
            Application.OpenURL("https://bryanirp.github.io/Docs/AURW%20Documetation.pdf");
        }
        [MenuItem("ABKaspo/Web Site")]
        public static void OpenWebsite()
        {
            Application.OpenURL("https://bryanirp.github.io/ABKaspo/index.html");
        }
        [MenuItem("ABKaspo/About/YouTube Channel")]
        public static void OpenYoutubeChannel()
        {
            Application.OpenURL("https://www.youtube.com/@ABKaspo-Games");
        }
        [MenuItem("ABKaspo/About/Instagram")]
        public static void OpenInstagramAccount()
        {
            Application.OpenURL("https://www.instagram.com/abkaspo_games");
        }
        [MenuItem("ABKaspo/About/Send An E-mail")]
        public static void SendAnEmail()
        {
            Application.OpenURL("mailto:abkaspo@gmail.com");
        }
    }
}