using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEGORacersAPI
{
    class InitializedEventArgs : EventArgs
    {
        public InitializedType Type { get; private set; }

        public InitializedEventArgs(InitializedType type)
        {
            Type = type;
        }
    }
}