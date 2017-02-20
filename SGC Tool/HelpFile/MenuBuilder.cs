using System.Text;

namespace TOOLChuyenDuLieu
{
    public class MenuBuilder
    {
        public enum SPECIAL_MENU_ITEM
        {
            CLOSEALL = 0x66,
            EXIT = 0x69,
            GUIDE = 0x68,
            LOGOUT = 0x65,
            UPDATEPROGRAM = 0x67
        }
 

 

        // Methods
        public static string CreateItem(string ID, string Caption, string ParentID, bool IsEnable, string FormClass, bool IsMDI, bool IsSep, string ImageName, bool IsWaiting, string HelpPage, string ToolTip)
        {
            return CreateItem(ID, Caption, ParentID, IsEnable, FormClass, IsMDI, IsSep, ImageName, IsWaiting, HelpPage, ToolTip, true);
        }

        public static string CreateItem(string ID, string Caption, string ParentID, bool IsEnable, string FormClass, bool IsMDI, bool IsSep, string ImageName, bool IsWaiting, string HelpPage, string ToolTip, bool IsModal)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<Item>");
            builder.Append("<ID>" + ID + "</ID>");
            builder.Append("<Name>" + Caption + "</Name>");
            builder.Append("<Parents>" + ParentID + "</Parents>");
            builder.Append("<Enable>" + (IsEnable ? "Y" : "N") + "</Enable>");
            builder.Append("<Form>" + FormClass + "</Form>");
            builder.Append("<MDI>" + (IsMDI ? "Y" : "N") + "</MDI>");
            builder.Append("<Sep>" + (IsSep ? "Y" : "N") + "</Sep>");
            builder.Append("<ImageName>" + ImageName + "</ImageName>");
            builder.Append("<Waiting>" + (IsWaiting ? "Y" : "N") + "</Waiting>");
            builder.Append("<HelpPage>" + HelpPage + "</HelpPage>");
            builder.Append("<ToolTip>" + ToolTip + "</ToolTip>");
            builder.Append("<Modal>" + (IsModal ? "Y" : "N") + "</Modal>");
            builder.Append("</Item>");
            return builder.ToString();
        }

        public static void CreateItem(StringBuilder str, string ID, string Caption, string ParentID, bool IsEnable, string FormClass, bool IsMDI, bool IsSep, string ImageName, bool IsWaiting, string HelpPage, string ToolTip, bool IsModal)
        {
            str.Append(CreateItem(ID, Caption, ParentID, IsEnable, FormClass, IsMDI, IsSep, ImageName, IsWaiting, HelpPage, ToolTip, IsModal));
        }

        public static string CreatePlugin()
        {
            return "";
        }

        public static string CreatePluginItem()
        {
            return "";
        }

        public static string CreateRootItem(string ID, string Caption, string ToolTip)
        {
            return CreateItem(ID, Caption, "1", true, "", false, false, "", false, "", ToolTip, false);
        }

        public static string CreateRootItem(string ID, string Caption, string ImageName, string ToolTip)
        {
            return CreateItem(ID, Caption, "1", true, "", false, false, ImageName, false, "", ToolTip, false);
        }

        public static string CreateRootItem(string ID, string Caption, string FormClass, string ImageName, string ToolTip)
        {
            return CreateItem(ID, Caption, "1", true, FormClass, false, false, ImageName, false, "", ToolTip, false);
        }

        public static string CreateSpecialItem(SPECIAL_MENU_ITEM ID, string Caption, string ParentID, bool IsSep, string ImageName)
        {
            return CreateItem(ID.ToString(), Caption, ParentID, true, "", false, IsSep, ImageName, false, "", "", true);
        }
    }


}
