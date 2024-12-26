using System;
using System.Collections.Generic;
using System.Text;

namespace ppo
{
    abstract class BaseFilter
    {
        public BaseFilter()
        {
        }

        public abstract void Apply(Image img);
        
    }
}
