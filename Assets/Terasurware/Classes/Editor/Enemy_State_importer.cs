using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class Enemy_State_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Assets/Parameter/Excel/Enemy_State.xls";
	private static readonly string exportPath = "Assets/Assets/Parameter/Excel/Enemy_State.asset";
	private static readonly string[] sheetNames = { "Sheet1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Enemy_State_Sheet data = (Enemy_State_Sheet)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Enemy_State_Sheet));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Enemy_State_Sheet> ();
				AssetDatabase.CreateAsset ((ScriptableObject)data, exportPath);
				data.hideFlags = HideFlags.NotEditable;
			}
			
			data.sheets.Clear ();
			using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}
				
				foreach(string sheetName in sheetNames) {
					ISheet sheet = book.GetSheet(sheetName);
					if( sheet == null ) {
						Debug.LogError("[QuestData] sheet not found:" + sheetName);
						continue;
					}

					Enemy_State_Sheet.Sheet s = new Enemy_State_Sheet.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Enemy_State_Sheet.Param p = new Enemy_State_Sheet.Param ();
						
					cell = row.GetCell(0); p.id = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.price_name_string = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.price_hp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.price_mp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.price_attack_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.price_defense_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.price_attack_range_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(7); p.price_attack_type_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.price_slanting_wall_bool = (cell == null ? false : cell.BooleanCellValue);
					cell = row.GetCell(9); p.price_possession_exp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
						s.list.Add (p);
					}
					data.sheets.Add(s);
				}
			}

			ScriptableObject obj = AssetDatabase.LoadAssetAtPath (exportPath, typeof(ScriptableObject)) as ScriptableObject;
			EditorUtility.SetDirty (obj);
		}
	}
}
