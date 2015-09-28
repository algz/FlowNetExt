using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.General
{
    class StartElement:Element
    {
        [Category("输入参数")]
        [DisplayNameAttribute("压力（Pa）")]
        [BrowsableAttribute(true)]
        public override string param1
        {
            set;
            get;
        }

        [Category("输入参数")]
        [DisplayNameAttribute("总温（K）")]
        [BrowsableAttribute(true)]
        public override string param2
        {
            set;
            get;
        }

        [BrowsableAttribute(false)]
        public override string KG
        {
            set;
            get;
        }

        #region 输出参数

        [BrowsableAttribute(false)]
        public override string TTI
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string TTE
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string PSI
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string PSE
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string FH1
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string FH2
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string FH3
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string FH4
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string RME
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string RMI
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string DOEL
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        public override string AKG
        {
            get;
            set;
        }

        #endregion
    }
}
