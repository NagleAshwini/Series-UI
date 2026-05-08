using SeriesUI.Models;
using System.Data;
using System.Data.SqlClient;

namespace SeriesUI.DAL
{
    public class SeriesDAL
    {
        DbHelper db = new DbHelper();

        public int InsertSeries(SeriesModel model)
        {
            SqlParameter[] param = new SqlParameter[]

            {
        new SqlParameter("@SeriesName", model.SeriesName),
        new SqlParameter("@SeriesType", model.SeriesType),
        new SqlParameter("@SeriesStatus", model.SeriesStatus ?? (object)DBNull.Value),
        new SqlParameter("@MatchStatus", model.MatchStatus ?? (object)DBNull.Value),
        new SqlParameter("@MatchFormat", model.MatchFormat ?? (object)DBNull.Value),
        new SqlParameter("@SeriesMatchType", model.SeriesMatchType ?? (object)DBNull.Value),
        new SqlParameter("@Gender", model.Gender),
        new SqlParameter("@Year", model.Year),
        new SqlParameter("@TrophyType", model.TrophyType ?? (object)DBNull.Value),
        new SqlParameter("@StartDate", model.StartDate),
        new SqlParameter("@EndDate", model.EndDate),
        new SqlParameter("@IsActive", model.IsActive),
        new SqlParameter("@Description", model.Description ?? (object)DBNull.Value)
    };

            return db.ExecuteNonQuery("prdTblSeriesInsert", param);
        }

        // UPDATE
        public int UpdateSeries(SeriesModel model)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SeriesId", model.SeriesId),
                new SqlParameter("@SeriesApiId", model.SeriesApiId),
                new SqlParameter("@SeriesName", model.SeriesName),
                new SqlParameter("@SeriesType", model.SeriesType),
                new SqlParameter("@SeriesStatus", model.SeriesStatus ?? (object)DBNull.Value),
                new SqlParameter("@MatchStatus", model.MatchStatus ?? (object)DBNull.Value),
                new SqlParameter("@MatchFormat", model.MatchFormat ?? (object)DBNull.Value),
                new SqlParameter("@SeriesMatchType", model.SeriesMatchType ?? (object)DBNull.Value),
                new SqlParameter("@Gender", model.Gender),
                new SqlParameter("@Year", model.Year),
                new SqlParameter("@TrophyType", model.TrophyType ?? (object)DBNull.Value),
                new SqlParameter("@StartDate", model.StartDate),
                new SqlParameter("@EndDate", model.EndDate),
                new SqlParameter("@IsActive", model.IsActive),
                new SqlParameter("@Description", model.Description ?? (object)DBNull.Value)
            };

            return db.ExecuteNonQuery("prcTblSeriesUpdate", param);
        }

        // SEARCH
        public DataTable SearchSeries(int? seriesApiId, string seriesName, string seriesType, DateTime? startDate, DateTime? endDate, int? seriesId = null)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SeriesApiId", (object)seriesApiId ?? DBNull.Value),
                new SqlParameter("@SeriesName", (object)seriesName ?? DBNull.Value),
                new SqlParameter("@SeriesType", (object)seriesType ?? DBNull.Value),
                new SqlParameter("@StartDate", (object)startDate ?? DBNull.Value),
                new SqlParameter("@EndDate", (object)endDate ?? DBNull.Value),
                new SqlParameter("@SeriesId", (object)seriesId ?? DBNull.Value) // Map the primary key here
            };

            return db.ExecuteSelect("prcTblSeriesSearch", param);
        }
        public int DeleteSeries(int id)
        {
            SqlParameter[] param = new SqlParameter[]
            {
        new SqlParameter("@SeriesId", id)
            };

            return db.ExecuteNonQuery("prcTblSeriesDelete", param);
        }

        public DataTable GetYearlyReportData(string years)
        {
            // Using DataTable makes it easier to handle dynamic counts in the frontend
            DataTable dt = new DataTable();

            SqlParameter[] param = new SqlParameter[]
            {
        new SqlParameter("@YearList", years)
            };

            // Assuming your db.ExecuteQuery returns a DataTable
            dt = db.ExecuteQuery("GetSeriesReportByYears", param);

            return dt;
        }
    }
}


