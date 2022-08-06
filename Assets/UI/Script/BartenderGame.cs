using UnityEngine;

namespace UIFramework
{
    public class BartenderGame : BasePanel
    {
        public GameObject needDetails;
        bool isNeedDetails;

        float time;
        public void OnClickReturnButton()
        {
            UIManager.Instance.PopPanel();
        }public void OnClickCustomerNeedButton()
        {
            needDetails.SetActive(true);
            isNeedDetails=true;
        }
        private void Update()
        {
            if (isNeedDetails)
            {
                time+=Time.deltaTime;
            }
            if (time > 5)
            {
                needDetails.SetActive(false);
                isNeedDetails=false;
                time=0;

            }
        }

    }
}
