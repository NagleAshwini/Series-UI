using SeriesUI.DAL;
using SeriesUI.ExcelReport.Queries;
using System.Data;

public class GetSeriesExcelQueryHandler
{
    private readonly SeriesDAL _dal = new SeriesDAL();
    private readonly ReportService _reportService = new ReportService();

    // Logic for the JSON Grid
    public List<Dictionary<string, object>> HandleJson(GetSeriesExcelQuery query)
    {
        DataTable dt = _dal.GetYearlyReportData(query.SelectedYears);

        var rows = new List<Dictionary<string, object>>();
        foreach (DataRow dr in dt.Rows)
        {
            var row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return rows;
    }

    // Logic for the Excel Download
    public byte[] HandleExcel(GetSeriesExcelQuery query)
    {
        DataTable dt = _dal.GetYearlyReportData(query.SelectedYears);
        return _reportService.GenerateYearlySeriesExcel(dt, query.SelectedYears);
    }
}