using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element86:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("进口面积")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("出口面积")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("扰流柱直径")]
        [BrowsableAttribute(true)]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("通道高度")]
        [BrowsableAttribute(true)]
        [PropertyOrder(4)]
        public override string GEO3
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("弦向间距")]
        [Description("弦向(冷气流动方向)间距")]
        [BrowsableAttribute(true)]
        [PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("径向间距")]
        [Description("径向(与冷气流动方向垂直)间距")]
        [BrowsableAttribute(true)]
        [PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("弦向排数")]
        [Description("弦向(冷气流动方向)排数")]
        [BrowsableAttribute(true)]
        [PropertyOrder(7)]
        public override string GEO6
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("径向排数")]
        [Description("径向(与冷气流动方向垂直)排数")]
        [BrowsableAttribute(true)]
        [PropertyOrder(8)]
        public override string GEO7
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("元件高度")]
        [BrowsableAttribute(true)]
        [PropertyOrder(9)]
        public override string GEO8
        {
            get;
            set;
        }
    }
}
