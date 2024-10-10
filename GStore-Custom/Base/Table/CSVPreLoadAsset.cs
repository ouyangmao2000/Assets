/*
 * 自动生成代码
 * 请勿编辑
 */
using System.Collections.Generic;
using System;
using UnityEngine;

public class CSVPreLoadAsset : CSVData
{
    private static readonly CSVPreLoadAsset ms_instance = new CSVPreLoadAsset();

    public static CSVPreLoadAsset Instance
    {
        get
        {
            return ms_instance;
        }
    }

    public Dictionary<ulong, CSVPreLoadAsset> csvDataDic = new Dictionary<ulong, CSVPreLoadAsset>();

    //定义字段
    /// <summary>
    /// ID
    /// </summary>
    public int id { get; private set; }
    /// <summary>
    /// 预制路径
    /// </summary>
    public string asset_path { get; private set; }
    /// <summary>
    /// 预制id
    /// </summary>
    public int asset_id { get; private set; }


    static string tableName = "preLoadAsset";

    //对应的csv文件
    protected override string Name()
    {
        return tableName;
    }

    public static void Load()
    {
        Instance.LoadCSVTable();
    }
    
    /// <summary>
    /// 获取对象(通过多个Key,最多5个key)
    /// </summary>
    public static CSVPreLoadAsset GetPreLoadAsset(int id)
    {
        ulong key = CSVHelper.GetKey(id);
        CSVPreLoadAsset data = Instance.Get(key);
        if(data == null)
        {
            Debug.LogErrorFormat("{0} 表 key {1} 出错了",tableName,id);  
        }
        return data;
    }
   

    public static Dictionary<ulong, CSVPreLoadAsset> GetAllDic(bool isCache = true)
    {
        return Instance.GetAll(isCache);
    }

    public static void UnLoad(bool isRemove = true)
    {
        Instance.UnLoadData(isRemove);
    }
    
    /// <summary>
    /// 通过ID获取对象
    /// </summary>
    private CSVPreLoadAsset Get(ulong key, bool isCache = true)
    {
        LoadCSVTable();
        CSVPreLoadAsset csvData;
        if (!csvDataDic.TryGetValue(key, out csvData))
        {
            CSVBytesData bytesData = GetCSVBytesData(key);
            if (bytesData == null)
            {
                return null;
            }
            csvData = GetCSVData(bytesData);
            if (isCache)
            {
                if (!csvDataDic.ContainsKey(key))
                {
                    csvDataDic.Add(key, csvData);
                }
            }
        }
        return csvData;
    }

    protected CSVPreLoadAsset GetCSVData(CSVBytesData bytesData)
    {
        CSVPreLoadAsset csvData = null;
        try
        {
            csvData = new CSVPreLoadAsset();
            csvData.bytesData = bytesData;
            bytesData.BeginLoad();
            //设置字段值
    	    csvData.id = bytesData.ReadIntValue();
            csvData.asset_path = bytesData.ReadString();
    	    csvData.asset_id = bytesData.ReadIntValue();

        }
        catch (Exception exception)
        {
            Debug.LogErrorFormat("{0}表 解析出错 {1}",tableName, exception.StackTrace);
            return null;
        }

        return csvData;
    }
    


    private Dictionary<ulong, CSVPreLoadAsset> GetAll(bool isCache)
    {
        LoadCSVTable();
        Dictionary<ulong, CSVPreLoadAsset> allDic = new Dictionary<ulong, CSVPreLoadAsset> ();
        if (csvDataDic.Count == GetAllCSVBytesData().Count)
        {
            allDic = csvDataDic;
        }
        else
        {
            csvDataDic.Clear();
            var _itor = GetAllCSVBytesData().GetEnumerator();
            while (_itor.MoveNext())
            {
                CSVPreLoadAsset csvData = Get(_itor.Current.Key);
                allDic.Add(_itor.Current.Key, csvData);
            }
            if (isCache)
            {
                csvDataDic = allDic;
            }
        }
        return allDic;
    }

    public override void UnLoadData(bool isRemove = true)
    {
        base.UnLoadData(isRemove);
        csvDataDic.Clear();
        if (isRemove)
        {
            CSVManager.Instance.RemoveCSVData(Name());
        }
    }
}
