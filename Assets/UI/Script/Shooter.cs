using UnityEngine;
using UnityEngine.UI;
namespace UIFramework
{
    public class Shooter: BasePanel
    {
        public ShootGamePlayerController shootGamePlayerController;
        public DartsMove darts1;
        public DartsMove darts2;
        public Text playerScore;
        public Text score;

        public override void OnEnter()
        {
            base.OnEnter();
            playerScore.text = "0";
            score.text = "0";
            System.Random random = new System.Random();
            shootGamePlayerController.time = random.Next(3, 5);
            darts1.speed = darts2.speed = 500;

        }
        public void OnClickReturnButton()
        {
            UIManager.Instance.PopPanel();
        }
    }
}
