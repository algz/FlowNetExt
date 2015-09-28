using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyControls2008.Properties;
using System.Drawing.Design;

namespace MyControls2008
{
    public partial class ToolboxGroup : UserControl
    {
        public ToolboxGroup()
        {
            InitializeComponent();

            this.textBrush = new SolidBrush(this.ForeColor);
            this.textPointF = new PointF(19f, 3f);
            this.heightLarge = this.Height;
            this.heightSmall = this.Height;
            this.imageRec = new Rectangle(3, 3, 16, 16);
            this.rectangleColor未选中 = Color.FromArgb(206, 212, 223);
            this.rectangleColor选中 = Color.FromArgb(229, 195, 101);
            this.fillColor未选中上 = Color.FromArgb(240, 240, 240);
            this.fillColor未选中下 = Color.FromArgb(240, 240, 240);
            this.fillColor选中上 = Color.FromArgb(255, 249, 231);
            this.fillColor选中下 = Color.FromArgb(255, 242, 203);
            this.rectanglePen = new Pen(rectangleColor未选中);
            this.image展开前 = Resources.normal;
            this.image展开后 = Resources.launch;
            this.image = image展开前;
            this.fillBrush上 = new SolidBrush(fillColor未选中上);
            this.fillBrush下 = new SolidBrush(fillColor未选中下);
            this.itemSpace = 1;
            this.imageOffset = new Point(0, 1);

            this.ResetRec();

            展开StatusChanged += new EventHandler(ToolboxGroup_展开StatusChanged);
            SelectStatusChanged += new EventHandler(ToolboxGroup_SelectStatusChanged);
            OnItemsChanged += new EventHandler(ToolboxGroup_OnItemsChanged);

            Res.Item2Group.Add(this.items, this);
        }

        #region 显示文本
        [Browsable(false)]
        private string text = "";

        [Browsable(false)]
        private Brush textBrush;

