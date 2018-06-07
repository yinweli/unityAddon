using Delaunay;
using System.Collections.Generic;
using System.Linq;

namespace FouridStudio
{
    /// <summary>
    /// Voronoi演算法包裝類別
    /// </summary>
    public class VoronoiWapper
    {
        #region 屬性

        /// <summary>
        /// 寬度
        /// </summary>
        private int width = 0;

        /// <summary>
        /// 高度
        /// </summary>
        private int height = 0;

        /// <summary>
        /// Voronoi演算法物件
        /// </summary>
        private Voronoi voronoi = null;

        #endregion 屬性

        #region 主要函式

        /// <param name="points">初始座標列表</param>
        /// <param name="width">寬度</param>
        /// <param name="height">高度</param>
        /// <param name="lloydIterations">LloydRelaxation演算法迭代次數</param>
        public VoronoiWapper(IEnumerable<Vector2f> points, int width, int height, int lloydIterations)
        {
            this.width = width;
            this.height = height;
            this.voronoi = new Voronoi(points.ToList(), new Rectf(0, 0, width, height), lloydIterations);

            foreach (Vector2f itor in voronoi.SiteCoords())
                this.voronoi.Region(itor);
        }

        /// <summary>
        /// 取得寬度
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
        }

        /// <summary>
        /// 取得高度
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
        }

        /// <summary>
        /// 取得Voronoi演算法物件
        /// </summary>
        public Voronoi Voronoi
        {
            get
            {
                return voronoi;
            }
        }

        /// <summary>
        /// 取得全部地區的中心座標
        /// </summary>
        /// <returns>座標列表</returns>
        public Vector2f[] getCenters()
        {
            return voronoi.SiteCoords().ToArray();
        }

        /// <summary>
        /// 取得指定地區的頂點座標列表
        /// </summary>
        /// <param name="point">地區中心座標</param>
        /// <returns>座標列表</returns>
        public Vector2f[] getVertexs(Vector2f point)
        {
            return voronoi.Region(point).ToArray();
        }

        /// <summary>
        /// 取得指定地區的鄰居地區中心座標列表
        /// </summary>
        /// <param name="point">地區中心座標</param>
        /// <returns>座標列表</returns>
        public Vector2f[] getNeighborCenters(Vector2f point)
        {
            return voronoi.NeighborSitesForSite(point).ToArray();
        }

        /// <summary>
        /// 取得全部地區的邊線列表
        /// </summary>
        /// <returns>邊線列表</returns>
        public LineSegment[] getBoundarays()
        {
            return voronoi.VoronoiDiagram().ToArray();
        }

        /// <summary>
        /// 取得指定地區的邊線列表
        /// </summary>
        /// <param name="point">地區中心座標</param>
        /// <returns>邊線列表</returns>
        public LineSegment[] getBoundarays(Vector2f point)
        {
            return voronoi.VoronoiBoundarayForSite(point).ToArray();
        }

        #endregion 主要函式
    }
}