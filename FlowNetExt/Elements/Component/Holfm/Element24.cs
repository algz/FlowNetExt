using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element24:Element
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
        [DisplayNameAttribute("GE01孔径（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE02孔长（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE03孔倾角（度）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(4)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE04偏航角（度）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE05Mg")]
        [BrowsableAttribute(true)]
        [PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE06Tg")]
        [BrowsableAttribute(true)]
        [PropertyOrder(7)]
        public override string GEO6
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE07（上游通道截面积/出口面积）（cm2）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(8)]
        public override string GEO7
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("KG（0，1）"), PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }

    }
}
