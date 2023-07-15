using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace CRUDlib
{
    public class EmployeeRegister
    {
        public string Name { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public long phonenumber { get; set; }
        public DateTime DOB { get; set; }


    }
    public class RegisterationRepository
    {


        public readonly string connectionString;

        public EmployeeRegister employeeregisterinfo()
        {
            EmployeeRegister e = new EmployeeRegister();

            Console.WriteLine("enter NAME");
            e.Name = Console.ReadLine();
            Console.WriteLine("enter ADDRESS ");
            e.address = Console.ReadLine();
            Console.WriteLine("enter last AGE ");
            e.age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter last phonenumber");
            e.phonenumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("enter last DOB ");
            e.DOB = Convert.ToDateTime(Console.ReadLine());

            return e;
        }


        public RegisterationRepository()
        {
            connectionString = @"Data source=DESKTOP-UCPA9BN;Initial catalog=EmployeePractical;User Id=sa;Password=Anaiyaan@123";
        }
        public void InsertSP(EmployeeRegister e)
        {
            try
            {



                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($"   exec inserta '{e.Name}', '{e.address}',{e.age},{e.phonenumber},'{e.DOB}'");

                con.Close();

            }
            catch (SqlException ep)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<EmployeeRegister> Read()
        {
            try
            {
                List<EmployeeRegister> constrain = new List<EmployeeRegister>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<EmployeeRegister>("exec listp").ToList();
                connection.Close();
                foreach (var cons in constrain)
                {


                    Console.WriteLine($"Name\t{cons.Name},Address\t{cons.address},AGE\t{cons.age},PHONENUMBER \t {cons.phonenumber},DOB \t{cons.DOB}");
                }

                return constrain;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public void doit()
        {




            int a = 0;
            do
            {
                Console.WriteLine("choose the option");
                Console.WriteLine("0.exit");
                Console.WriteLine("1.LIST");
                Console.WriteLine("2.INSERT");


                Console.WriteLine("enter the option");
                a = Convert.ToInt32(Console.ReadLine());


                RegisterationRepository obj = new RegisterationRepository();

                switch (a)
                {
                    case 0:
                        Console.WriteLine("exiting");
                        break;
                    case 1:
                        obj.Read();
                        break;

                    case 2:
                        var detail = obj.employeeregisterinfo();
                        obj.InsertSP(detail);
                        break;

                    default:
                        Console.WriteLine("you entered the invalid option");
                        break;



                }
            } while (a != 0);
        }


    }
}
