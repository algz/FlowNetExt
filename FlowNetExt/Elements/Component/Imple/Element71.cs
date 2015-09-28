using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component
{
    class Element71:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("射流孔面积")]
        [BrowsableAttribute(true)]
        [PropertyOrder(1)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("射流孔直径")]
        [BrowsableAttribute(true)]
        [PropertyOrder(2)]
        public override string GEO1
        {
            get;
            set;
        }


        [Category("输入参数")]
        [DisplayNameAttribute("靶面高度")]
        [BrowsableAttribute(true)]
        [PropertyOrder(3)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("孔间距")]
        [BrowsableAttribute(true)]
        [PropertyOrder(4)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("靶面内腔直径")]
        [BrowsableAttribute(true)]
        [PropertyOrder(5)]
        public override string GEO4
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("不做转热计算")]
        [BrowsableAttribute(true)]
        [PropertyOrder(6)]
        public override string GEO5
        {
            get;
            set;
        }
    }
}
