using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.Component.Holfm1
{
    class Element24:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("孔面积")]
        [BrowsableAttribute(true)]
        public override string AA
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("孔径")]
        [BrowsableAttribute(true)]
        public override string GEO1
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("孔长")]
        [BrowsableAttribute(true)]
        public override string GEO2
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("孔倾角")]
        [BrowsableAttribute(true)]
        public override string GEO3
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("偏航角")]
        [BrowsableAttribute(true)]
        public override string GEO4
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("Mg")]
        [BrowsableAttribute(true)]
        public override string GEO5
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("Tg")]
        [BrowsableAttribute(true)]
        public override string GEO6
        {
            get;
            set;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("扇/圆形出口面积")]
        [BrowsableAttribute(true)]
        public override string GEO7
        {
            get;
            set;
        }
    }
}
