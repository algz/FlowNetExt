using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Runtime.InteropServices;


//要往toolbox中加group,点扩展属性的items添加;group中添加item也同样,不能拖个group进toolbox,这样是无效的,有问题的.
namespace MyControls2008
{

    public partial class Toolbox : FlowLayoutPanel
    {
        public Toolbox()
        {
            InitializeComponent();

            Res.Group2Toolbox.Add(this.items, this);

            OnGroupssChanged += new EventHandler(Toolbox_OnGroupssChanged);
        }

        [Browsable(false)]
        private List<ToolboxGroup> items = new List<ToolboxGroup>();

        public event EventHandler OnGroupssChanged;

        [Category("扩展"),
        Description("Toolbox子项Groups集合"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Editor(typeof(ToolboxGroupCollection), typeof(UITypeEditor)),
        RefreshProperties(RefreshProperties.All),
        NotifyParentProperty(true)]
        public List<ToolboxGroup> Items
        {
            get
            {
                return items;
            }
        }

        public FlowLayoutPanel panel = new FlowLayoutPanel();

        public void Raise_GroupsChanged()
        {
            if (OnGroupssChanged != null)
                OnGroupssChanged.Invoke(this, new EventArgs());
        }

        public void ForItem_ItemIsSelect(ToolboxGroup group)
        {
            int count = this.items.Count;
            for (int i = 0; i < count; i++) {

                ToolboxGroup g = this.items[i];

                if (g != group) {

                    g.IsSelect = false;

                    int count2 = g.Items.Count;
                    for (int j = 0; j < count2; j++) {

                        g.Items[j].IsSelect = false;
                    }
                }
            }
        }

        void Toolbox_OnGroupssChanged(object sender, EventArgs e)
        {
            int count = this.items.Count;
            this.Controls.Clear();

            int newWidth = 0;
            if (this.items.Sum(x =>
                x.Height + x.Margin.Top + x.Margin.Bottom) > this.Height)

                newWidth = this.Width - 21;
            else
                newWidth = this.Width - 4;

            for (int i = 0; i < count; i++) {
                this.items[i].Width = newWidth;
                this.items[i].Parent = this;
                this.Controls.Add(this.items[i]);
            }

            this.Invalidate();
        }

        public void ResetGroupWidth(int p)
        {
            int count = this.items.Count;
            for (int i = 0; i < count; i++) {
                this.items[i].isRepaint = false;
                this.items[i].Width = this.Width + p;
                this.items[i].isRepaint = true;
            }
        }

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 解决一些闪烁问题,(原来内部控件多了,当出现垂直滚动条与不出现交替时会有闪烁).
        /// 导入了:
        /// public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        /// 添加了:
        /// SendMessage(this.Handle, 11, (IntPtr)0, (IntPtr)0); 
        /// ......
        /// SendMessage(this.Handle, 11, (IntPtr)1, (IntPtr)0);
        /// this.Refresh();
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            SendMessage(this.Handle, 11, (IntPtr)0, (IntPtr)0); 
            base.OnSizeChanged(e);

            if (VScroll) {
                this.ResetGroupWidth(-21);
            }
            else {
                this.ResetGroupWidth(-4);
            }
            this.HScroll = false;
            SendMessage(this.Handle, 11, (IntPtr)1, (IntPtr)0);
            this.Refresh();
        }
    }
}
