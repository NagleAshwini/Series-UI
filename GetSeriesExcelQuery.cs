namespace SeriesUI.ExcelReport.Queries
{
    public class GetSeriesExcelQuery
    {
        public string SelectedYears { get; set; }
        public GetSeriesExcelQuery(string years)
        {
            SelectedYears = years;
        }
    }
}
