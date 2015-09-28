using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FlowNetExt.Elements.Component;

namespace FlowNetExt.Elements.Component
{
    class Element96:Element
    {

        [Category("输入参数")]
        [DisplayNameAttribute("AA进口面积（cm2）"), PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GE01出口面积（cm2）"), PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("GE02阀门开度"), PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("KG"), PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }
    }
}
