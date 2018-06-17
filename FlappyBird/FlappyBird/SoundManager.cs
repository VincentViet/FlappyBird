using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace FlappyBird
{
    static class SoundManager
    {
        private static Dictionary<string, SoundEffect> _sound = new Dictionary<string, SoundEffect>();

        public static void Add(string name,SoundEffect soundEffect)
        {
            _sound.Add(name, soundEffect);
        }

        public static void Play(string name)
        {
            if (_sound.ContainsKey(name))
            {
                _sound[name].Play();
            }
        }
    }
}
