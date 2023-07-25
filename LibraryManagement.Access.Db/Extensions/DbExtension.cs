using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Access.Db.Extensions
{
    internal static class DbExtension
    {
        public static DbCommand AddParameter(this DbCommand command, string name, object value, DbType type)
        {
            DbParameter param = command.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            param.DbType = type;

            command.Parameters.Add(param);

            return command;
        }
    }
}
