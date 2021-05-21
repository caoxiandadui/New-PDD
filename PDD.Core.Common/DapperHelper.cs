using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace PDD.Core.Common
{
    public class DapperHelper
    {
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="Mysql">Mysql语句</param>
        /// <returns></returns>
        public static object Scalar(string Mysql)
        {
            using (IDbConnection conn=new MySqlConnection(ConfigurationManager.conn))
            {
                object result = conn.ExecuteScalar(Mysql);
                return result;
            }
        }
        /// <summary>
        /// 返回列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Mysql"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string Mysql)
        {
            using (IDbConnection conn = new MySqlConnection(ConfigurationManager.conn))
            {
                var result = conn.Query<T>(Mysql).ToList();
                return result;
            }
        }
        /// <summary>
        /// 添加、删除、修改
        /// </summary>
        /// <param name="Mysql"></param>
        /// <returns></returns>
        public static int Execute(string Mysql)
        {
            using (IDbConnection conn = new MySqlConnection(ConfigurationManager.conn))
            {
                var result = conn.Execute(Mysql);
                return result;
            }
        }
        public int Delete(string Mysql)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
            {

                var result = db.Execute(Mysql);
                return result;
            }
        }

        //添加
        public int Add(string Mysql)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
            {

                var result = db.Execute(Mysql);
                return result;
            }
        }
        public int Upt(string Mysql)
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
            {

                var result = db.Execute(Mysql);
                return result;
            }
        }

        /// <summary>
        ///adas
        /// </summary>
        /// <param name="Mysql"></param>
        /// <returns></returns>
        public int CUD<T>(string Mysql,T t)
        {
            using (IDbConnection conn = new MySqlConnection(ConfigurationManager.conn))
            {
                var result = conn.Execute(Mysql);
                return result;
            }
        }
    }
}
