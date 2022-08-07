using UnityEngine;

namespace UIFramework
{
    public class BartenderGame : BasePanel
    {
        public GameObject needDetails;
        public GameObject cupDetails;
        public GameObject messagePanel;
        bool isNeedDetails;
        bool isTaste;

        bool custormerNeedLook;

        public int tasteMaxNum;
        int tasteNum;

        float customerNeedtime;
        float Tastetime;
        

        public override void OnEnter()
        { 
            base.OnEnter();
            custormerNeedLook = true;
            tasteNum = 0;

        }
        public void OnClickReturnButton()
        {
            UIManager.Instance.PopPanel();
        }
        
        public void OnClickCustomerNeedButton()
        {
            
            if (!cupDetails.activeSelf&& custormerNeedLook)
            {
                needDetails.SetActive(true);
                isNeedDetails = true;
            }
        }
        
        public void OnClickTasteCupButton()
        {
            if (!cupDetails.activeSelf && (tasteNum <= tasteMaxNum))
            {
                tasteNum++;
                cupDetails.SetActive(true);
                isTaste = true;
            }

        }
        public void OnClickmessagePanelButton()
        {
            messagePanel.SetActive(false);
        }

        private void Update()
        {
            if (isNeedDetails)
            {
                customerNeedtime+=Time.deltaTime;
            }
            if (customerNeedtime > 5)
            {
                custormerNeedLook=false;
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
