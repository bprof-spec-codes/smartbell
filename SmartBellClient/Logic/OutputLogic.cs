using Data;
using SpeechLib;
using System;
using System.IO;
using System.Threading;
using System.Windows.Media;

namespace Logic
{
    public class OutputLogic : IOutputLogic
    {
        public void TTS(string txt)
        {
            SpVoice voice = new SpVoice();
            SpObjectTokenCategory otc = new SpObjectTokenCategory();
            // otc.SetId("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\Voices"); // the original route
            otc.SetId("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech_OneCore\\Voices"); // route to access regional voices
            ISpeechObjectTokens tokenEnum = otc.EnumerateTokens();
            int nTokenCount = tokenEnum.Count;
            int i = -1;
            bool found = false;
            while (i < nTokenCount && !found)
            {
                i++;
                try
                {
                    if (tokenEnum.Item(i).GetDescription() == "Microsoft Szabolcs - Hungarian (Hungary)")
                    {
                        found = true;
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            if (found)
            {
                voice.Voice = (SpObjectToken)tokenEnum.Item(i);
                voice.Speak(File.ReadAllText(txt)); 
            }
            else
            {
                voice.Speak(File.ReadAllText(txt));
            }
            Thread.Sleep(10000);
        }

        public void MP3(string audio)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(Directory.GetParent(
                Environment.CurrentDirectory).Parent.Parent.FullName + @"\Output" + @$"\{audio}"));
            mplayer.Play();
            Thread.Sleep(10000);
        }
        

    }
}
