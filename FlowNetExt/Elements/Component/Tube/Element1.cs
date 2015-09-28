using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    
    class Element1:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("AA进口面积（cm2）")]
        [PropertyOrder(1)]
        [BrowsableAttribute(true)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE01出口面积（cm2）"), PropertyOrder(2)]
        [BrowsableAttribute(true)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE02水力直径（cm）"), PropertyOrder(3)]
        [BrowsableAttribute(true)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE03长度（cm）"), PropertyOrder(4)]
        [BrowsableAttribute(true)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE04周长（cm）"), PropertyOrder(5)]
        [BrowsableAttribute(true)]
        public override string GEO4
        {
            get;
            set;
        }

    }
}
