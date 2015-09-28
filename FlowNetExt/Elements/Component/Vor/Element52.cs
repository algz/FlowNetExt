using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element52:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("GE01进口半径（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE02出口半径（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE03旋转比")]
        [BrowsableAttribute(true)]
        [PropertyOrder(4)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE04右盘RPM")]
        [BrowsableAttribute(true)]
        [PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("GE05左盘RPM")]
        [BrowsableAttribute(true)]
        [PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("GE07两盘间距（cm）")]
        [BrowsableAttribute(true)]
        [PropertyOrder(8)]
        public override string GEO7
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("KG")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1000)]
        public override string KG
        {
            get;
            set;
        }
    }
}
