using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element21:Element
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
        [DisplayNameAttribute("GE03孔回转半径（cm）半径")]
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
        [DisplayNameAttribute("GE07接受孔变化系数（1）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(8)]
        public override string GEO7
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("DOEL")]
        [BrowsableAttribute(true)]
        [PropertyOrder(9)]
        public override string GEO8
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("KG预旋喷嘴元件号")]
        [Description("相关预旋喷嘴元件号.")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }
    }
}
