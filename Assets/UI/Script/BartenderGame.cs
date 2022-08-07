using UnityEngine;

namespace UIFramework
{
    public class BartenderGame : BasePanel
    {
        public GameObject needDetails;
        public GameObject cupDetails;
        bool isNeedDetails;
        bool isTaste;

        float customerNeedtime;
        float Tastetime;
        public void OnClickReturnButton()
        {
            UIManager.Instance.PopPanel();
        }public void OnClickCustomerNeedButton()
        {
            needDetails.SetActive(true);
            isNeedDetails=true;
        }public void OnClickTasteButton()
        {
            cupDetails.SetActive(true);
            isTaste = true;
        }
        
        private void Update()
        {
            if (isNeedDetails)
            {
                customerNeedtime+=Time.deltaTime;
            }
            if (customerNeedtime > 5)
            {
                needDetails.SetActive(false);
                isNeedDetails=false;
                customerNeedtime=0;

            }if (isTaste)
            {
                Tastetime += Time.deltaTime;
            }
            if (Tastetime > 5)
            {
                cupDetails.SetActive(false);
                isTaste = false;
                Tastetime = 0;

            }
        }

    }
}
