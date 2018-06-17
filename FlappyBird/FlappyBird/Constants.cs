using Microsoft.Xna.Framework;

namespace FlappyBird
{
    internal static class Constants
    {
        public static readonly Rectangle BrownPipe = new Rectangle(19, 462, 88, 619);
        public static readonly Rectangle GreenPipe = new Rectangle(111, 462, 89, 619);
        public static readonly Rectangle[] BlueBird = new Rectangle[4]
        {
            new Rectangle(213, 1005, 101, 74),
            new Rectangle(210, 926, 105, 74),
            new Rectangle(210,844,105,74),
            new Rectangle(208, 760, 103, 74)
        };
        public static readonly Rectangle[] RedBird = new Rectangle[4]
        {
            new Rectangle(325, 1005, 100, 74),
            new Rectangle(318,926,105,74),
            new Rectangle(318, 844, 105, 74),
            new Rectangle(315, 760, 104, 74)
        };
        public static readonly Rectangle[] GreenBird = new Rectangle[4]
        {
            new Rectangle(439, 1006, 101, 75),
            new Rectangle(432, 929, 105, 74),
            new Rectangle(432, 847, 106, 74),
            new Rectangle(430, 762, 105, 74)
        };
        public static readonly Rectangle InstructionButton = new Rectangle(666, 840, 321, 242);
        //        public static readonly Rectangle Panel = new Rectangle(581, 571, 495, 249);
        public static readonly Rectangle Panel = new Rectangle(581, 277, 495, 249);
        public static readonly Rectangle BronzeMedal = new Rectangle(209, 463, 101, 101);
        public static readonly Rectangle GoldMedal = new Rectangle(317, 463, 102, 101);
        public static readonly Rectangle SilverMedal = new Rectangle(425, 461, 102, 102);
        public static readonly Rectangle Ground = new Rectangle(23, 214, 719, 238);
        //        public static readonly Rectangle PlayButton = new Rectangle(242, 47, 252, 151);
        public static readonly Rectangle PlayButton = new Rectangle(242, 899, 252, 151);

        public static readonly Vector2 FreeFallAcceleration = new Vector2(0.0f, 9.81f);
        public static readonly float Meters2Pixel = 30f;
        public static readonly float Pixel2Meters = 0.01f;

        public static readonly int Width = 1087;
        public static readonly int Height = 1097;
    }
}
