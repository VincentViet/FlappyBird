namespace FlappyBird
{
    static class ScoreManager
    {

        #region Static Properties
        public static int Scores;
        public static int HighScores;
        #endregion


        #region Method

        public static void GetHighScore() // 
        {
            HighScores = Properties.FlappyBirdSettings.Default.HighScore;
        }

        public static void UpdateHighScore() //
        {
            Properties.FlappyBirdSettings.Default.HighScore = HighScores;
            Properties.FlappyBirdSettings.Default.Save();
        }

        public static void ResetScores()
        {
            Scores = 0;
        }

        #endregion
    }
}
