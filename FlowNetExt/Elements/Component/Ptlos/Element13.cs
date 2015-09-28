using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element13:Element11
    {
        [Category("输入参数")]
        [DisplayNameAttribute("GEO2")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO2
        {
            get;
            set;
        }
    }
}
