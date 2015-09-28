using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyControls2008
{
    [
    DefaultEvent("Click"),
    TypeConverter(typeof(ExpandableObjectConverter))
    ]
    public partial class ToolboxItem : UserControl
    {
        public ToolboxItem() {
            InitializeComponent();

            this.textBrush = new SolidBrush(this.ForeColor);
            this.textPointF = new PointF(48f, 3f);
            this.imageRec = new Rectangle(19, 3, 16, 16);
            this.rectanglePen = new Pen(rectangleColor);
            this.fillBrush = new SolidBrush(fillColor);
            this.rectangleRec = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            this.fillRec = new Rectangle(1, 1, this.Width - 2, this.Height - 2);

            this.SelectStatusChanged += new EventHandler(ToolboxItem_SelectStatusChanged);
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
                textPointF = new PointF(48f, 3f).Add(showtextOffset);
                this.Invalidate();
            }
        }
        #endregion

        #region 显示图标
        [Browsable(false)]
        private Image image;

        [Browsable(false)]
        private Rectangle imageRec;

        [Browsable(true),
        Category("扩展"),
        Description("显示图标"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Image Image
        {
            get
            {
                return image ?? new Bitmap(16, 16);
            }
            set
            {
                image = value;
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
                imageRec = new Rectangle(19, 3, 16, 16).Add(
                    imageOffset).ChangeWidthHeight(ImageSize);
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
                imageRec = new Rectangle(19, 3, 16, 16).Add(
                    imageOffset).ChangeWidthHeight(ImageSize);
                this.Invalidate();
            }
        }
        #endregion

        #region isMouseOn 鼠标是否在控件上
        [Browsable(false)]
        private bool isMouseOn = false;

        [Browsable(true),
        Category("扩展"),
        Description("鼠标进入或离开时")]
        public event EventHandler MouseOnStatusChanged;

        [Browsable(true),
        Category("扩展"),
        Description("鼠标是否在控件上"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public bool IsMouseOn
        {
            get
            {
                return isMouseOn;
            }
            set
            {
                isMouseOn = value;
                if(MouseOnStatusChanged!=null)
                    MouseOnStatusChanged.Invoke(this, new EventArgs());
                this.Invalidate();
            }
        }
        #endregion

        #region IsSelect 控件是否被选中
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

        #region 控件框颜色
        [Browsable(false)]
        private Color rectangleColor = Color.FromArgb(229, 195, 101);

        [Browsable(false)]
        private Pen rectanglePen;

        [Browsable(false)]
        private Rectangle rectangleRec;

        [Browsable(true),
        Category("扩展"),
        Description("控件框颜色"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color RectangleColor
        {
            get
            {
                return rectangleColor;
            }
            set
            {
                rectangleColor = value;
                rectanglePen = new Pen(rectangleColor);
                this.Invalidate();
            }
        }
        #endregion

        #region 选中背景颜色
        [Browsable(false)]
        private Color fillColor = Color.FromArgb(255, 239, 187);

        [Browsable(false)]
        private Brush fillBrush;

        [Browsable(false)]
        private Rectangle fillRec;

        [Browsable(true),
        Category("扩展"),
        Description("选中背景颜色"),
        RefreshProperties(RefreshProperties.Repaint),
        NotifyParentProperty(true)]
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
                fillBrush = new SolidBrush(fillColor);
                this.Invalidate();
            }
        }
        #endregion

        #region OnMouseEnter 鼠标移至控件上
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.IsMouseOn = true;
        }
        #endregion

        #region OnMouseLeave 鼠标离开控件
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            
            this.IsMouseOn = false;
            
        }
        #endregion

        #region OnMouseDown 控件被选中
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.IsSelect = true;
        }
        #endregion

        #region SizeChanged
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            rectangleRec = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            fillRec = new Rectangle(1, 1, this.Width - 2, this.Height - 2);

            ToolboxGroup g = this.Parent as ToolboxGroup;
            if (g != null) {
                g.Height = g.SizeSmall.Height + g.Items.Sum(x => x.Height + g.ItemSpace);
                g.Width = this.Width;
            }
        }
        #endregion

        #region OnForeColorChanged 
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

            textBrush = new SolidBrush(this.ForeColor);
        }
        #endregion

        #region 重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.NewPaint(e);
        }

        private void NewPaint(PaintEventArgs e)
        {
            using (BufferedGraphics Buf = Res.Context.Allocate(e.Graphics, e.ClipRectangle)) {

                Graphics g = Buf.Graphics;
                g.Clear(this.BackColor);

                if (this.IsMouseOn || this.IsSelect) {
                    g.DrawRectangle(rectanglePen, rectangleRec);
                    g.FillRectangle(fillBrush, fillRec);
                }

                if (this.Image != null) {
                    g.DrawImage(Image, imageRec);
                }

                g.DrawString(this.Showtext, this.Font, textBrush, textPointF);

                Buf.Render(e.Graphics);
                g.Dispose();
            }
        }
        #endregion

        #region ToolboxItem_SelectStatusChanged(影响GroupSelect)
        void ToolboxItem_SelectStatusChanged(object sender, EventArgs e)
        {
            ToolboxGroup g = this.Parent as ToolboxGroup;
            if (g != null && isSelect) {
                g.ForItem_ItemIsSelect(this);
            }
        }
        #endregion
    }

    #region 支持集合编辑器
    public class ToolboxItemCollection
        : System.ComponentModel.Design.CollectionEditor
    {
        public ToolboxItemCollection(Type type)
            : base(type)
        {
        }

        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        protected override object CreateInstance(Type itemType)
        {
            Res.isItemCreate = true;
            return base.CreateInstance(itemType);
        }

        protected override object SetItems(object editValue, object[] value)
        {
            try {
                return base.SetItems(editValue, value);
            }
            finally {
                if (Res.isItemCreate) {
                    Res.isItemCreate = false;
                }
                else {
                    List<ToolboxItem> obj = (List<ToolboxItem>)editValue;
                    ((ToolboxGroup)Res.Item2Group[obj]).Raise_ItemsChanged();
                }
            }
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(ToolboxItem);
        }
    }
    #endregion
}
