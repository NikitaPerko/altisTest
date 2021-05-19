using UnityEngine;

namespace MathUtils.Spreadsheet
{
    public class SpaceFinderSpreadSheetCellValue : SpreadsheetBaseValue<SpaceFinderSpreadSheetCellValue>
    {
        public Vector2 Position;
        public bool IsActive = true;

        public override SpaceFinderSpreadSheetCellValue GetCopy()
        {
            return new SpaceFinderSpreadSheetCellValue {Position = Position, IsActive = IsActive};
        }
    }
}