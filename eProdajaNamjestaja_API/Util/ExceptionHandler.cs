using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eProdajaNamjestaja_API.Util
{
    public class ExceptionHandler
    {
        public static string HandleException(EntityException ex)
        {
            SqlException error = ex.InnerException as SqlException;

            switch (error.Number)
            {
                case 2627:
                    return getConstraintExceptionMessage(error);
                case 2601:
                    return getConstraintExceptionMessage(error);
            }
            return error.Message + " (" + error.Number + ")";
        }

        private static string getConstraintExceptionMessage(SqlException error)
        {
            string msg = error.Message;

            int startIndexDbName = msg.IndexOf("'");
            int endIndexDbName = msg.IndexOf("'", startIndexDbName + 1);

            int startIndex = msg.IndexOf("'", endIndexDbName + 1);
            int endIndex = msg.IndexOf("'", startIndex + 1);

            if (startIndex > 0 && endIndex > 0)
            {
                string constraintName = msg.Substring(startIndex + 1, endIndex - startIndex - 1);

                if (constraintName == "CS_KorisnickoIme")
                    msg = "Username_con: Korisničko ime već postoji";
                else if (constraintName == "CS_Mail")
                    msg = "Email_con: Email već postoji.";

            }

            return msg;
        }
    }

}
