using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element51:Element52
    {
        [Category("输入参数")]
        [DisplayNameAttribute("GE06输入温升（K)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(7)]
        public override string GEO6
        {
            get;
            set;
        }
    }
}
