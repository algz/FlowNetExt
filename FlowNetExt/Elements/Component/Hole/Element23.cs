using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element23:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("AA进口面积（cm2）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE01CD")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }
    }
}
