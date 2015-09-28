using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element4:Element1
    {

        [Category("输入参数")]
        [DisplayNameAttribute("GE08R1（cm）")]
        [PropertyOrder(9)]
        [BrowsableAttribute(true)]
        public override string GEO8
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE09R2（cm）")]
        [PropertyOrder(10)]
        [BrowsableAttribute(true)]
        public override string KG
        {
            get;
            set;
        }

    }
}
