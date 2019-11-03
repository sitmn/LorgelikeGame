using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class Player_State_importer : AssetPostprocessor {
	private static readonly string filePath = "Assets/Assets/Parameter/Excel/Player_State.xls";
	private static readonly string exportPath = "Assets/Assets/Parameter/Excel/Player_State.asset";
	private static readonly string[] sheetNames = { "Sheet1", };
	
	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
	{
		foreach (string asset in importedAssets) {
			if (!filePath.Equals (asset))
				continue;
				
			Player_State_Sheet data = (Player_State_Sheet)AssetDatabase.LoadAssetAtPath (exportPath, typeof(Player_State_Sheet));
			if (data == null) {
				data = ScriptableObject.CreateInstance<Player_State_Sheet> ();
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

					Player_State_Sheet.Sheet s = new Player_State_Sheet.Sheet ();
					s.name = sheetName;
				
					for (int i=1; i<= sheet.LastRowNum; i++) {
						IRow row = sheet.GetRow (i);
						ICell cell = null;
						
						Player_State_Sheet.Param p = new Player_State_Sheet.Param ();
						
					cell = row.GetCell(0); p.id = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.price_name_string = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.price_player_MAX_hp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.price_player_origin_hp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.price_player_hp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.price_player_MAX_mp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.price_player_origin_mp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(7); p.price_player_mp_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.price_player_origin_attack_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(9); p.price_player_attack_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(10); p.price_player_origin_defense_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(11); p.price_player_defense_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(12); p.price_player_attack_through_bool = (cell == null ? false : cell.BooleanCellValue);
					cell = row.GetCell(13); p.price_player_attack_range_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(14); p.price_player_attack_type_int = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(15); p.price_player_slanting_wall_bool = (cell == null ? false : cell.BooleanCellValue);
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
