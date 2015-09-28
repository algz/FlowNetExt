using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element22:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("AA孔面积（cm2）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE01孔径（cm)")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE03孔长（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(4)]
        public override string GEO3
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

        [Category("输入参数")]
        [DisplayNameAttribute("GE05回转半径（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("KG（一般孔选1）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }
    }
}
