
namespace TOOLChuyenDuLieu
{
    public class GenID
    {
        // Fields
        private int GroupID = 0x3e8;
        private int ItemID = 0;

        // Methods
        public string CurrentGroup()
        {
            return ("G" + this.GroupID);
        }

        public string NewGroup()
        {
            this.GroupID++;
            return ("G" + this.GroupID);
        }

        public string NewItem()
        {
            this.ItemID++;
            return ("I" + this.ItemID);
        }

        public string ParentGroup()
        {
            return ("G" + (this.GroupID - 1));
        }
    }


}
