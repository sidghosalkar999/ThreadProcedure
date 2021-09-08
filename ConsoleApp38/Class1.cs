using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseDemo
{
    public class Class1
    {
        static string constr = "data source=DESKTOP-V1RC23K\\SQLEXPRESS;initial catalog=master;integrated security=True;";
        public void DisplayStudent()
        {
            DataTable DT = ExecuteData("select * from STUDENT");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("=====================================================================");
                Console.WriteLine("DATABASE RECORDS");
                Console.WriteLine("=====================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["STDNAME"].ToString() + " " + row["STDID"].ToString() + " " + row["STDROLLNO"].ToString());
                }
                Console.WriteLine("======================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("No student found in database table!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public DataTable ExecuteData(String Query)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(Query, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    sqlcon.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public void AddStudent()
        {
            string STDNAME = string.Empty;
            string STDID = string.Empty;
            string STDROLLNO = string.Empty;

            Console.WriteLine("Insert student: ");

            Console.Write("Enter STDNAME: ");
            STDNAME = Console.ReadLine();

            Console.Write("Enter STDID: ");
            STDID = Console.ReadLine();

            Console.Write("Enter STDROLLNO: ");
            STDROLLNO = Console.ReadLine();

            ExecuteCommand(String.Format("Insert into STUDENT(STDNAME,STDID,STDROLLNO) values ('{sid}','{1}','{2}')", STDNAME, STDID, STDROLLNO));
        }
        public bool ExecuteCommand(string queury)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(queury, sqlcon);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
            return true;
        }
        public void EditStudent()
        {
            string STDNAME = string.Empty;
            string STDID = string.Empty;
            string STDROLLNO = string.Empty;
            Console.WriteLine("Edit existing Student:  ");
            Console.WriteLine("Insert student: ");

            Console.Write("Enter STUDENT NAME: ");
            STDNAME = Console.ReadLine();

            Console.Write("Enter EmpName: ");
            STDID = Console.ReadLine();

            Console.Write("Enter Salary: ");
            STDROLLNO = Console.ReadLine();

            ExecuteCommand(String.Format("Update STUDENT set STDNAME = '{YASH}', STDID = '{2}', eno = '{3}' where eno = '{1}')", STDNAME, STDID, STDROLLNO));
        }

        public void DeleteStudent()
        {
            string STDNAME = string.Empty;

            Console.WriteLine("Delet Existing STUDENT ");

            Console.Write("Enter STUDENT NAME ");
            STDNAME = Console.ReadLine();

            ExecuteCommand(String.Format("Delete from STUDENT where STDNAME = '{sid}')", STDNAME));

            Console.WriteLine("STUDENT details deleted from the database!" + Environment.NewLine);
        }

    }
}
