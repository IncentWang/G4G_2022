using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ExcelData", menuName = "Data", order = 0)]
    public class ExcelDataManager : ScriptableObject
    {
        public AlcoholItem[] AlcoholItem;
        public Need[] Need;
    }
}