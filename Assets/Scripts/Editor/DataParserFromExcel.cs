using System;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Data;
using DefaultNamespace;
using Excel;

public class DataParserFromExcel : Editor
{
    public static string AlcoholAttributePath = Application.dataPath + "/Excels/wine.xlsx";
    public static string NeedAttributePath = Application.dataPath + "/Excels/need.xlsx";
    public static string AssetOutputPath = "Assets/Resources/DataAssets/ExcelData.asset";

    public static AlcoholItem[] ReadAlcoholExcel()
    {
        int col = 0, row = 0;
        Debug.Log(AlcoholAttributePath);
        DataRowCollection collect = ReadExcel(AlcoholAttributePath, ref col, ref row);
        AlcoholItem[] items = new AlcoholItem[row - 3];

        for (int i = 3; i < row; i++)
        {
            AlcoholItem item = new AlcoholItem();
            item.id = int.Parse(collect[i][0].ToString());
            item.name = collect[i][1].ToString();
            item.sweet = int.Parse(collect[i][2].ToString());
            item.intensity = int.Parse(collect[i][3].ToString());
            item.mellow = int.Parse(collect[i][4].ToString());
            items[i - 3] = item;
        }

        return items;
    }

    public static Need[] ReadNeedExcel()
    {
        int col = 0, row = 0;
        DataRowCollection collect = ReadExcel(NeedAttributePath, ref col, ref row);
        Need[] items = new Need[row - 3];

        for (int i = 3; i < row; i++)
        {
            Need item = new Need();
            item.id = int.Parse(collect[i][0].ToString());
            item.needSweet = int.Parse(collect[i][1].ToString());
            item.needIntensity = int.Parse(collect[i][2].ToString());
            item.needMellow = int.Parse(collect[i][3].ToString());
            item.weight = int.Parse(collect[i][4].ToString());
            items[i - 3] = item;
        }

        return items;
    }

    public static DataRowCollection ReadExcel(string path, ref int colNum, ref int rowNum)
    {
        FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);

        DataSet result = reader.AsDataSet();
        colNum = result.Tables[0].Columns.Count;
        rowNum = result.Tables[0].Rows.Count;
        return result.Tables[0].Rows;
    }

    [MenuItem("G4G/ReadFromExcel")]
    public static void CreateAssets()
    {
        ExcelDataManager manager = ScriptableObject.CreateInstance<ExcelDataManager>();
        manager.AlcoholItem = ReadAlcoholExcel();
        manager.Need = ReadNeedExcel();
        if (!Directory.Exists(AssetOutputPath))
        {
            Directory.CreateDirectory(AssetOutputPath);
        }
        
        AssetDatabase.CreateAsset(manager, AssetOutputPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

// [Serializable]
// public struct AlcoholItem
// {
//     public int id;
//     public string name;
//     public int sweet;
//     public int intensity;
//     public int mellow;
// }
//
// [Serializable]
// public struct Need
// {
//     public int id;
//     public int needSweet;
//     public int needIntensity;
//     public int needMellow;
//     public int weight;
// }

