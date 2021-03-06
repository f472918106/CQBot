﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CQBot.Assist.DB
{
    /// <summary>
    /// Sql帮助类
    /// </summary>
    public class SqlHelper
    {
        //数据库连接字符串
        private string connString = @"Data Source=DESKTOP-BG6JJLQ;Database=Dictionary;Integrated Security=true";
        //创建数据库连接空对象
        private SqlConnection conn = null;

        //构造函数
        public SqlHelper()
        {
            //数据库连接对象实例化
            conn = new SqlConnection(connString);
            Connect();
        }

        //析构函数
        ~SqlHelper()
        {
            //关闭数据库连接
            DisConnect();
        }

        //打开数据库连接
        private void Connect()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        //关闭数据库连接
        public void DisConnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        //查询操作
        public DataTable Query(string sqlStr, SqlParameter[] parameters)
        {
            if (conn.State != ConnectionState.Open)
            {
                Connect();
            }
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            if (parameters != null)//判断一下parameters是否为空,不判断会出错
                cmd.Parameters.AddRange(parameters);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //存储操作
        public void Save(string sqlStr, SqlParameter[] parameters)
        {
            if (conn.State != ConnectionState.Open)
            {
                Connect();
            }
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
        }

        //删除操作
        public void Delete(string sqlStr)
        {
            if (conn.State != ConnectionState.Open)
            {
                Connect();
            }
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
