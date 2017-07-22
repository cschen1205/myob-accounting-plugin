namespace Was.AccServiceRef {
 
    public partial class LightCustomer {

        public override bool Equals(object obj)
        {

            if (obj is LightCustomer)
            {
                LightCustomer _obj = (LightCustomer)obj;
                return _obj.CustomerID.Equals(this.CustomerID);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

  }
}