using System;
using System.Collections.Generic;
using AdventureCycle.AdventureNodeOptionParameters;

namespace AdventureCycle.Data
{
    [Serializable]
    public class AdventureNodeOptionComposite 
    {
        public List<BaseAdventureNodeOptionParameter> OptionParameters;
    }
}
