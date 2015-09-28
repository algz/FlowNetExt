using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element64:Element
    {

        [Category("输入参数")]
        [DisplayNameAttribute("GE01盘外半径（cm)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE02盘内半径(cm)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE04RPM")]
        [BrowsableAttribute(true)]
        [PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }

    }
}
