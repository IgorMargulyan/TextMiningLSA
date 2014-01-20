using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMining
{
    class DAL
    {
        private string DataMiningConnectionString = "Data Source=ISL9098\\SQLEXPRESS;Initial Catalog=TextMining;Integrated Security=True";

        public SqlDataAdapter TraceabilityDataAdapter
        {
            get
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = DataMiningConnectionString;

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [dbo].[tblTrcRejectCodes] ORDER BY RejectCode";

                SqlDataAdapter da = new SqlDataAdapter(command);

                // Create the InsertCommand.
                command = new SqlCommand(
                    "INSERT INTO tblTrcRejectCodes (RejectCode, RejectType, RejectDescEng) " +
                    "VALUES (@RejectCode, @RejectType, @RejectDescEng)", conn);

                // Add the parameters for the InsertCommand.
                command.Parameters.Add("@RejectCode", SqlDbType.Int, 1, "RejectCode");
                command.Parameters.Add("@RejectType", SqlDbType.NVarChar, 50, "RejectType");
                command.Parameters.Add("@RejectDescEng", SqlDbType.NVarChar, 50, "RejectDescEng");

                da.InsertCommand = command;

                // Create the UpdateCommand.
                command = new SqlCommand(
                    "UPDATE tblTrcRejectCodes SET RejectCode = @RejectCode, RejectType = @RejectType, RejectDescEng = @RejectDescEng " +
                    "WHERE RejectCode = @oldRejectCode", conn);

                // Add the parameters for the UpdateCommand.
                command.Parameters.Add("@RejectCode", SqlDbType.Int, 1, "RejectCode");
                command.Parameters.Add("@RejectType", SqlDbType.NVarChar, 50, "RejectType");
                command.Parameters.Add("@RejectDescEng", SqlDbType.NVarChar, 50, "RejectDescEng");
                SqlParameter parameter = command.Parameters.Add(
                    "@oldRejectCode", SqlDbType.Int, 1, "RejectCode");
                parameter.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = command;

                // Create the DeleteCommand.
                command = new SqlCommand(
                    "DELETE FROM tblTrcRejectCodes1 WHERE RejectCode = @RejectCode", conn);

                // Add the parameters for the DeleteCommand.
                parameter = command.Parameters.Add("@RejectCode", SqlDbType.Int, 1, "RejectCode");
                parameter.SourceVersion = DataRowVersion.Original;

                da.DeleteCommand = command;

                return da;
            }
        }
    }
}
