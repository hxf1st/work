using System;
using System.Collections.Generic;
using System.Text;

namespace JiDian.Business
{
    public interface handler
    {
        void initialize(Object obj);
        Object loadObject();

    }
}
