using System;
using System.Collections.Generic;

using System.Text;

namespace UpdateHandler
{
    public interface fsIUpdatable
    {
        void Refresh();
        int Value { set;  get; }
        int Maximum { set;  get; }
        object Invoke(Delegate method, params object [] parameters);
    }
}
