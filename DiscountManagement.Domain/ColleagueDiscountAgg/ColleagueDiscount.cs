

using My_Shop_Framework.Domain;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount:EntityBase
    {
        public long ProductId  { get;private set; }
        public int  DiscountRate { get; private set; }
        public bool IsRemove { get; private set; }

        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemove = false;
        }

        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Remove()
        {
            IsRemove = true;
        }

        public void Restore()
        {
            IsRemove = false;
        }
    }
}