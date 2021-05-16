namespace MathUtils.Spreadsheet
{
    public class SpreadsheetCell<T>
    {
        public SpreadsheetBaseValue CellValue;
        public int RowIndex;
        public int ColumnIndex;

        public SpreadsheetCell<T> GetCopy()
        {
            return new SpreadsheetCell<T> {ColumnIndex = ColumnIndex, RowIndex = RowIndex, CellValue = CellValue.GetCopy()};
        }
    }
}