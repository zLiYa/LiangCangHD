using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // 数据库连接字符串
            string connectionString = "Server=localhost;Database=LiangCang;User Id=sa;Password=zsq20030223;";

            // 目标表名
            string tableName = "UserInfo";

            // 使用SqlConnection连接数据库
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 查询表结构的SQL语句
                string query = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{tableName}'";

                // 定义一个方法来将数据库类型映射到C#类型
                Func<string, string> mapToCSharpType = dbType =>
                {
                    switch (dbType.ToLower())
                    {
                        case "int":
                        case "bigint":
                            return "int";
                        case "nvarchar":
                        case "varchar":
                            return "string";
                        case "datetime":
                            return "DateTime";
                        case "char":
                            return "string";
                        case "tinyint":
                            return "byte";
                        // 可以继续添加其他类型映射
                        default:
                            throw new NotSupportedException($"Unsupported database type: {dbType}");
                    }
                };

                // 使用SqlCommand执行查询并生成实体类代码
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    StringBuilder entityClassBuilder = new StringBuilder();
                    entityClassBuilder.AppendLine("public class " + tableName);
                    entityClassBuilder.AppendLine("{");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader.GetString(0);
                            string dataType = reader.GetString(1);
                            string cSharpType = mapToCSharpType(dataType);
                            string propertyName = char.ToUpper(columnName[0]) + columnName.Substring(1); // 首字母大写转换
                            entityClassBuilder.Append($"\tpublic {cSharpType} {propertyName} {{ get; set; }}");
                            entityClassBuilder.AppendLine();
                        }
                    }

                    entityClassBuilder.AppendLine("}");

                    // 指定输出文件的路径
                    string outputFilePath = @"E:\Work\个人项目\良仓\UserInfoEntity.cs";

                    // 使用StreamWriter将实体类定义写入文件
                    using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
                    {
                        writer.Write(entityClassBuilder.ToString());
                    }

                    Console.WriteLine($"实体类已成功保存至：{outputFilePath}");
                }
            }
        }
    }
}