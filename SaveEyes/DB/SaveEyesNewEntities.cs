using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEyes.DB
{
    public partial class SaveEyesNewEntities
    {
        private static SaveEyesNewEntities _context;

        public static SaveEyesNewEntities GetContext()
        {
            if (_context == null )
                _context = new SaveEyesNewEntities();

            return _context;
        }
    }
}
