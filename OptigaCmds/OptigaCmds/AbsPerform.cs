using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptigaCmds
{
    public abstract class AbsPerform
    {
        public abstract bool ValidateParam();
        public abstract bool ValidateInLen();
        public abstract bool ValidateOID();
        public abstract void DoTask();
    }
}
