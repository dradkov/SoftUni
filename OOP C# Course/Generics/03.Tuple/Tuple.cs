namespace Tuple
{
    public class Threeuple<T, U, S>
    {

        public Threeuple(T firstItem, U secondItem, S thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
        }


        public T FirstItem { get; private set; }
        public U SecondItem { get; private set; }
        public S ThirdItem { get; private set; }


        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem} -> {this.ThirdItem}";
        }
    }
}

