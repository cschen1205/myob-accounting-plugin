namespace Was.AccServiceRef
{
    public partial class LightTerms
    {
        public override bool Equals(object obj)
        {
            if (obj is LightTerms)
            {
                LightTerms _obj = (LightTerms)obj;
                return _obj.TermsID.Equals(this.TermsID);
            }
           
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}