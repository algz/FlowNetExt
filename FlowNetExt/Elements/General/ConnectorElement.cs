using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlowNetExt.Elements.General
{
    class ConnectorElement : Element
    {
        [BrowsableAttribute(false)]
        public override string KG
        {
            get;
            set;
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

        #region 计算结果

        [Category("计算结果")]
        //[DisplayNameAttribute("进口面积")]
        //[DefaultValueAttribute("0")]
        //[Description("进口面积.")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("压力"), PropertyOrder(1)]
        [ReadOnlyAttribute(true)]
        public virtual string Pressure
        {
            get;
            set;
        }

        

        [Category("计算结果")]
        //[DisplayNameAttribute("进口面积")]
        //[DefaultValueAttribute("0")]
        //[Description("进口面积.")]
        //[BrowsableAttribute(false)]
        [DisplayNameAttribute("温度"), PropertyOrder(2)]
        [ReadOnlyAttribute(true)]
        public virtual string Temperature
        {
            get;
            set;
        }

        #endregion
    }
}
