public class TableName
{
	public const string assets = "assets";
	public const string preLoadAsset = "preLoadAsset";
	public const string setting = "setting";
}

public enum ECSVAssets
{
   /// <summary>
   /// id
   /// </summary>
   id = 0,
   /// <summary>
   /// 目录
   /// </summary>
   dir = 1,
   /// <summary>
   /// 名字
   /// </summary>
   name = 2,
   /// <summary>
   /// 后缀
   /// </summary>
   suffix = 3,
   /// <summary>
   /// ab包名字,用于合并打包资源,场景不可用些字段
   /// </summary>
   abname = 4,
}

public enum ECSVPreLoadAsset
{
   /// <summary>
   /// ID
   /// </summary>
   id = 0,
   /// <summary>
   /// 预制路径
   /// </summary>
   asset_path = 1,
   /// <summary>
   /// 预制id
   /// </summary>
   asset_id = 2
}

public enum ECSVSetting
{
   /// <summary>
   /// settingID
   /// </summary>
   setting_id = 0,
   /// <summary>
   /// 英文简写
   /// </summary>
   name = 1,
   /// <summary>
   /// 数值
   /// </summary>
   int_value = 2,
   /// <summary>
   /// 字符参数
   /// </summary>
   string_value = 3
}

