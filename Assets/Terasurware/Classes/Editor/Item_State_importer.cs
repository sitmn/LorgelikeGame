using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class Item_State_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Assets/Parameter/Excel/Item_State.xls";
	private static readonly string exportPath = "Assets/Assets/Parameter/Excel/Item_State.asset";
	private static readonly string[] sheetNames = { "Sheet1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Item_State_Sheet data = (Item_State_Sheet)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Item_State_Sheet));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Item_State_Sheet> ();
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

					Item_State_Sheet.Sheet s = new Item_State_Sheet.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Item_State_Sheet.Param p = new Item_State_Sheet.Param ();
						
					cell = row.GetCell(0); p.id = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.price_name_string = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.price_heal_point_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.price_attack_point_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.price_attack_type_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.price_attack_range_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.price_develop_material1_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(7); p.price_develop_material2_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.price_develop_material3_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(9); p.price_develop_need_mp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
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
