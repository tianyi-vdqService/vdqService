﻿using Common.Lib.Core;
using Common.Lib.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Util
{
    public class LogUtil
    {
        public static readonly string MySqlCon = ConfigurationManager.ConnectionStrings["SqlConnectionStr"].ToString();
        public static void WriteLog(string content, int logType)
        {
            string insertSql = "INSERT INTO t_log (`content`, `type_id`, `create_time`, `description`) VALUES ('"+ content + "'," + logType+ ", " + System.DateTime.Now + ", '" + content + "')"; 
            MySqlConnection mysql = DBMySql.getMySqlCon(MySqlCon);
            MySqlCommand mySqlCommand = DBMySql.getSqlCommand(insertSql, mysql);
            //打开连接
            mysql.Open();
            mySqlCommand.ExecuteNonQuery();
            //记得关闭
            mysql.Close();
        }
    }
}