        [Browsable(false)]
        private PointF textPointF;

        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                this.Showtext = base.Text;
            }
        }

        [Browsable(true),
        Category("扩展"),
        Description("显示文本变化时")]
        public event EventHandler OnShowtextChanged;

        [Browsable(true),
        Category("扩展"),
        Description("显示文本"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public string Showtext
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (OnShowtextChanged != null)
                    OnShowtextChanged.Invoke(this, new EventArgs());
                this.Invalidate();
            }
        }
        #endregion

        #region 文本偏移位置
        [Browsable(false)]
        private Point showtextOffset = new Point(0, 0);

        [Browsable(true),
        Category("扩展"),
        Description("文本偏移位置"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Point ShowtextOffset
        {
            get
            {
                return showtextOffset;
            }
            set
            {
                showtextOffset = value;
                textPointF = new PointF(19f, 3f).Add(showtextOffset);
                this.Invalidate();
            }
        }
        #endregion

        #region 图标 展开前 展开后
        [Browsable(false)]
        private Image image展开前;
        [Browsable(false)]
        private Image image展开后;
        [Browsable(false)]
        private Image image;

        [Browsable(false)]
        private Rectangle imageRec;

        [Browsable(true),
        Category("扩展"),
        Description("图标 展开前"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Image Image展开前
        {
            get
            {
                return image展开前;
            }
            set
            {
                image展开前 = value;
                if (!Is展开)
                    image = image展开前;
                this.Invalidate();
            }
        }

        [Browsable(true),
        Category("扩展"),
        Description("图标 展开后"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Image Image展开后
        {
            get
            {
                return image展开后;
            }
            set
            {
                image展开后 = value;
                if (Is展开)
                    image = image展开后;
                this.Invalidate();
            }
        }
        #endregion

        #region 图片大小
        [Browsable(false)]
        private Size imageSize = new Size(16, 16);

        [Browsable(true),
        Category("扩展"),
        Description("图片大小"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Size ImageSize
        {
            get
            {
                return imageSize;
            }
            set
            {
                imageSize = value;
                imageRec = new Rectangle(3, 3, 16, 16).Add(
                    imageOffset).ChangeWidthHeight(ImageSize);
                this.Invalidate();
            }
        }
        #endregion

        #region 图片偏移位置
        [Browsable(false)]
        private Point imageOffset = new Point(0, 0);

        [Browsable(true),
        Category("扩展"),
        Description("图片偏移位置"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Point ImageOffset
        {
            get
            {
                return imageOffset;
            }
            set
            {
                imageOffset = value;
                imageRec = new Rectangle(3, 3, 16, 16).Add(
                    imageOffset).ChangeWidthHeight(ImageSize);
                this.Invalidate();
            }
        }
        #endregion

        #region 内置窗体大小 展开前 展开后
        [Browsable(false)]
        private int heightSmall;
        [Browsable(false)]
        private int HeightSmall
        {
            get
            {
                return heightSmall;
            }
            set
            {
                heightSmall = value;
                this.Invalidate();
            }
        }
        [Browsable(false)]
        private int heightLarge;
        [Browsable(false)]
        private int HeightLarge
        {
            get
            {
                return heightLarge;
            }
            set
            {
                heightLarge = value;
                this.Invalidate();
            }
        }
        [Browsable(true),
        Description("内置窗体大小 展开前,\n不要手工修改"),
        Category("扩展"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Size SizeSmall
        {
            get
            {
                return new Size(this.Width, this.HeightSmall);
            }
            set
            {
                this.Width = value.Width;
                this.HeightSmall = value.Height;
                this.ResetRec();
                this.Invalidate();
            }
        }
        [Browsable(true),
        Description("内置窗体大小 展开后,\n不要手工修改"),
        Category("扩展"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Size SizeLarge
        {
            get
            {
                return new Size(this.Width, this.HeightLarge);
            }
            set
            {
                this.Width = value.Width;
                this.HeightLarge = value.Height;
                this.ResetRec();
                this.Invalidate();
            }
        }

        private void ResetRec()
        {
            this.rectangleRec = new Rectangle(
                0,
                0,
                this.Width - 1,
                this.HeightSmall - 1);

            this.fillRec上 = new Rectangle(
                1,
                1,
                this.Width - 2,
                this.HeightSmall / 2);

            this.fillRec下 = new Rectangle(
                1,
                1 + this.HeightSmall / 2,
                this.Width - 2,
                this.HeightSmall - 2 - this.HeightSmall / 2);

            this.ResetAllItems();
        }
        #endregion

        #region 控件框颜色 选中前 选中后
        [Browsable(false)]
        private Color rectangleColor未选中;
        [Browsable(false)]
        private Color rectangleColor选中;

        [Browsable(false)]
        private Pen rectanglePen;

        [Browsable(false)]
        private Rectangle rectangleRec;

        [Browsable(true),
        Category("扩展"),
        Description("控件框颜色 是否选中"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color RectangleColor未选中
        {
            get
            {
                return rectangleColor未选中;
            }
            set
            {
                rectangleColor未选中 = value;
                if (!IsSelect) {
                    rectanglePen = new Pen(rectangleColor未选中);
                }
                this.Invalidate();
            }
        }

        [Browsable(true),
        Category("扩展"),
        Description("控件框颜色 展开后"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color RectangleColor选中
        {
            get
            {
                return rectangleColor选中;
            }
            set
            {
                rectangleColor选中 = value;
                if (IsSelect) {
                    rectanglePen = new Pen(rectangleColor选中);
                }
                this.Invalidate();
            }
        }
        #endregion

        #region 背景颜色 上下 选中 未选中
        [Browsable(false)]
        private Color fillColor未选中上;
        [Browsable(false)]
        private Color fillColor未选中下;
        [Browsable(false)]
        private Color fillColor选中上;
        [Browsable(false)]
        private Color fillColor选中下;

        [Browsable(false)]
        private Brush fillBrush上;
        [Browsable(false)]
        private Brush fillBrush下;

        [Browsable(false)]
        private Rectangle fillRec上;
        [Browsable(false)]
        private Rectangle fillRec下;

        [Browsable(true),
        Category("扩展"),
        Description("背景 展开前上"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color FillColor展开前上
        {
            get
            {
                return fillColor未选中上;
            }
            set
            {
                fillColor未选中上 = value;
                if (!IsSelect)
                    this.fillBrush上 = new SolidBrush(this.fillColor未选中上);
                this.Invalidate();
            }
        }

        [Browsable(true),
        Category("扩展"),
        Description("背景 展开前下"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color FillColor展开前下
        {
            get
            {
                return fillColor未选中下;
            }
            set
            {
                fillColor未选中下 = value;
                if (!IsSelect)
                    this.fillBrush下 = new SolidBrush(this.fillColor未选中下);
                this.Invalidate();
            }
        }

        [Browsable(true),
        Category("扩展"),
        Description("背景 展开后上"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color FillColor展开后上
        {
            get
            {
                return fillColor选中上;
            }
            set
            {
                fillColor选中上 = value;
                if (IsSelect)
                    this.fillBrush上 = new SolidBrush(this.fillColor选中上);
                this.Invalidate();
            }
        }

        [Browsable(true),
        Category("扩展"),
        Description("背景 展开后下"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color FillColor展开后下
        {
            get
            {
                return fillColor选中下;
            }
            set
            {
                fillColor选中下 = value;
                if (IsSelect)
                    this.fillBrush下 = new SolidBrush(this.fillColor选中下);
                this.Invalidate();
            }
        }
        #endregion

        #region is展开 展开
        [Browsable(false)]
        private bool is展开 = false;

        [Browsable(true),
        Category("扩展"),
        Description("是否展开状态改变时")]
        public event EventHandler 展开StatusChanged;

        [Browsable(true),
        Category("扩展"),
        Description("是否展开状态"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public bool Is展开
        {
            get
            {
                return is展开;
            }
            set
            {
                is展开 = value;
                if (展开StatusChanged != null)
                    展开StatusChanged.Invoke(this, new EventArgs());
                this.Invalidate();
            }
        }
        #endregion

        #region isSelect 控件是否被选中
        [Browsable(false)]
        private bool isSelect = false;

        [Browsable(true),
        Category("扩展"),
        Description("控件是否被选中状态改变时")]
        public event EventHandler SelectStatusChanged;

        [Browsable(true),
        Category("扩展"),
        Description("控件是否被选中"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public bool IsSelect
        {
            get
            {
                return isSelect;
            }
            set
            {
                isSelect = value;
                if (SelectStatusChanged != null)
                    SelectStatusChanged.Invoke(this, new EventArgs());
                this.Invalidate();
            }
        }
        #endregion

        #region 控件间隔
        [Browsable(false)]
        private int itemSpace;

        [Browsable(true),
        Category("扩展"),
        Description("控件是否被选中"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public int ItemSpace
        {
            get
            {
                return itemSpace;
            }
            set
            {
                itemSpace = value;
                this.ResetAllItems();
                this.Invalidate();
            }
        }
        #endregion

        #region Group子项Items集合
        [Browsable(false)]
        private List<ToolboxItem> items = new List<ToolboxItem>();

        public event EventHandler OnItemsChanged;

        [Category("扩展"),
        Description("Group子项Items集合"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Editor(typeof(ToolboxItemCollection), typeof(UITypeEditor)),
        RefreshProperties(RefreshProperties.All),
        NotifyParentProperty(true)]
        public List<ToolboxItem> Items
        {
            get
            {
                return items;
            }
        }
        #endregion

        #region ToolboxGroup_OnItemsChanged
        public void Raise_ItemsChanged()
        {
            if (OnItemsChanged != null)
                OnItemsChanged.Invoke(this, new EventArgs());
        }

        public void ToolboxGroup_OnItemsChanged(object sender, EventArgs e)
        {
            ResetAllItems();

            this.Is展开 = true;
        }

        public void ResetAllItems()
        {
            int count = this.Items.Count;
            count = this.Items.Count;
            this.Controls.Clear();

            int newHeight = this.HeightSmall;

            for (int i = 0; i < count; i++) {

                newHeight += this.itemSpace + this.Items[i].Height;
                this.Items[i].Location = new Point(0, newHeight - this.Items[i].Height);
                this.Items[i].Width = this.Width;
                this.Items[i].IsSelect = false;
                this.Items[i].Parent = this;
            }

            this.HeightLarge = newHeight;
        }
        #endregion

        #region OnFontChanged
        protected override void OnFontChanged(EventArgs e)
        {
            //base.OnFontChanged(e);
            this.Invalidate();
        }
        #endregion

        #region OnForeColorChanged
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

            this.textBrush = new SolidBrush(this.ForeColor);
            this.Invalidate();
        }
        #endregion

        #region ToolboxGroup_展开StatusChanged
        protected void ToolboxGroup_展开StatusChanged(object sender, EventArgs e)
        {
            if (Is展开) {
                image = Image展开后;
                this.Height = this.HeightLarge;
            }
            else {
                image = Image展开前;
                this.Height = this.HeightSmall;

                int count = this.items.Count;
                for (int i = 0; i < count; i++) {
                    this.items[i].IsSelect = false;
                }
            }
        }
        #endregion

        #region ToolboxGroup_SelectStatusChanged
        protected void ToolboxGroup_SelectStatusChanged(object sender, EventArgs e)
        {
            if (IsSelect) {
                rectanglePen = new Pen(rectangleColor选中);
                this.fillBrush上 = new SolidBrush(this.fillColor选中上);
                this.fillBrush下 = new SolidBrush(this.fillColor选中下);
            }
            else {
                rectanglePen = new Pen(rectangleColor未选中);
                this.fillBrush上 = new SolidBrush(this.fillColor未选中上);
                this.fillBrush下 = new SolidBrush(this.fillColor未选中下);
            }
        }
        #endregion

        #region OnMouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Y <= this.HeightSmall) {
                this.IsSelect = true;
                this.Is展开 = !this.Is展开;

                Toolbox t = this.Parent as Toolbox;
                if (t != null) {
                    t.ForItem_ItemIsSelect(this);
                }
            }
        }
        #endregion

        #region OnSizeChanged
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (!this.Is展开) {
                this.HeightSmall = this.Height;
                this.ResetAllItems();
            }
            else {
                this.HeightSmall = this.Height - this.Items.Sum(x => x.Height + this.ItemSpace);
                this.ResetAllItems();
            }

            this.ResetRec();

            this.Invalidate();
        }
        #endregion

        #region  重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.isRepaint) {
                base.OnPaint(e);
                this.NewPaint(e);
            }
        }

        private void NewPaint(PaintEventArgs e)
        {
            using (BufferedGraphics Buf = Res.Context.Allocate(e.Graphics, e.ClipRectangle)) {

                Graphics g = Buf.Graphics;
                g.Clear(this.BackColor);

                g.DrawRectangle(rectanglePen, rectangleRec);

                g.FillRectangle(fillBrush上, fillRec上);
                g.FillRectangle(fillBrush下, fillRec下);

                g.DrawImage(image, imageRec);
                g.DrawString(this.Showtext, this.Font, textBrush, textPointF);

                Buf.Render(e.Graphics);
                g.Dispose();
            }
        }
        #endregion

        #region FOR SUNITEM 当点击Group子项时发生(改变Group为未选中状态)
        public void ForItem_ItemIsSelect(ToolboxItem item)
        {
            this.IsSelect = false;
            int count = this.items.Count;

            for (int i = 0; i < count; i++) {
                if (this.items[i] != item)
                    this.items[i].IsSelect = false;
            }

            Toolbox t = this.Parent as Toolbox;
            if (t != null) {
                t.ForItem_ItemIsSelect(this);
            }
        }
        #endregion

        public bool isRepaint = true;
    }

    #region 支持集合编辑器
    public class ToolboxGroupCollection
        : System.ComponentModel.Design.CollectionEditor
    {
        public ToolboxGroupCollection(Type type)
            : base(type)
        {
        }

        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        protected override object CreateInstance(Type itemType)
        {
            Res.isGroupCreate = true;
            return base.CreateInstance(itemType);
        }

        protected override object SetItems(object editValue, object[] value)
        {
            try {
                return base.SetItems(editValue, value);
            }
            finally {
                if (Res.isGroupCreate) {
                    Res.isGroupCreate = false;
                }
                else {
                    List<ToolboxGroup> obj = (List<ToolboxGroup>)editValue;
                    ((Toolbox)Res.Group2Toolbox[obj]).Raise_GroupsChanged();
                }
            }
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(ToolboxGroup);
        }
    }
    #endregion
}
