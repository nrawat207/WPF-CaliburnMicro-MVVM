using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dapper.Sql
{
    public class Employee
    {
        public const string Insert =
        @"INSERT INTO [dbo].[Employees]
           ([Name]
           ,[Department]
           ,[Designation]
           ,[DOB]
           ,[Timestamp])
          VALUES
          (@name
          ,@department
          ,@designation
          ,@dob
          ,@timestamp
          )
        ";

        public const string Select =
        @"
         SELECT [Id]
              ,[Name]
              ,[Department]
              ,[Designation]
              ,[DOB]
              ,[Timestamp]
         FROM [dbo].[Employees]
        ";

        public const string SelectById =
        @"
         SELECT [Id]
              ,[Name]
              ,[Department]
              ,[Designation]
              ,[DOB]
              ,[Timestamp]
         FROM [dbo].[Employees]
         WHERE 1 = 1  
        ";


    }


}
