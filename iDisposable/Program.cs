using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader tr = null;

            try
            {            
                tr = new StreamReader(@"Files\test.txt");
                
                string s = tr.ReadToEnd();

                Console.WriteLine(s);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (tr != null)
                {
                    tr.Dispose();
                }
            }
            Console.WriteLine(); Console.WriteLine();
            
            TextReader tr2 = null;
              
            try
            {
                using (tr2 = new StreamReader(@"Files\test.txt"))
                {
                    string s = tr2.ReadToEnd();

                    Console.WriteLine(s);
                }
            }
            catch (Exception ex)
            {
            }
            Console.WriteLine(); Console.WriteLine();

            Class r = null;

            try
            {
                r = new Class(@"Files\test.txt");
                r.ShowData();
            }
            finally
            {
                r.Dispose();
            }

            Console.WriteLine(); Console.WriteLine();
            
            Class r2 = null;
            using (r2 = new Class(@"Files\test.txt"))
            {
                r2.ShowData();
            }

            Console.WriteLine(); Console.WriteLine();
            
            Class r3 = new Class(@"Files\test.txt");
            r3.ShowData();



        }
    }
}

