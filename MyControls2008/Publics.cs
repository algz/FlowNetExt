using System.Drawing;
using System.Collections;

namespace MyControls2008
{
    /// <summary>
    /// Point扩展方法
    /// </summary>
    public static class PointExtend
    {
        /// <summary>
        /// Point相加
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point Add(this Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
    }

    /// <summary>
    /// PointF扩展方法
    /// </summary>
    public static class PointFExtend
    {
        /// <summary>
        /// Point相加
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static PointF Add(this PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static PointF Add(this PointF p1, Point p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }
    }

    /// <summary>
    /// Rectangle扩展方法
    /// </summary>
    public static class RectangleExtend
    {
        /// <summary>
        /// Rectangle相加
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Rectangle Add(this Rectangle r, Point p)
        {
            return new Rectangle(r.X + p.X, r.Y + p.Y, r.Width, r.Height);
        }

        /// <summary>
        /// Rectangle变换大小
        /// </summary>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Rectangle ChangeWidthHeight(this Rectangle r, Size s)
        {
            return new Rectangle(r.X, r.Y, s.Width, s.Height);
        }
    }

    /// <summary>
    ///  公共资源
    /// </summary>
    public static class Res
    {
        /// <summary>
        /// 双缓存
        /// </summary>
        public static BufferedGraphicsContext Context =
              BufferedGraphicsManager.Current;

        public static Hashtable Item2Group = new Hashtable();
        public static Hashtable Group2Toolbox = new Hashtable();

        public static bool isItemCreate = false;
        public static bool isGroupCreate = false;
    }
}
