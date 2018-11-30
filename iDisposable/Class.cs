using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDisposable
{
    class Class : IDisposable
    {
        TextReader tr = null;

        public Class(string path)
        {
            Console.WriteLine("Getting Managed Resources");
            tr = new StreamReader(path);
            
            Console.WriteLine("Getting Unmanaged Resources");
        }

        void ReleaseManagedResources()
        {
            Console.WriteLine("Releasing Managed Resources");
            if (tr != null)
            {
                tr.Dispose();
            }
        }

        void ReleaseUnmangedResources()
        {
            Console.WriteLine("Releasing Unmanaged Resources");
        }

        public void ShowData()
        {
            if (tr != null)
            {
                Console.WriteLine(tr.ReadToEnd() + " / Some unmanaged data. ");
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose called from outside");
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Actual Dispose called with a " + disposing.ToString());
            if (disposing == true)
            {
                ReleaseManagedResources();
            }
            else
            {
            }
            
            ReleaseUnmangedResources();

        }

        ~Class()
        {
            Console.WriteLine("Finalizer called");
            Dispose(false);
        }
    }
}
