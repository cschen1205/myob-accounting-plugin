namespace Was.AccServiceRef
{
    public partial class LightShippingMethod
    {
        public override bool Equals(object obj)
        {
            if (obj is LightShippingMethod)
            {
                LightShippingMethod _obj = (LightShippingMethod)obj;
                return _obj.ShippingMethodID.Equals(this.ShippingMethodID);
            }
          
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}