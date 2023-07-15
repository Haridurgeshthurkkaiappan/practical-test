using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using Dapper;
using CRUDlib;

namespace CRUD1
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterationRepository obj = new RegisterationRepository();
            obj.doit();
        }
    }
}
