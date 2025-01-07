namespace Forestage.Models.Enums
{
    public enum OrderStatus
    {
        /// <summary>
        /// 取消
        /// </summary>
        Cancelled = 0,

        /// <summary>
        /// 參與中
        /// </summary>
        Participating = 1,

        /// <summary>
        /// 成立
        /// </summary>
        Established = 2,

        /// <summary>
        /// 運送中
        /// </summary>
        Shipping = 3,

        /// <summary>
        /// 到貨
        /// </summary>
        Arrived = 4,

        /// <summary>
        /// 已取貨
        /// </summary>
        PickedUp = 5,

        /// <summary>
        /// 未取貨
        /// </summary>
        Unclaimed = 6
    }

}
