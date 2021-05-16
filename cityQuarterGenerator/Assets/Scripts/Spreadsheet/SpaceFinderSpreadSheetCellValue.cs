using UnityEngine;

namespace MathUtils.Spreadsheet
{
    public class SpaceFinderSpreadSheetCellValue : SpreadsheetBaseValue
    {
        public Vector2 Position;
        public bool IsActive = true;

        public override SpreadsheetBaseValue GetCopy()
        {
            return new SpaceFinderSpreadSheetCellValue {Position = Position, IsActive = IsActive};
        }
    }
}