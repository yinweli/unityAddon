﻿using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FouridStudio
{
    /// <summary>
    /// SQLite資料庫
    /// 注意!不支援多執行緒
    /// </summary>
    public class RepositorySQLite : IDisposable
    {
        #region 屬性

        /// <summary>
        /// 資料庫物件
        /// </summary>
        private SqliteConnection connection = null;

        #endregion 屬性

        #region 主要函式

        public void Dispose()
        {
            close();
        }

        /// <summary>
        /// 開啟資料庫
        /// 通常用在要讀取SQLiteDB檔案時
        /// </summary>
        /// <param name="dataSource">資料來源字串</param>
        /// <returns>資料庫物件</returns>
        public RepositorySQLite open(string dataSource)
        {
            close();

            connection = new SqliteConnection(dataSource);
            connection.Open();

            return this;
        }

        /// <summary>
        /// 開啟資料庫
        /// 通常用在要讀取SQLite文字檔案時
        /// </summary>
        /// <param name="sqls">文字檔案內容列表</param>
        /// <returns>資料庫物件</returns>
        public RepositorySQLite open(IEnumerable<string> sqls)
        {
            close();

            connection = new SqliteConnection("Data Source=:memory:;Version=3;");
            connection.Open();

            foreach (string itor in sqls)
            {
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = itor;
                    command.ExecuteNonQuery();
                }//using
            }//for

            return this;
        }

        /// <summary>
        /// 關閉資料庫
        /// </summary>
        public void close()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }//if
        }

        /// <summary>
        /// 執行Sql語句
        /// </summary>
        /// <param name="sql">Sql語句</param>
        /// <returns>結果列表</returns>
        public List<SQLiteResult> query(string sql)
        {
            if (connection == null)
                throw new Exception("sqlite not open");

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    List<SQLiteResult> results = new List<SQLiteResult>();

                    while (reader.Read())
                        results.Add(new SQLiteResult(reader));

                    return results;
                }//using
            }//using
        }

        #endregion 主要函式
    }

    /// <summary>
    /// SQLite查詢結果
    /// </summary>
    public class SQLiteResult : IEnumerable
    {
        #region 屬性

        /// <summary>
        /// 結果列表
        /// </summary>
        private Dictionary<string, object> results = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                return results[key];
            }
        }

        #endregion 屬性

        #region 主要函式

        public SQLiteResult(SqliteDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; ++i)
                results[reader.GetName(i)] = reader.GetValue(i);
        }

        public IEnumerator GetEnumerator()
        {
            return results.GetEnumerator();
        }

        public Dictionary<string, object>.KeyCollection keys()
        {
            return results.Keys;
        }

        public Dictionary<string, object>.ValueCollection values()
        {
            return results.Values;
        }

        public bool isExist(string key)
        {
            return results.ContainsKey(key);
        }

        #endregion 主要函式
    }
}