// Type: System.Windows.Forms.TreeNode
// Assembly: System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: c:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;

namespace System.Windows.Forms
{
    [DefaultProperty("Text")]
    [TypeConverter(typeof (TreeNodeConverter))]
    [Serializable]
    public class TreeNode : MarshalByRefObject, ICloneable, ISerializable
    {
        public TreeNode();
        public TreeNode(string text);
        public TreeNode(string text, TreeNode[] children);
        public TreeNode(string text, int imageIndex, int selectedImageIndex);
        public TreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children);
        protected TreeNode(SerializationInfo serializationInfo, StreamingContext context);
        public Color BackColor { get; set; }

        [Browsable(false)]
        public Rectangle Bounds { get; }

        [DefaultValue(false)]
        public bool Checked { get; set; }

        [DefaultValue(null)]
        public virtual ContextMenu ContextMenu { get; set; }

        [DefaultValue(null)]
        public virtual ContextMenuStrip ContextMenuStrip { get; set; }

        [Browsable(false)]
        public TreeNode FirstNode { get; }

        public Color ForeColor { get; set; }

        [Browsable(false)]
        public string FullPath { get; }

        [Browsable(false)]
        public IntPtr Handle { get; }

        [TypeConverter(typeof (TreeViewImageIndexConverter))]
        [Localizable(true)]
        [Editor(
            "System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(-1)]
        [RelatedImageList("TreeView.ImageList")]
        public int ImageIndex { get; set; }

        [TypeConverter(typeof (TreeViewImageKeyConverter))]
        [Localizable(true)]
        [DefaultValue("")]
        [Editor(
            "System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [RelatedImageList("TreeView.ImageList")]
        public string ImageKey { get; set; }

        public int Index { get; }

        [Browsable(false)]
        public bool IsEditing { get; }

        [Browsable(false)]
        public bool IsExpanded { get; }

        [Browsable(false)]
        public bool IsSelected { get; }

        [Browsable(false)]
        public bool IsVisible { get; }

        [Browsable(false)]
        public TreeNode LastNode { get; }

        [Browsable(false)]
        public int Level { get; }

        [Browsable(false)]
        public TreeNode NextNode { get; }

        [Browsable(false)]
        public TreeNode NextVisibleNode { get; }

        [Localizable(true)]
        [DefaultValue(null)]
        public Font NodeFont { get; set; }

        [ListBindable(false)]
        [Browsable(false)]
        public TreeNodeCollection Nodes { get; }

        [Browsable(false)]
        public TreeNode Parent { get; }

        [Browsable(false)]
        public TreeNode PrevNode { get; }

        [Browsable(false)]
        public TreeNode PrevVisibleNode { get; }

        [TypeConverter(typeof (TreeViewImageIndexConverter))]
        [Localizable(true)]
        [DefaultValue(-1)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Editor(
            "System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [RelatedImageList("TreeView.ImageList")]
        public int SelectedImageIndex { get; set; }

        [TypeConverter(typeof (TreeViewImageKeyConverter))]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Editor(
            "System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [RelatedImageList("TreeView.ImageList")]
        [Localizable(true)]
        public string SelectedImageKey { get; set; }

        [DefaultValue("")]
        [TypeConverter(typeof (ImageKeyConverter))]
        [Localizable(true)]
        [Editor(
            "System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [RelatedImageList("TreeView.StateImageList")]
        public string StateImageKey { get; set; }

        [Editor(
            "System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof (UITypeEditor))]
        [TypeConverter(typeof (NoneExcludedImageIndexConverter))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [RelatedImageList("TreeView.StateImageList")]
        [DefaultValue(-1)]
        public int StateImageIndex { get; set; }

        [Localizable(false)]
        [Bindable(true)]
        [DefaultValue(null)]
        [TypeConverter(typeof (StringConverter))]
        public object Tag { get; set; }

        [Localizable(true)]
        public string Text { get; set; }

        [DefaultValue("")]
        [Localizable(false)]
        public string ToolTipText { get; set; }

        public string Name { get; set; }

        [Browsable(false)]
        public TreeView TreeView { get; }

        #region ICloneable Members

        public virtual object Clone();

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context);

        #endregion

        public static TreeNode FromHandle(TreeView tree, IntPtr handle);
        public void BeginEdit();
        public void Collapse(bool ignoreChildren);
        public void Collapse();
        protected virtual void Deserialize(SerializationInfo serializationInfo, StreamingContext context);
        public void EndEdit(bool cancel);
        public void EnsureVisible();
        public void Expand();
        public void ExpandAll();
        public int GetNodeCount(bool includeSubTrees);
        public void Remove();
        protected virtual void Serialize(SerializationInfo si, StreamingContext context);
        public void Toggle();
        public override string ToString();
    }
}
